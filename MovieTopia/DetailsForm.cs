using MovieTopia.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTopia
{
    public partial class DetailsForm : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        public Dictionary<string, Control> controlsDict = new Dictionary<string, Control>();
        private bool newRecord;
        DataSet ds;
        SqlDataAdapter adapter;

        /// <summary>
        /// This form automatically builds itself based on the parameters passed into it.
        /// The schemaName is the table name of the record which you are creating or editing.
        /// The dataSet contains all of the DataTables from the select queries for accessing child entity data. Important that the table or accessing name is the entity name itself eg. Movie or MovieSchedule.
        /// The selectedDataGridViewRow is the currently selected or highlighted row in the Data grid. Ensure to set the datagrid Multiselect property to false, otherwise errors can occur.
        /// The foreignKeySchemaNames is a dictionary that maps the foreign key field name to the column in the child entity you wish to see in the drop down. The default values visible are the ID's
        /// 
        /// Alot of the automation is based on a schema query to the database to get it's structure and layout, such as the primitive data types (to create the correct control), and whether the field is a foreign key or primary key etc.
        /// </summary>
        /// <param name="schemaName"></param>
        /// <param name="dataSet"></param>
        /// <param name="selectedDataGridViewRow"></param>
        /// <param name="foreignKeySchemaNames"></param>
        public DetailsForm(string schemaName, DataSet dataSet = null, DataGridViewRow selectedDataGridViewRow = null, Dictionary<string, string> foreignKeySchemaNames = null)
        {
            InitializeComponent();

            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (dataSet == null || selectedDataGridViewRow == null) this.newRecord = true;

            QuerySchema(schemaName);
            PopulateFields(selectedDataGridViewRow, dataSet, foreignKeySchemaNames);          
        }

        private void QuerySchema(string schemaName)
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                string sql = $@"
                    SELECT
                        c.name AS [columnName],
                        t.name AS [dataType],
                        c.max_length AS [maxLength],
                        c.IS_NULLABLE AS [isNullable],
                        c.default_object_id AS [defaultValue],
                        CASE 
                            WHEN fk.parent_column_id IS NOT NULL THEN CAST(1 AS BIT) -- TRUE
                            ELSE CAST(0 AS BIT) -- FALSE
                        END AS [isForeign],
                        CASE 
                            WHEN pk.index_id IS NOT NULL THEN CAST(1 AS BIT) -- TRUE for Primary Key
                            ELSE CAST(0 AS BIT) -- FALSE for Primary Key
                        END AS [isPrimary]
                    FROM 
                        sys.columns c
                    INNER JOIN 
                        sys.tables tbl ON c.object_id = tbl.object_id
                    INNER JOIN 
                        sys.types t ON c.user_type_id = t.user_type_id
                    LEFT JOIN 
                        (
                            SELECT 
                                fkc.parent_column_id,
                                fkc.parent_object_id
                            FROM 
                                sys.foreign_key_columns fkc
                            INNER JOIN 
                                sys.foreign_keys fk ON fkc.constraint_object_id = fk.object_id
                        ) AS fk ON c.column_id = fk.parent_column_id AND c.object_id = fk.parent_object_id
                    LEFT JOIN 
                        (
                            SELECT 
                                ic.column_id,
                                ic.object_id,
                                i.index_id
                            FROM 
                                sys.index_columns ic
                            INNER JOIN 
                                sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id
                            WHERE 
                                i.is_primary_key = 1
                        ) AS pk ON c.column_id = pk.column_id AND c.object_id = pk.object_id
                    WHERE 
                        tbl.name = '{schemaName}'
                    ORDER BY 
                        c.column_id;";

                adapter.SelectCommand = new SqlCommand(sql, conn); ;
                adapter.Fill(ds, "TableSchema");
            }
        }

        public static Dictionary<string, object> ToDictionary(DataGridViewRow row, Dictionary<string, object> schemaRowData)
        {
            var dictionary = new Dictionary<string, object>();

            // Loop through each cell in the row
            foreach (DataGridViewCell cell in row.Cells)
            {
                // Get the column name and the cell value
                string columnName = row.DataGridView.Columns[cell.ColumnIndex].Name;

                object cellValue = cell.Value != null ? cell.Value : schemaRowData[columnName];
                //MessageBox.Show(columnName);

                // Add the column name and value to the dictionary
                dictionary[columnName] = cellValue;
            }

            return dictionary;
        }

        public static Dictionary<string, object> ToDictionary(DataTable table)
        {
            var dictionary = new Dictionary<string, object>();

            // Loop through each cell in the row
            foreach (DataRow row in table.Rows)
            {
                // Get the column name and the cell value
                string key = row["columnName"].ToString();
                string value = row["defaultValue"].ToString();
                //MessageBox.Show(columnName);

                // Add the column name and value to the dictionary
                dictionary[key] = value;
            }

            return dictionary;
        }

        private void PopulateFields(DataGridViewRow dataRow, DataSet dataSet, Dictionary<string, string> foreignKeySchemaNames)
        {
            // Clear existing controls
            this.Controls.Clear();

            int y = 10; // Initial vertical position for the fields

            DataTable schemaTable = ds.Tables["TableSchema"];

            var schemaRowData = ToDictionary(schemaTable);
            var fieldData = schemaRowData;
            if (!newRecord)
            {
                fieldData = ToDictionary(dataRow, schemaRowData);
            }

            Label formLabel = new Label
            {
                Text = newRecord ? "New Item" : "Edit Item",
                Top = y,
                Left = 10,
                Width = 100
            };
            this.Controls.Add(formLabel);
            y += 30;

            foreach (DataRow schemaRow in schemaTable.Rows)
            {
                string schemaColumnName = schemaRow["columnName"].ToString();
                string dataType = schemaRow["dataType"].ToString();
                string maxLength = schemaRow["maxLength"].ToString();
                var defaultValue = schemaRow["defaultValue"];
                bool foreignKey = (bool)schemaRow["isForeign"];
                bool primaryKey = (bool)schemaRow["isPrimary"];

                if (!fieldData.ContainsKey(schemaColumnName)) { continue; }

                Label label = new Label
                {
                    Text = schemaColumnName,
                    Top = y,
                    Left = 10,
                    Width = 100
                };

                Control control;
                fieldData.TryGetValue(schemaColumnName, out object fieldValue);
                if (dataType == "bit") // Handle booleans
                {
                    control = new CheckBox
                    {
                        Text = schemaColumnName,
                        Checked = (bool)fieldData[schemaColumnName],
                        Top = y,
                        Left = 120,
                        Width = 200
                    };
                }
                else if (dataType == "int") // Handle integers
                {
                    if (foreignKey)
                    {
                        control = new ComboBox
                        {
                            Top = y,
                            Left = 120,
                            Width = 200,
                            DropDownStyle = ComboBoxStyle.DropDownList,
                        };

                        //try
                        { // parameters for foreign key diplay members 
                            DataTable foreignEntity = dataSet.Tables[schemaColumnName.Substring(0, schemaColumnName.Length - 2)];
                            if (fieldData.ContainsKey(schemaColumnName))
                            {
                                if (foreignKeySchemaNames == null || !foreignKeySchemaNames.TryGetValue(schemaColumnName, out string foreignKeyRelation))
                                {
                                    foreignKeyRelation = schemaColumnName;
                                }

                                List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
                                foreach (DataRow row in foreignEntity.Rows)
                                {
                                    items.Add(new KeyValuePair<string, string>(row[schemaColumnName].ToString(), row[foreignKeyRelation].ToString()));
                                }

                                ComboBox cbx = (ComboBox)control;
                                cbx.DataSource = items;
                                cbx.ValueMember = "Key";
                                cbx.DisplayMember = "Value";

                                // TODO - fix the selection stuff
                                //fieldData.TryGetValue(foreignKeyRelation, out string key)
                                string selected = fieldData[schemaColumnName].ToString();
                                cbx.SelectedText = selected;
                                control = cbx;
                            }
                        }
                        //catch (Exception ex)
                        //{
                        //    continue;
                        //}
                    }
                    else if (primaryKey)
                    {
                        control = new TextBox
                        {
                            Text = fieldData[schemaColumnName].ToString(),
                            Top = y,
                            Left = 120,
                            Width = 200,
                            Enabled = false
                        };
                    }
                    else
                    {
                        control = new TextBox
                        {
                            Text = fieldData[schemaColumnName].ToString(),
                            Top = y,
                            Left = 120,
                            Width = 200,
                        };
                    }
                }
                else if (dataType == "smallmoney")  // Handle currency
                {
                    control = new TextBox
                    {
                        Text = fieldData[schemaColumnName].ToString(),
                        Top = y,
                        Left = 120,
                        Width = 200
                    };
                }
                else if (dataType == "datetime")  // Handle datetime
                {
                    control = new DateTimePicker
                    {
                        //Value = (DateTime)fieldData[schemaColumnName],
                        Value = newRecord ? DateTime.Today : (DateTime)fieldData[schemaColumnName],
                        Top = y,
                        Left = 120,
                        Width = 200,
                        //ShowUpDown = true,
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "yyyy-MM-dd HH:mm"
                    };
                }
                else  // Handle textboxes for other data types
                {
                    // use max length here
                    control = new TextBox
                    {
                        Text = fieldData[schemaColumnName].ToString(),
                        Top = y,
                        Left = 120,
                        Width = 200
                    };                  
                }

                
                this.Controls.Add(label);
                this.Controls.Add(control);

                controlsDict.Add(schemaColumnName, control);

                y += 30; // Move down for the next field
            }

            // Add Save and Cancel buttons
            AddButtons(y);
        }

        private void AddButtons(int topPosition)
        {
            Button saveButton = new BTN
            {
                Text = "Save",
                Top = topPosition + 10,
                Left = 120,
                Width = 100,
                DialogResult = DialogResult.OK,
            };
            saveButton.Click += SaveButton_Click;

            Button cancelButton = new BTN
            {
                Text = "Cancel",
                Top = topPosition + 10,
                Left = 230,
                Width = 100,
                DialogResult = DialogResult.Cancel,
            };
            cancelButton.Click += CancelButton_Click;

            this.Controls.Add(saveButton);
            this.Controls.Add(cancelButton);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Handle save logic here
            string msg = "";

            //if (controlsDict.TryGetValue("Title", out Control control))
            //{
            //    TextBox textBox = control as TextBox;
            //    string currentValue = textBox?.Text;

            //    MessageBox.Show($"The current value is: {currentValue}");
            //}

            //if (controlsDict.TryGetValue("Description", out Control control1))
            //{
            //    TextBox textBox = control1 as TextBox;
            //    string currentValue = textBox?.Text;

            //    MessageBox.Show($"The current value is: {currentValue}");
            //}

            if (controlsDict.TryGetValue("GenreID", out Control control2))
            {
                ComboBox cbx = control2 as ComboBox;
                string currentValue = cbx.SelectedValue?.ToString();
                

                MessageBox.Show($"The current value is: {currentValue}");
            }



            // dialog result to handle data grid reload
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

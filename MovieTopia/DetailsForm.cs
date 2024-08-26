using MovieTopia.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
        private int numCharCountLabels = 0;
        private Label[] charCountLabels;
        DataSet ds;
        SqlDataAdapter adapter;
        //private ErrorProvider errorProvider = new ErrorProvider();

        /// <summary>
        /// This form automatically builds itself based on the parameters passed into it. See <see cref="DetailsForm"/> for more.
        /// Alot of the automation is based on a schema query to the database to get it's structure and layout, such as the primitive data types (to create the correct control), and whether the field is a foreign key or primary key etc.
        /// </summary>
        /// <param name="schemaName">The schemaName is the table name of the record which you are creating or editing.</param>
        /// <param name="dataSet">The dataSet contains all of the DataTables from the select queries for accessing child entity data. Important that the table or accessing name is the entity name itself eg. 'Movie' or 'MovieSchedule'.</param>
        /// <param name="selectedDataGridViewRow">The selectedDataGridViewRow is the currently selected or highlighted row in the Data grid. Ensure to set the datagrid Multiselect property to false, otherwise errors can occur.</param>
        /// <param name="foreignKeySchemaNames">The foreignKeySchemaNames is a dictionary that maps the foreign key field name to the column in the child entity you wish to see in the drop down. The default values visible are the ID's</param>
        public DetailsForm(string schemaName, DataSet dataSet, DataGridViewRow selectedDataGridViewRow = null, Dictionary<string, string> foreignKeySchemaNames = null)
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
            charCountLabels = new Label[schemaTable.Rows.Count];

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
                Left = padding,
                Width = 200,
                Font = new Font("Arial", 16, FontStyle.Bold),
            };
            this.Controls.Add(formLabel);
            y += 2 * padding;

            foreach (DataRow schemaRow in schemaTable.Rows)
            {
                string schemaColumnName = schemaRow["columnName"].ToString();
                string dataType = schemaRow["dataType"].ToString();
                int maxLength = int.Parse(schemaRow["maxLength"].ToString());
                var defaultValue = schemaRow["defaultValue"];
                bool foreignKey = (bool)schemaRow["isForeign"];
                bool primaryKey = (bool)schemaRow["isPrimary"];

                if (!fieldData.ContainsKey(schemaColumnName)) { continue; }

                Label label = new Label
                {
                    Text = schemaColumnName,
                    Top = y,
                    Left = padding,
                    Width = 160,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                };

                Control control;
                fieldData.TryGetValue(schemaColumnName, out object fieldValue);
                if (dataType == "bit") // Handle booleans
                {
                    bool.TryParse(fieldData[schemaColumnName].ToString(), out bool active);
                    control = new CheckBox
                    {
                        Checked = active,
                        Top = y,
                        Left = label.Width + padding,
                        Width = 200,
                        Font = new Font("Arial", 10, FontStyle.Regular),
                        BackColor = Color.Transparent
                    };
                }
                else if (dataType == "int") // Handle integers
                {
                    if (foreignKey)
                    {
                        control = new ComboBox
                        {
                            Top = y,
                            Left = label.Width + padding,
                            Width = 200,
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Font = new Font("Arial", 10, FontStyle.Regular),
                        };

                        // parameters for foreign key diplay members
                        string childEntity = schemaColumnName.Substring(0, schemaColumnName.Length - 2);
                        if (dataSet == null || !dataSet.Tables.Contains(childEntity))
                        {
                            MessageBox.Show("Improperly configured DataSet. The child entity table could not be found in the DataSet");
                        }
                        else
                        {
                            DataTable foreignEntity = dataSet.Tables[childEntity];
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
                    }
                    else if (primaryKey)
                    {
                        control = new TextBox
                        {
                            Text = fieldData[schemaColumnName].ToString(),
                            Top = y,
                            Left = label.Width + padding,
                            Width = 200,
                            Enabled = false,
                            Font = new Font("Arial", 10, FontStyle.Regular),
                        };
                    }
                    else
                    {
                        control = new NumericUpDown
                        {
                            Minimum = 0,
                            Maximum = 300,
                            Value = int.Parse(fieldData[schemaColumnName].ToString()),
                            Top = y,
                            Left = label.Width + padding,
                            Width = 200,
                            Font = new Font("Arial", 10, FontStyle.Regular),
                        };
                        control.Validating += (sender, e) => {
                            ValidateNumericUpDown((NumericUpDown)sender, e);  // invoke error provider for validation checks
                        };
                    }
                }
                else if (dataType == "smallmoney")  // Handle currency
                {
                    control = new NumericUpDown
                    {
                        Minimum = 0,
                        Maximum = 1000,
                        DecimalPlaces = 2,
                        Value = decimal.Parse(fieldData[schemaColumnName].ToString()),
                        Top = y,
                        Left = label.Width + padding,
                        Width = 200,
                        Font = new Font("Arial", 10, FontStyle.Regular),
                    };
                    control.Validating += (sender, e) => {
                        ValidateNumericUpDown((NumericUpDown)sender, e);  // invoke error provider for validation checks
                    };
                }
                else if (dataType == "datetime")  // Handle datetime
                {
                    control = new DateTimePicker
                    {
                        //Value = (DateTime)fieldData[schemaColumnName],
                        Value = newRecord ? DateTime.Now : (DateTime)fieldData[schemaColumnName],
                        MinDate = DateTime.Now,
                        Top = y,
                        Left = label.Width + padding,
                        Width = 200,
                        //ShowUpDown = true,
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "yyyy-MM-dd HH:mm",
                        Font = new Font("Arial", 10, FontStyle.Regular),
                    };
                    control.Validating += (sender, e) => {
                        ValidateDateTimePicker((DateTimePicker)sender, e);  // invoke error provider for validation checks
                    };
                }
                else  // Handle textboxes for other data types
                {

                    int requiredWidth = ((int)maxLength / 17) == 0 ? 200 : 400;
                    int heightMultiplier = (int)Math.Ceiling((float)maxLength / (float)17);
                    int requiredHeightMultiplier = heightMultiplier > 5 ? 5 : heightMultiplier;
                    bool multiLine = heightMultiplier > 1 ? true : false;
                    bool scrollBars = heightMultiplier > 5 ? true : false;

                    control = new TextBox
                    {
                        Text = fieldData[schemaColumnName].ToString(),
                        Top = y,
                        Left = label.Width + padding,
                        Width = requiredWidth,
                        Multiline = multiLine,
                        ScrollBars = scrollBars ? ScrollBars.Vertical : ScrollBars.None,
                        MaxLength = maxLength,
                        Font = new Font("Arial", 10, FontStyle.Regular),
                    };
                    control.Height *= requiredHeightMultiplier;
                    control.Validating += (sender, e) => {
                        ValidateNotEmpty((TextBox)sender, e);  // invoke error provider for validation checks
                    };
                    

                    // Create and configure the character count Label
                    Label charCountLabel = new Label
                    {
                        //Location = new Point(50, 160), // Set the location
                        AutoSize = true,
                        ForeColor = Color.Gray,
                        Font = new Font("Arial", 10, FontStyle.Regular),
                        BackColor = Color.White,
                        //Top = y,
                        //Left = control.Right + padding,
                        //Width = 400,
                        //Text = $"0 / {maxLength} characters",
                    };

                    this.Controls.Add(charCountLabel);
                    charCountLabels[numCharCountLabels++] = charCountLabel;

                    ((TextBox)control).TextChanged += (sender, e) => UpdateCharCountLabel(sender as TextBox, charCountLabel);
                }
                
                this.Controls.Add(label);
                this.Controls.Add(control);

                controlsDict.Add(schemaColumnName, control);

                y += padding + control.Height; // Move down for the next field
            }

            // Add Save and Cancel buttons
            AddButtons(y);
        }

        /// <summary>
        /// Validates the TextBox value to prevent blank or whitespace entries
        /// </summary>
        /// <param name="textBox">The TextBox control.</param>
        /// <param name="e">The CancelEventsArgs.</param>
        private void ValidateNotEmpty(TextBox textBox, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) || string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetIconPadding(textBox, padding);
                errorProvider1.SetError(textBox, "This field is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            }
        }

        /// <summary>
        /// Validates the NumericUpDown value to prevent invalid number entries
        /// </summary>
        /// <param name="numericUpDown">The NumericUpDown control.</param>
        /// <param name="e">The CancelEventsArgs.</param>
        private void ValidateNumericUpDown(NumericUpDown numericUpDown, CancelEventArgs e)
        {
            if (numericUpDown.Value <= numericUpDown.Minimum)
            {
                // Set the error message
                errorProvider1.SetIconPadding(numericUpDown, padding);
                errorProvider1.SetError(numericUpDown, $"This field requires a valid number (between {numericUpDown.Minimum} and {numericUpDown.Maximum})");
                e.Cancel = true;
            }
            else
            {
                // Clear the error
                errorProvider1.SetError(numericUpDown, "");
            }
        }

        /// <summary>
        /// Validates the DateTimePicker value to prevent invalid dates entries
        /// </summary>
        /// <param name="dateTimePicker">The DateTimePicker control.</param>
        /// <param name="e">The CancelEventsArgs.</param>
        private void ValidateDateTimePicker(DateTimePicker dateTimePicker, CancelEventArgs e)
        {
            if (dateTimePicker.Value == dateTimePicker.MinDate)
            {
                // Set the error message
                errorProvider1.SetIconPadding(dateTimePicker, padding);
                errorProvider1.SetError(dateTimePicker, "Please select a valid date.");
                e.Cancel = true;
            }
            else
            {
                // Clear the error
                errorProvider1.SetError(dateTimePicker, "");
            }
        }

        /// <summary>
        /// Updates the character count label based on the content of the TextBox.
        /// </summary>
        /// <param name="textBox">The TextBox control.</param>
        /// <param name="charCountLabel">The Label to update.</param>
        private void UpdateCharCountLabel(TextBox textBox, Label charCountLabel)
        {
            if (textBox != null)
            {
                int charCount = textBox.Text.Length;
                charCountLabel.Text = $"{charCount} / {textBox.MaxLength}";

                // Adjust the position of the label to the bottom right of the TextBox
                charCountLabel.Location = new Point(textBox.Right - charCountLabel.Width - 5, textBox.Bottom - charCountLabel.Height - 5);
            }
        }

        private void AddButtons(int topPosition)
        {
            Button saveButton = new BTN
            {
                Text = newRecord ? "Create" : "Save",
                Top = topPosition + 10,
                Left = 160 + padding,
                Width = 95,
                DialogResult = DialogResult.OK,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackgroundColor = Color.DodgerBlue,
                BorderColor = Color.MediumBlue,
                BorderSize = 1,
                CausesValidation = true,
            };
            saveButton.Click += SaveButton_Click;

            Button cancelButton = new BTN
            {
                Text = "Cancel",
                Top = topPosition + 10,
                Left = 285,
                Width = 95,
                DialogResult = DialogResult.Cancel,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackgroundColor = Color.Red,
                BorderColor = Color.DarkRed,
                BorderSize = 1,
                CausesValidation = false,
            };
            cancelButton.Click += CancelButton_Click;

            this.Controls.Add(saveButton);
            this.Controls.Add(cancelButton);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

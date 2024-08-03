using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dotenv.net;

namespace MovieTopia
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Load environment variables from .env file
            DotEnv.Load(options: new DotEnvOptions(ignoreExceptions: false, probeForEnv: true, probeLevelsToSearch: 4, encoding: Encoding.ASCII));

            // Build the connection string
            string server = Environment.GetEnvironmentVariable("DB_SERVER");
            string database = Environment.GetEnvironmentVariable("DB_DATABASE");
            string user = Environment.GetEnvironmentVariable("DB_USER");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            string connectionString = $"Server={server};Database={database};Integrated Security=True";

            // Optionally, set the connection string as an environment variable (optional)
            Environment.SetEnvironmentVariable("DATABASE_URL", connectionString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}

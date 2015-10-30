using System;
using System.Data.SqlClient;

namespace Belatrix.Logging.DataBaseOutput
{
    public class DataBaseWritter : IDataBaseWritter
    {
        public void Save(string s)
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Insert into Log Values('" + s + "', " + "0" + ")"))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}

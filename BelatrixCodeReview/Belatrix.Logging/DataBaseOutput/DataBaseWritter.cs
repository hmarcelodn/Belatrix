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

                using (SqlCommand command = new SqlCommand("Insert into Log Values(@message, @type)"))
                {
                    SqlParameter messageParam = new SqlParameter();
                    SqlParameter typeParam = new SqlParameter();

                    messageParam.ParameterName = "@message";
                    messageParam.Value = s;

                    typeParam.ParameterName = "@type";
                    typeParam.Value = 0;

                    command.Parameters.Add(messageParam);
                    command.Parameters.Add(typeParam);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}

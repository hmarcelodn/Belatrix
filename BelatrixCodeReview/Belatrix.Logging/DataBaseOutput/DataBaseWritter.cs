using Belatrix.Logging.Common;
using System;
using System.Data.SqlClient;

namespace Belatrix.Logging.DataBaseOutput
{
    public class DataBaseWritter : IDataBaseWritter
    {
        public void Save(Message message)
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Insert into Logging Values(@message, @type)", connection))
                {
                    SqlParameter messageParam = new SqlParameter();
                    SqlParameter typeParam = new SqlParameter();

                    messageParam.ParameterName = "@message";
                    messageParam.Value = message.MessageText;

                    typeParam.ParameterName = "@type";
                    typeParam.Value = message.MessageType;

                    command.Parameters.Add(messageParam);
                    command.Parameters.Add(typeParam);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}

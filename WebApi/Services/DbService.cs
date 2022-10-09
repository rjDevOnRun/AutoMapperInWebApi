using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApi.Exceptions;

namespace WebApi.Services
{
    public class DbService : IDbService
    {
        private SqlConnection sqlConnection;
        private string connectionString = "your-connection-string-here";

        public DbService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public async Task<List<T>> GetData<T>(string QUERY) where T : class
        {
            using (sqlConnection)
            {
                sqlConnection.Open();

                var command = new SqlCommand(QUERY, sqlConnection);
                DataTable dt = new DataTable();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                dt.Load(reader);
                if (dt == null)
                {
                    throw new DbNoDataException("No Data collected!");
                }

                List<T> data = new List<T>();

                foreach (DataRow dr in dt.Rows)
                {
                    CreateObjectData(data, dr);
                    throw new DtoException($"Could not create Dto of type {typeof(T).Name}");
                }
                return data;
            }
        }

        private static void CreateObjectData<T>(List<T> data, DataRow dr) where T : class
        {
            Type objTypeInfo = typeof(T);
            T objInstance = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo objProp in objTypeInfo.GetProperties())
                {
                    if (objProp.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName] is DBNull)
                        {
                            objProp.SetValue(objInstance, null, null);
                        }
                        else
                        {
                            objProp.SetValue(objInstance, dr[column.ColumnName], null);
                        }
                    }
                    else
                        continue;
                }
            }

            data.Add(objInstance);
        }
    }
}
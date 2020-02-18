using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Reflection;

namespace Automation_TrainingM10B.Base_Files
{
    class QueryUtils
    {
        OracleConnection dbConnection;
        OracleCommand dbCommand;
        OracleDataReader dbReader;

        public QueryUtils(OracleConnection pdbConnection)
        {
            dbConnection = pdbConnection;
        }

        public T QuerySingleRow<T>(string Query)
        {
            T output = (T)Activator.CreateInstance(typeof(T));
            Type outputType = output.GetType();

            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = Query;

            using (dbReader = dbCommand.ExecuteReader())
            {
                if (!dbReader.HasRows)
                {
                    return output;
                }
                dbReader.Read();

                for (int i = 0; i < dbReader.FieldCount; i++)
                {
                    string strColumnName = dbReader.GetName(i);
                    object objColumnData = dbReader.GetValue(i);

                    PropertyInfo attribute = outputType.GetProperty(strColumnName);
                    List<PropertyInfo> attributes = outputType.GetProperties().ToList();

                    if (attribute != null)
                    {
                        if (objColumnData.GetType() == typeof(DBNull))
                        {
                            objColumnData = null;
                        }
                        SetAttribute(attribute, output, objColumnData);
                    }
                }
            }

            return output;
        }

        public void SetAttribute(PropertyInfo convertToAttribute, object convertToObject, object convertFromValue)
        {
            convertToAttribute.SetValue(convertToObject, convertFromValue);
        }
    }
}

using NUnit.Framework;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_TrainingM10B.Base_Files;
using Automation_TrainingM10B.Data_Models;

namespace Automation_TrainingM10B.Test_Cases
{
    class SQL_Connection_Tests:BaseTest
    {
        [Test]
        public void Database_Test()
        {
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT LOYALTYIDNUMBER FROM BP_ESS.LW_VIRTUALCARD";

            List<string> lstLoyaltyId = new List<string>();
            using(dbReader = dbCommand.ExecuteReader())
            {
                while(dbReader.Read())
                {
                    lstLoyaltyId.Add(dbReader.GetString(0));
                }
            }
        }

        [Test]
        public void Query_Test()
        {
            string query = @"SELECT VC.LOYALTYIDNUMBER,LM.FIRSTNAME,LM.LASTNAME
                            FROM BP_ESS.LW_VIRTUALCARD VC
                            JOIN BP_ESS.LW_LOYALTYMEMBER LM ON VC.IPCODE = LM.IPCODE
                            WHERE VC.LOYALTYIDNUMBER = 'APA851'";
            Member_Model member = QuerySingleRow<Member_Model>(query);
            member.GetDetails();
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

                    if(attribute != null)
                    {
                        if(objColumnData.GetType() == typeof(DBNull))
                        {
                            objColumnData = null;
                        }
                        SetAttribute(attribute, output, objColumnData);
                    }
                }
            }

            return output;
        }

        public void SetAttribute(PropertyInfo convertToAttribute, object convertToObject,object convertFromValue)
        {
            convertToAttribute.SetValue(convertToObject, convertFromValue);
        }
    }
}

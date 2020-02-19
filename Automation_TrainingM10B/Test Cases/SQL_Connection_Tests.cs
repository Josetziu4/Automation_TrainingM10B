using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationTrainingM10B.Base_Files;
using Automation_TrainingM10B.Data_Models;
using Automation_TrainingM10B.Base_Files;

namespace Automation_TrainingM10B.Test_Cases
{
    class SQL_Connection_Tests : BaseTest
    {
        QueryUtils database;
        [Test]
        public void Database_Test()
        {
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT LOYALTYIDNUMBER FROM BP_TCP.LW_VIRTUALCARD";

            //ALMACENAR DATOS
            List<string> lstLoyaltyId = new List<string>();

            using (dbReader = dbCommand.ExecuteReader())
            {
                while (dbReader.Read())
                {
                    lstLoyaltyId.Add(dbReader.GetString(0));
                }
            }
        }
        [Test]
        public void Query_Test()
        {
            database = new QueryUtils(dbConnection);
            string query = @"SELECT * FROM BP_TCP.LW_VIRTUALCARD";
            Member_Mode member = database.QuerySingleRow<Member_Mode>(query);
            member.GetDetails();
        }

        


    }
}

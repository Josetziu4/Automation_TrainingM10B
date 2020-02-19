using AutomationTrainingM10B.Base_Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Automation_TrainingM10B.Data_Models;
using Automation_TrainingM10B.Base_Files;



namespace Automation_TrainingM10B.Test_Cases
{
    class SQL_Connection_Test : BaseTest
    {
        QueryUtils database;
        [Test]
        public void Database_Test()
        {
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT NAME FROM BP_SRP.V_LW_REWARDSDEF";

            exTestStep = exTestCase.CreateNode("DB Connection", "Connection Test");
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
            string query = @"SELECT VC.LOYALTYIDNUMBER,LM.FIRSTNAME,LM.LASTNAME
                            FROM BP_SRP.LW_VIRTUALCARD VC
                            JOIN BP_SRP.LW_LOYALTYMEMBER LM ON VC.IPCODE = LM.IPCODE
                            WHERE VC.LOYALTYIDNUMBER = '20145877458'";
            Member_Model member = database.QuerySingleRow<Member_Model>(query);
            member.GetDetails();
        }       

    }
}

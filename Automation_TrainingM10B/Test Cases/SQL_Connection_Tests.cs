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
        QueryUtils database;
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
            database = new QueryUtils(dbConnection);
            string query = @"SELECT VC.LOYALTYIDNUMBER,LM.FIRSTNAME,LM.LASTNAME
                            FROM BP_ESS.LW_VIRTUALCARD VC
                            JOIN BP_ESS.LW_LOYALTYMEMBER LM ON VC.IPCODE = LM.IPCODE
                            WHERE VC.LOYALTYIDNUMBER = 'APA851'";
            Member_Model member = database.QuerySingleRow<Member_Model>(query);
            member.GetDetails();

            query = @"SELECT VC.LOYALTYIDNUMBER,LM.FIRSTNAME,LM.LASTNAME
                            FROM BP_ESS.LW_VIRTUALCARD VC
                            JOIN BP_ESS.LW_LOYALTYMEMBER LM ON VC.IPCODE = LM.IPCODE";
            List<Member_Model> members = database.Query<Member_Model>(query).ToList();
            foreach(var item in members)
            {
                item.GetDetails();
            }
        }
    }
}

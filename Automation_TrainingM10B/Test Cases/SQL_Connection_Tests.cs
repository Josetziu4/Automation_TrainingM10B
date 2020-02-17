using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTrainingM10B.Base_Files;
using Automation_TrainingM10B.Data_Models;
using System.Reflection;
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
            dbCommand.CommandText = "select loyaltyidnumber from bp_srp.lw_virtualcard;";

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
            string query = @"select loyaltyidnumber,
                            firstname,lastname 
                            from bp_srp.lw_virtualcard;";//el @ antes del string hace que no se pierda la cadena de texto cuando se le da enter.
            Member_Model member = database.QuerySingleRow<Member_Model>(query);
            member.GetDetails();
        }


    }
}

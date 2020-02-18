﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Automation_TrainingM10B.Base_Files;
using System.Reflection;
using Automation_TrainingM10B.Data_Models;

namespace Automation_TrainingM10B.Test_Cases
{
    class SQL_Connection_Tests : BaseTest
    {
        QueryUtils database;

        [Test]
        public void Database_Test()
        {
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT LOYALTYIDNUMBER " +
                                    "FROM BP_EXP.LW_VIRTUALCARD " +
                                    "WHERE 1=1 AND ROWNUM < 6";

            List<string> lstLoyaltyId = new List<string>();
            using (dbReader = dbCommand.ExecuteReader())
            {
                while(dbReader.Read())
                {
                    lstLoyaltyId.Add(dbReader.GetString(0)); //el cero se refiere a la primera columna
                }
            }
        }

        [Test]
        public void Query_Test()
        {
            database = new QueryUtils(dbConnection);
            string query = @"SELECT LOYALTYIDNUMBER
                             FROM BP_EXP.LW_VIRTUALCARD
                             WHERE 1=1 AND ROWNUM < 6";
            Member_Model member = database.QuerySingleRow<Member_Model>(query);
            member.GetDetails();
        }
    }
}

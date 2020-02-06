using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationTrainingM10B.Base_Files;

namespace Automation_TrainingM10B.Test_Cases
{
    class SQL_Connection_Tests : BaseTest
    {
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

    }
}

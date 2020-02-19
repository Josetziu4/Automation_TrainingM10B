using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTrainingM10B.Base_Files;

namespace Automation_TrainingM10B.Data_Models
{
    class Member_Mode
    {
        public string LOYALTYIDNUMBER { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }

        public void GetDetails()
        {
            Console.WriteLine($"LoyaltyIdNumber: {LOYALTYIDNUMBER}" +
                $"First Name: {FIRSTNAME}" +
                $"Last Name: {LASTNAME}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Data_Models
{
    class Member_Model
    {
        public string LOYALTYIDNUMBER { get; set; }

        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }

        public void GetDetails()
        {
            Console.WriteLine($"LoyaltyIdNumeber: {LOYALTYIDNUMBER}" +
                $"First Name : {FIRSTNAME}" +
                $"Last Name : {LASTNAME}");
        }

    }
}

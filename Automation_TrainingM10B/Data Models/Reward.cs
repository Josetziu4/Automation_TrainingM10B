using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Data_Models
{
    class Reward
    {
        public int MemberId { get; set; }
        public int RewardId { get; set; }
        public string RewardName { get; set; }
        public double RewardPoints { get; set; }
        public DateTime RewardStartDate { get; set; }
        public DateTime RewardEndDate { get; set; }
        /*
         * Id
         * Name
         * Points
         * StartDate
         * EndDate
         */
         public Reward()
        {
            RewardId = 0;
        }
    }
}

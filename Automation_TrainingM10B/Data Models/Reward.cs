using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_TrainingM10B.Data_Models
{
    class Reward
    {
        public int MemberID { get; set; }
        public int RewardId { get; set; }
        public string RewardName { get; set; }
        public double RewardPoints { get; set; }
        public DateTime RewardStarDate { get; set; }
        public DateTime RewardEndDate { get; set; }

        public Reward()
        {
            MemberID = 0;
        }
    }
}

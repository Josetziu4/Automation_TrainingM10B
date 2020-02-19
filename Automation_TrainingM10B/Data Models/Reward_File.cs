using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AutomationTrainingM10B.Reporting;
using Automation_TrainingM10B.Base_Files;

namespace Automation_TrainingM10B.Data_Models
{
    class Reward_File: ReportManager
    {
        public string FileName { get; set; }
        public string Header { get; set; }

        public List<Reward> Reward { get; set; }

        public Reward_File()
        {
            FileName = $"AUTO_REWARD_{DateTime.Now.ToString("yyyMMdd")}.TXT";
            Header = "MemberID|RwardId|RewardName|RewardDate|ExpirationDate|RewardPoints";
            Reward = new List<Reward>();
        }

        public void fnCreateFile()
        {
            StreamWriter file = File.CreateText(fnGetDataFeedsPath()+FileName);
            file.WriteLine(Header);
            foreach (Reward reward in Reward)
            {
                file.WriteLine($"{reward.RewardId}|{reward.MemberID}|{reward.RewardName}|{reward.RewardStarDate}|{reward.RewardPoints}");
            }
            file.Close();
        }

    }
}

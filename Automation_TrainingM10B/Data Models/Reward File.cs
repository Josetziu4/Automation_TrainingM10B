﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTrainingM10B.Reporting;

namespace Automation_TrainingM10B.Data_Models
{
    class Reward_File:ReportManager
    {
        public string FileName { get; set; }
        public string Header { get; set; }
        public List<Reward> Rewards { get; set; }
        
        public Reward_File()
        {
            FileName = $"AUTO_REWARD_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.TXT";
            Header = "MemberId|RewardId|RewardName|RewardDate|ExpirationDate";
            Rewards = new List<Reward>();
        }

        public void fnCreateFile()
        {
            StreamWriter file = File.CreateText(fnGetDataFeedsPath() + FileName);
            file.WriteLine(Header);

            foreach(Reward reward in Rewards)
            {
                file.WriteLine($"{reward.MemberId}|{reward.RewardId}|{reward.RewardName}|{reward.RewardStartDate}|{reward.RewardEndDate}");
            }
            file.Close();
        }
        /*
         * Header
         * FileName
         * Body (MemberId|RewardId|RewardName|RewardDate|ExpirationDate)
         */
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_TrainingM10B.Data_Models;
using NUnit.Framework;

namespace Automation_TrainingM10B.Test_Cases
{
    class Data_Model_Tests
    {
        [Test]
        public void RewardFile_Test()
        {
            Reward_File rewardFile = new Reward_File(); //CREATE REWARD FILE

            //CREATE A NEW RECORD WITH THE FOLLOWING DATA
            Reward reward1 = new Reward();
            reward1.MemberId = 1;
            reward1.RewardName = "TestReward1";
            reward1.RewardPoints = 20;
            reward1.RewardStartDate = DateTime.Now;
            reward1.RewardEndDate = DateTime.Now;

            //ADD RECORD TO FILE
            rewardFile.Rewards.Add(reward1);

            //WRITE FILE
            rewardFile.fnCreateFile();
        }
    }
}

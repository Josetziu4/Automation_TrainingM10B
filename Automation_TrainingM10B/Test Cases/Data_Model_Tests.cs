using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_TrainingM10B.Data_Models;
using Automation_TrainingM10B.Base_Files;
using NUnit.Framework;
using Renci.SshNet.Sftp;
using System.IO;
using Automation_TrainingM10B.Reporting;

namespace Automation_TrainingM10B.Test_Cases
{
    class Data_Model_Tests:BaseTest
    {
        ReportManager mngr = new ReportManager();
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

            Console.WriteLine(sftpConnection.WorkingDirectory);

            sftpConnection.ChangeDirectory("/opt/app/oracle/flatfiles/ess/lw/qa_a/in/auto");

            Console.WriteLine(sftpConnection.WorkingDirectory);

            List<SftpFile> sftpFiles = sftpConnection.ListDirectory("/opt/app/oracle/flatfiles/ess/lw/qa_a/in/completed").ToList();
            
            foreach(SftpFile file in sftpFiles )
            {
                Console.WriteLine(file.Name);
            }

            //sftpConnection.UploadFile(uploadStream,rewardFile.FileName,true);

            //ADD RECORD TO FILE
            rewardFile.Rewards.Add(reward1);

            //WRITE FILE
            rewardFile.fnCreateFile();

            //var uploadStream = File.OpenRead(manager.fnGetDataFeedsPath() + "ESS_TRANSACTION_20200204_144542.txt.dec");
            //sftpConnection.UploadFile(uploadStream, "ESS_TRANSACTION_20200204_144542.txt.dec", true);

            sftpConnection.ChangeDirectory("/opt/app/oracle/flatfiles/ess/lw/qa_a/in/completed");

            Stream downloadedFile = File.OpenWrite(manager.fnGetDataFeedsPath() + "file.txt");
            sftpConnection.DownloadFile("/opt/app/oracle/flatfiles/ess/lw/qa_a/in/completed/ESS_TRANSACTION_20200211_113040.txt.dec", downloadedFile);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_TrainingM10B.Data_Models;
using Automation_TrainingM10B.Base_Files;
using NUnit.Framework;
using AutomationTrainingM10B.Base_Files;
using Renci.SshNet.Sftp;
using System.IO;
using AutomationTrainingM10B.Reporting;

namespace Automation_TrainingM10B.Test_Cases
{
    class Data_Model_Test : BaseTest
    {
        ReportManager mng = new ReportManager();
        [Test]
        public void RewardFile()
        {
            //CREATE REWARD FILE
            Reward_File rewardFile = new Reward_File();
            //CREATE A NEW RECORD
            Reward reward1 = new Reward();
            reward1.MemberID = 1;
            reward1.RewardName = "TestReward1";
            reward1.RewardPoints = 30;
            reward1.RewardStarDate = DateTime.Now;
            reward1.RewardEndDate = DateTime.Now;

            Console.WriteLine(sftpConnection.WorkingDirectory);

            sftpConnection.ChangeDirectory("/opt/app/oracle/flatfiles/srp/lw/qa_a/in/auto");

            Console.WriteLine(sftpConnection.WorkingDirectory);

            List<SftpFile> sftpFiles = sftpConnection.ListDirectory("/opt/app/oracle/flatfiles/srp/lw/qa_a/in/auto").ToList();

            foreach (SftpFile file in sftpFiles)
            {
               // Console.WriteLine(file.FullName);
                Console.WriteLine(file.Name);

            }
           
            //sftpConnection.UploadFile();

            //ADD RECORD TO FILE
            rewardFile.Reward.Add(reward1);

            //WRITE FILE
            rewardFile.fnCreateFile();

            //UPLOAD FILE | Folder: DataFeeds in proyect
            var uploadStreem = File.OpenRead(manager.fnGetDataFeedsPath() + "SRP_Engagement_20200111_000001_Zappar.csv");
            sftpConnection.UploadFile(uploadStreem, "SRP_Engagement_20200111_000001_Zappar.csv", true);

            ////DOWNLOAD FILE
            //sftpConnection.ChangeDirectory("/opt/app/oracle/flatfiles/srp/lw/qa_a/in/auto");
            ////FILE NAME AND EXTENTION: file.csv
            //Stream downloadFile = File.OpenWrite(manager.fnGetDataFeedsPath() + "file.csv");
            ////FILE NAME TO DOWNLOAD FROM SFTP
            //sftpConnection.DownloadFile("/opt/app/oracle/flatfiles/srp/lw/qa_a/in/auto/SRP_Engagement_20200111_000004_Zappar.csv", downloadFile);




        }
    }
}

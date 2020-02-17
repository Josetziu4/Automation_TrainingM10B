using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_TrainingM10B.Data_Models;
using AutomationTrainingM10B.Base_Files;
using AutomationTrainingM10B.Reporting;
using NUnit.Framework;
using Renci.SshNet.Sftp;

namespace Automation_TrainingM10B.Test_Cases
{
    class Data_Model_Tests : BaseTest
    {
        [Test]
        public void RewardFile_Test()
        {
            ReportManager mngr = new ReportManager();

            Reward_File rewardFile = new Reward_File();//Create reward file


            //Create a new records with following data
            Reward reward1 = new Reward();
            reward1.MemberId = 1;
            reward1.RewardName = "TestReward1";
            reward1.RewardPoints = 20;
            reward1.RewardStartDate = DateTime.Now;
            reward1.RewardEndDate = DateTime.Now;

            Console.WriteLine(sftpConnection.WorkingDirectory);

            sftpConnection.ChangeDirectory("/opt/app/flatfiles/srp/lw/qa_a/in/auto");//Esta linea hace que se cambie al path donde va ir el file.
            Console.WriteLine(sftpConnection.WorkingDirectory);

            List<SftpFile> sftpFiles = sftpConnection.ListDirectory("/opt/app/flatfiles/srp/lw/qa_a/in/auto").ToList();//hace una lista de los files que hayan en el path
            foreach (SftpFile files in sftpFiles)
            {
                //Console.WriteLine(files.FullName);//Regresa todo el path m'as el nombre del archivo
                Console.WriteLine(files.Name);//regresa solo el nombre del archivo
            }

            //Add record to file
            rewardFile.Rewards.Add(reward1);

            //Write file
            rewardFile.fnCreatFile();

            //Upload File
            var uploadStream = File.OpenRead(manager.fnGetDataFeedsPath() + rewardFile.FileName);
            //sftpConnection.UploadFile(uploadStream, rewardFile.FileName, true);

            //Download file
            sftpConnection.ChangeDirectory("/opt/app/flatfiles/srp/lw/qa_a/in/completed");


            Stream downloadedFile = File.OpenWrite(manager.fnGetDataFeedsPath() + "File.txt");
            sftpConnection.DownloadFile("/opt/app/flatfiles/srp/lw/qa_a/in/completed/NOMBRE_DEL_FILE_A_DESCARGAR.txt.dec", downloadedFile);
        }
    }
}

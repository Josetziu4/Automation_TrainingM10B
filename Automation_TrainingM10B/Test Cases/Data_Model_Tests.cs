using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_TrainingM10B.Data_Models;
using NUnit.Framework;
using Automation_TrainingM10B.Base_Files;
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
            Reward_File rewardFile = new Reward_File();

            //CREATE A NEW RECORD WITH THE FOLLOWING DATA
            Reward reward1 = new Reward();
            reward1.MemberId = 1;
            reward1.RewardName = "TestReward1";
            reward1.RewardPoints = 20;
            reward1.RewardStarDate = DateTime.Now;
            reward1.RewardEndDate = DateTime.Now;

            Console.WriteLine(sftpConnection.WorkingDirectory);

            //sftpConnection.ChangeDirectory("/opt/app/oracle/flatfiles/exp/lw/qa_a/in/auto");
            sftpConnection.ChangeDirectory("/opt/app/oracle/flatfiles/exp/lw/qa_a/in/completed");

            Console.WriteLine(sftpConnection.WorkingDirectory);

            //Obtener archivos que estan dentro del sftp
            List<SftpFile> sftpFiles = sftpConnection.ListDirectory("/opt/app/oracle/flatfiles/exp/lw/qa_a/in/completed").ToList();
            
            foreach(SftpFile file in sftpFiles)
            {
                //Console.WriteLine(file.FullName); Devuelve el directorio mas el nombre del file
                Console.WriteLine(file.Name);

            }



            //Como subir un archivo
            //var uploadStream = File.OpenRead(manager.fnGetDataFeedsPath());
            //sftpConnection.UploadFile(uploadStream, "File Name", true); //el true es para sobre escritura

            //Como descargar archivo
            sftpConnection.ChangeDirectory("/opt/app/oracle/flatfiles/exp/lw/qa_a/in/completed");

            Stream downloadedFile = File.OpenWrite(manager.fnGetDataFeedsPath() + "file.txt");
            sftpConnection.DownloadFile("/opt/app/oracle/flatfiles/exp/lw/qa_a/in/completed/filename", downloadedFile);

            //ADD RECORD TO FILE
            rewardFile.Rewards.Add(reward1);

            //WRITE FILE
            rewardFile.fnCreateFile();
        }
        



    }
}

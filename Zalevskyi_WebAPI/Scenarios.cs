using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Zalevskyi_WebAPI
{
    public class Authentication
    {
        public static string typeOfToken = "Bearer";
        public static string token = "sl.BIx5-K9vdTHpRGqwr5pNvZ9YRn50dCPkOtwDJmwc7gjrM5z045Ri6shxEuA4UfEdi_dSEqazuvx7xgNDCJXOauRgM8B24LAuHVLr5vqtc5WZEpmRafhldJllSQkWbVaYfonKM58wfpc2";
    }

    public class FileProperties
    {
        public static string localPath = "MyGif.gif";
        public static string cloudPath = "/MyGifs/MyGif.gif";
        public static string cloudFolder = "/MyGifs";
        public static string cloudFilename = "MyGif.gif";
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private bool CheckIfFileInFolder()
        {
            bool isFileInFolder = false;
            string folderList = new ListFilesRequestSender().SendRequest().Content;
            string nameProperty = " \"name\": " + "\"" + FileProperties.cloudFilename + "\"";

            foreach (var property in folderList.Split(","))
            {
                if (string.Equals(property, nameProperty))
                {
                    isFileInFolder = true;
                    break;
                }
            }
            return isFileInFolder;
        }

        private bool CheckMetadata(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
                return false;

            bool isMetadataCorrect = true;


            string metadata = response.Content;
            string nameProperty = " \"name\": " + "\"" + FileProperties.cloudFilename + "\"";
            string pathProperty = " \"path_display\": " + "\"" + FileProperties.cloudPath + "\"";


            foreach (var property in metadata.Split(","))
            {
                if (property.Contains("\"name\""))
                    if (property != nameProperty)
                        isMetadataCorrect = false;

                if (property.Contains("\"path_display\""))
                    if (property != pathProperty)
                        isMetadataCorrect = false;
            }
            return isMetadataCorrect;
        } 

        [Test, Order(1)]
        public void UploadFileScenario()
        {
            new UploadFileRequestSender().SendRequest();
            Assert.IsTrue(CheckIfFileInFolder());
        }

        [Test, Order(2)]
        public void GetFileMetadataScenario()
        {
            Assert.IsTrue(CheckMetadata(new GetFileMetadataRequestSender().SendRequest()));
        }

        [Test, Order(3)]
        public void DeleteFileScenario()
        {
            Assert.AreEqual(HttpStatusCode.OK, new DeleteFileRequestSender().SendRequest().StatusCode);
            Assert.IsFalse(CheckIfFileInFolder());
        }
    }
}
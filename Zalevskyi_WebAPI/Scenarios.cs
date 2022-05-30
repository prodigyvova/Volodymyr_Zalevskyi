using NUnit.Framework;
using System.Net;

namespace Zalevskyi_WebAPI
{
    public class Authentication
    {
        public static string typeOfToken = "Bearer";
        public static string token = "sl.BIk9KyrfeK4g8BeVmEi9PNeVDl1NDXk5UKRuRc9wgEKrImD4N558cGegn-B-upLLVvPCVg9cc7PARSMdOpnmUUzYRDZaj4gevhdGMvVgM3mTI5HexGFKvKGyE_WBxx5ip1ptwwBN-O5L";
    }

    public class FileProperties
    {
        public static string localPath = "MyGif.gif";
        public static string cloudPath = "/MyGifs/MyGif.gif";
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Order(1)]
        public void UploadFileScenario()
        {
            Assert.AreEqual(HttpStatusCode.OK, new UploadFileRequestSender().SendRequest().StatusCode);
        }

        [Test, Order(2)]
        public void GetFileMetadataScenario()
        {
            Assert.AreEqual(HttpStatusCode.OK, new GetFileMetadataRequestSender().SendRequest().StatusCode);
        }

        [Test, Order(3)]
        public void DeleteFileScenario()
        {
            Assert.AreEqual(HttpStatusCode.OK, new DeleteFileRequestSender().SendRequest().StatusCode);
        }
    }
}
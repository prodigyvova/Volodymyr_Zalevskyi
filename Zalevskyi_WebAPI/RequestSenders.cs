using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace Zalevskyi_WebAPI
{
    public class RequestURLs
    {
        public static readonly string uploadFileURL = "https://content.dropboxapi.com/2/files/upload";
        public static readonly string getFileMetadataURL = "https://api.dropboxapi.com/2/sharing/get_file_metadata";
        public static readonly string deleteFileURL = "https://api.dropboxapi.com/2/files/delete_v2";
        public static readonly string listFilesURL = "https://api.dropboxapi.com/2/files/list_folder";
    }

    public abstract class RequestSender
    {
        public abstract string requestURL { get; }
        protected abstract Request FactoryMethod();

        public virtual IRestResponse SendRequest()
        {
            return new RestClient(requestURL).Post(FactoryMethod().GetRestRequest);
        }
    }

    public class UploadFileRequestSender : RequestSender
    {
        public override string requestURL { get { return RequestURLs.uploadFileURL; } }

        protected override Request FactoryMethod()
        {
            return new UploadFileRequest();
        }

    }

    public class GetFileMetadataRequestSender : RequestSender
    {
        public override string requestURL { get { return RequestURLs.getFileMetadataURL; } }

        protected override Request FactoryMethod()
        {
            return new GetFileMetadataRequest();
        }

    }

    public class DeleteFileRequestSender : RequestSender
    {
        public override string requestURL { get { return RequestURLs.deleteFileURL; } }

        protected override Request FactoryMethod()
        {
            return new DeleteFileRequest();
        }

    }

    public class ListFilesRequestSender : RequestSender
    {
        public override string requestURL { get { return RequestURLs.listFilesURL; } }

        protected override Request FactoryMethod()
        {
            return new ListFilesRequest();
        }

    }


}

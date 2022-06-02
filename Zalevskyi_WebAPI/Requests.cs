using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RestSharp;

namespace Zalevskyi_WebAPI
{
    public abstract class Request
    {
        protected RestRequest restRequest = new RestRequest();

        public Request()
        {
            SetHead();
            SetBody();
        }

        protected void SetAuthentication()
        {
            restRequest.AddHeader("Authorization", Authentication.typeOfToken + " " + Authentication.token);
        }

        protected abstract void SetHead();

        protected abstract void SetBody();

        public RestRequest GetRestRequest { get {return restRequest;} }
    }

    public class UploadFileRequest : Request
    {
        public UploadFileRequest() : base()
        {
            return;
        }
        

        protected override void SetHead()
        {
            SetAuthentication();
            restRequest.AddHeader("Dropbox-API-Arg", "{\"path\":\"" + FileProperties.cloudPath + "\",\"mode\":\"add\"}");
            restRequest.AddHeader("Content-Type", "application/octet-stream");
        }

        protected override void SetBody()
        {
            restRequest.AddHeader("Content-Length", new FileInfo(FileProperties.localPath).Length.ToString());
            restRequest.AddParameter("file", File.ReadAllBytes(FileProperties.localPath), ParameterType.RequestBody);
        }
    }

    public class GetFileMetadataRequest : Request
    {
        public GetFileMetadataRequest() : base()
        {
            return;
        }

        protected override void SetHead()
        {
            SetAuthentication();
        }

        protected override void SetBody()
        {
            restRequest.AddJsonBody(new {file = FileProperties.cloudPath} );
        }
    }

    public class DeleteFileRequest : Request
    {
        public DeleteFileRequest() : base()
        {
            return;
        }

        protected override void SetHead()
        {
            SetAuthentication();
        }

        protected override void SetBody()
        {
            restRequest.AddJsonBody(new { path = FileProperties.cloudPath });
        }
    }

    public class ListFilesRequest : Request
    {
        public ListFilesRequest() : base()
        {
            return;
        }

        protected override void SetHead()
        {
            SetAuthentication();
        }

        protected override void SetBody()
        {
            restRequest.AddJsonBody(new { path = FileProperties.cloudFolder });
        }
    }




}


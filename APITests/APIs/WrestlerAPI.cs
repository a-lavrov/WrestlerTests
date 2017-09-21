using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrestlerTests.Models;
using Wrestler.Utils;
using WrestlerTests.Utils;

namespace WrestlerTests.APITests.APIs
{
    public class WrestlerAPI : BaseAPI
    {
        public string Create(WrestlerModel model)
        {
            var request = new RestRequest()
            {
                Method = Method.POST,
                Resource = "/wrestler/create.php",
                RequestFormat = DataFormat.Json
            };

            request.AddBody(model);

            var responseModel = Execute<WrestlerModel>(request);
            return responseModel.id;
        }


        public WrestlerModel Fetch(string id)
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = "/wrestler/fetch.php?id=" + id
            };

            var model = Execute<WrestlerModel>(request);

            return model;
        }


        public WrestlerModel Read(string id)
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = "/wrestler/read.php?id=" + id
            };

            var model = Execute<WrestlerModel>(request);

            return model;
        }


        public WrestlerModel Delete(string id)
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = "/wrestler/delete.php?id=" + id
            };

            return Execute<WrestlerModel>(request);
        }


        public void Delete(List<string> ids)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                Delete(ids[i]);
            }
        }


        public WrestlerModel Update(WrestlerModel model)
        {
            var request = new RestRequest()
            {
                Method = Method.PUT,
                Resource = "/wrestler/update.php",
                RequestFormat = DataFormat.Json

            };

            request.AddBody(model);

            return Execute<WrestlerModel>(request);
        }


        public void Search(int start, int count, IEnumerable<string> filters, string order, string search)
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = $"/wrestler/search.php?{start}&{count}&{filters}&{order}&{search}"
            };



        }
        

        public AttachmentModel UploadAttachment(string id, string fullPathWithFileName)
        {
            var request = new RestRequest()
            {
                Method = Method.POST,
                Resource = $"/attach/upload.php",
                RequestFormat = DataFormat.Json
            };
            
            request.AddFile("file", fullPathWithFileName, "text/plain");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("id_wrestler", id, ParameterType.RequestBody);
            
            return Execute<AttachmentModel>(request);
        }

        public AttachmentModel UploadPhoto(string id, string fullPathWithFileName)
        {
            var request = new RestRequest()
            {
                Method = Method.POST,
                Resource = $"/photo/upload.php",
                RequestFormat = DataFormat.Json
            };

            request.AddFile("file", fullPathWithFileName, "image/jpeg");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("id_wrestler", id, ParameterType.RequestBody);

            return Execute<AttachmentModel>(request);
        }

        public AttachmentModel DeleteAttachment(string id)
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = $"/attach/delete.php?id=" + id
            };

            return Execute<AttachmentModel>(request);

        }


    }
}

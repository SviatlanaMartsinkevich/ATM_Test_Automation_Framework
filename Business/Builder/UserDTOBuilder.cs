using Business.Models;
using log4net;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;


namespace Business.Builder
{
    public class UserDTOBuilder 
    {
        private List<UserDTO> users;
        private RestRequest restRequest;
        private RestResponse restResponse;

        public ILog Log
        {
            get { return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); }
        }

        public List<UserDTO> GetUsers()
        {
            return users;
        }
        public RestRequest GetRestRequest()
        {
            return restRequest;
        }

        public RestResponse GetRestResponse()
        {
            return restResponse;
        }
      
        public class Builder
        {
            private UserDTOBuilder userDTOBuilder;
          
            public Builder()
            {
                userDTOBuilder = new UserDTOBuilder();
            }

            public Builder CreateGetRequest(string endpoint)
            {
                userDTOBuilder.Log.Info("Create GET Request");
                userDTOBuilder.restRequest = new RestRequest(endpoint, Method.Get);
                userDTOBuilder.restRequest.AddHeader("Accept", "application/json");
                userDTOBuilder.restRequest.RequestFormat = DataFormat.Json;
                return this;
            }

            public Builder CreatePostRequest(string endpoint, UserDTO userDTO)
            {
                userDTOBuilder.Log.Info("Create POST Request");
                userDTOBuilder.restRequest = new RestRequest(endpoint, Method.Post);
                userDTOBuilder.restRequest.AddHeader("Accept", "application/json");
                userDTOBuilder.restRequest.AddBody(userDTO);
                userDTOBuilder.restRequest.RequestFormat = DataFormat.Json;
                return this;
            }

            public Builder CreateResponse(RestClient client)
            {
                userDTOBuilder.Log.Info("Create Response");
                userDTOBuilder.restResponse = client.Execute(userDTOBuilder.restRequest);
                return this;
            }

            public Builder GetUsersList()
            {
                userDTOBuilder.Log.Info("Get Users list");
                userDTOBuilder.users = JsonConvert.DeserializeObject<List<UserDTO>>(userDTOBuilder.restResponse.Content);
                return this;
            }

             public UserDTOBuilder Build()
             {
                return userDTOBuilder;
             }
        }
    }
}



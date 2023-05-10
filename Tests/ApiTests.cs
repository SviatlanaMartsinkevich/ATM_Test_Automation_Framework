using AngleSharp.Common;
using Business.Builder;
using Business.Endpoint;
using Business.Models;
using Core.BaseEntities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace Tests 
{
    [Parallelizable(scope: ParallelScope.All)]
    [TestFixture]
    public class ApiTests : BaseApiTest
{
        public UserDTOBuilder userDTOBuilder;

        [Category("API")]
        [Test, Description("Task#1")]
        public void ValidateThatTheListOfUsersCanBeReceivedSuccessfullyTest()
        {
            Log.Info("Validate that the list of users can be received successfully test");
           
            UserDTOBuilder.Builder builder = new UserDTOBuilder.Builder();
            userDTOBuilder =  builder.CreateGetRequest(Endpoint.usersEndpoint)
                                     .CreateResponse(GetRestClient())
                                     .GetUsersList()
                                     .Build();

            var keys = userDTOBuilder.GetUsers().FirstOrDefault().ToDictionary().Keys.ToList();
            var list = new List<object> (){"Id", "Name", "Username", "Email", "Address", "Phone",   "Website",  "Company"};

            Assert.AreEqual(HttpStatusCode.OK, userDTOBuilder.GetRestResponse().StatusCode);
            Assert.IsTrue(Enumerable.SequenceEqual(keys,list));
        }

        [Category("API")]
        [Test, Description("Task#2")]
        public void ValidateResponseHeaderForAListOfUsersTest()
        {
            Log.Info("Validate response header for a list of users test");
           
            UserDTOBuilder.Builder builder = new UserDTOBuilder.Builder();
            userDTOBuilder = builder.CreateGetRequest(Endpoint.usersEndpoint)
                                    .CreateResponse(GetRestClient())
                                    .Build();

            Assert.AreEqual(HttpStatusCode.OK, userDTOBuilder.GetRestResponse().StatusCode);
            Assert.NotNull(userDTOBuilder.GetRestResponse().ContentType);
            Assert.AreEqual(userDTOBuilder.GetRestResponse().ContentHeaders.First().Value, "application/json; charset=utf-8");
        }

        [Category("API")]
        [Test, Description("Task#3")]
        public void ValidateResponseBodyForAListOfUsersTest()
        {
            Log.Info("Validate response body for a list of users test");
           
            UserDTOBuilder.Builder builder = new UserDTOBuilder.Builder();
            userDTOBuilder = builder.CreateGetRequest(Endpoint.usersEndpoint)
                                    .CreateResponse(GetRestClient())
                                    .GetUsersList()
                                    .Build();

            var idCount = new HashSet<long>();
            foreach ( var user in userDTOBuilder.GetUsers())
            {
                idCount.Add(user.Id);
                Assert.NotNull(user.Name);
                Assert.NotNull(user.Username);
                Assert.NotNull(user.Company.Name);

            }

            Assert.AreEqual(userDTOBuilder.GetUsers().Count, 10);
            Assert.AreEqual(idCount.Count, 10);
            Assert.AreEqual(HttpStatusCode.OK, userDTOBuilder.GetRestResponse().StatusCode);
        }

        [Category("API")]
        [Test, Description("Task#4")]
        public void ValidateThatUserCanBeCreatedTest()
        {
            Log.Info("Validate that user can be created test");
           
           UserDTO userDTO = new UserDTO() {Name = "Jon", Username = "Smith" };

            UserDTOBuilder.Builder builder = new UserDTOBuilder.Builder();
            userDTOBuilder = builder.CreatePostRequest(Endpoint.usersEndpoint, userDTO)
                                    .CreateResponse(GetRestClient())
                                    .Build();

            Assert.IsNotEmpty(userDTOBuilder.GetRestResponse().Content);
            Assert.IsTrue(userDTOBuilder.GetRestResponse().Content.Contains("id"));
            Assert.AreEqual(HttpStatusCode.Created, userDTOBuilder.GetRestResponse().StatusCode);
        }

        [Category("API")]
        [Test, Description("Task#5")]
        public void ValidateThatUserIsNotifiedIfResourceDoesntExistTest()
        {
            Log.Info("Validate that user is notified if resource doesn’t exist test");

            UserDTOBuilder.Builder builder = new UserDTOBuilder.Builder();
            userDTOBuilder = builder.CreateGetRequest(Endpoint.invalidEndpoint)
                                    .CreateResponse(GetRestClient())
                                    .Build();

            Assert.AreEqual(HttpStatusCode.NotFound, userDTOBuilder.GetRestResponse().StatusCode);
        }
    }
}

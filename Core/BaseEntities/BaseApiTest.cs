using log4net;
using RestSharp;


namespace Core.BaseEntities
{
    public class BaseApiTest
    {
        protected string baseUrl = "https://jsonplaceholder.typicode.com/";

        protected ILog Log
        {
            get { return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); }
        }

        public RestClient GetRestClient()
        {
            Log.Info("Create RestClient");
            return new RestClient(baseUrl);
        }
    }
}

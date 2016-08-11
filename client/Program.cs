using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace client {
    class Program {

        private const string TOKEN_ENDPOINT = "http://localhost:44333/connect/token";
        //private const string TOKEN_ENDPOINT = "http://wkidentity.azurewebsites.net/connect/token";

        private const string RESOURCE_ENDPOINT = "http://localhost:45329/test";
        //private const string RESOURCE_ENDPOINT = "http://wkresource.azurewebsites.net/test";

        static void Main(string[] args) {

            var t = GetClientToken();
            CallApi(t);

            t = GetUserToken();
            CallApi(t);
            
            Console.ReadKey();

        }

        static TokenResponse GetClientToken() {
            var client = new TokenClient(
                TOKEN_ENDPOINT,
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("api1").Result;
        }

        static TokenResponse GetUserToken() {
            var client = new TokenClient(
                TOKEN_ENDPOINT,
                "carbon",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("bob", "secret", "api1").Result;
        }
        
        static void CallApi(TokenResponse response) {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync(RESOURCE_ENDPOINT).Result);
        }

    }
}

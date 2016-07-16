using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace client {
    class Program {

        static void Main(string[] args) {

            var t = GetClientToken();
            CallApi(t);


            Console.ReadKey();

        }

        static TokenResponse GetClientToken() {
            var client = new TokenClient(
                "http://wkidentity.azurewebsites.net/connect/token",
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("api1").Result;
        }

        static void CallApi(TokenResponse response) {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://wkresource.azurewebsites.net/test").Result);
        }

    }
}

using RestSharp;
using System.Text.Json;

namespace idscan{
    public class Program
    {
        static void Main(string[] args) {

            string authKey = "REPLACE_ME";

            var imageFile = File.ReadAllBytes(@"barcode-image.jpg");
            var data = Convert.ToBase64String(imageFile);

            var client = new RestClient("https://app1.idware.net");

            var request = new RestRequest("/DriverLicenseParserRest.svc/ParseImage", Method.Post);

            string jsonString = JsonSerializer.Serialize(new { authKey = authKey, data = data });

            request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);


        }

    }
}

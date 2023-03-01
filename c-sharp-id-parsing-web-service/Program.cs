using RestSharp;
using System.Text.Json;

namespace idscan{
    public class Program
    {
        static void Main(string[] args) {

            parseImageRequest();

            validateDriversLicenseNumber();

        }

        public static void parseImageRequest()
        {
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

        public static void validateDriversLicenseNumber()
        {
            string authKey = "REPLACE_ME";

            var client = new RestClient("https://app1.idware.net");
            var request = new RestRequest("/DriverLicenseParserRest.svc/ValidateLicenseNumber", Method.Post);

            string jsonString = JsonSerializer.Serialize(new { authKey = authKey, licenseNumber = "011978085", jurisdictionCode = "LA", countryCode = "USA" } );

            request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
    }


    }
}
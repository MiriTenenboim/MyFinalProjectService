using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;
using Nancy.Json;

namespace SpurringSportActivity.Service
{
    public class GoogleMapsAPI
    {
        private const string GoogleMapsBaseUrl = "https://maps.googleapis.com/maps/api/directions/json?";
        private readonly string _apiKey;

        public GoogleMapsAPI(string apiKey)
        {
            _apiKey = apiKey;
        }

        public int GetDistanceInSteps(double x1, double y1, double x2, double y2)
        {
            string origin = $"{x1},{y1}";
            string destination = $"{x2},{y2}";
            string url = $"{GoogleMapsBaseUrl}origin={origin}&destination={destination}&key={_apiKey}";

            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var responseFromServer = reader.ReadToEnd();
            var serializer = new JavaScriptSerializer();
            var jsonResponse = serializer.Deserialize<dynamic>(responseFromServer);

            var steps = jsonResponse["routes"][0]["legs"][0]["steps"];
            int distanceInSteps = 0;

            foreach (var step in steps)
            {
                distanceInSteps += (int)step["distance"]["value"];
            }

            return distanceInSteps;
        }
    }
}
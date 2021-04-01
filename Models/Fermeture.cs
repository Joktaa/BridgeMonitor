using System;
using Newtonsoft.Json;

namespace BridgeMonitor.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Fermeture>(myJsonResponse); 
    public class Fermeture
    {
        [JsonProperty("boat_name")]
        public string BoatName { get; set; }

        [JsonProperty("closing_type")]
        public string ClosingType { get; set; }

        [JsonProperty("closing_date")]
        public DateTime ClosingDate { get; set; }

        [JsonProperty("reopening_date")]
        public DateTime ReopeningDate { get; set; }

        public TimeSpan Duration { get; set; }
        public string ClosingDateString { get; set; }
        public string ReopeningDateString { get; set; }
    }

}
using System.Text.Json.Serialization;

namespace TeamsClientApiSample;

class MeetingControlMessage
{
    [JsonPropertyName("apiVersion")]
    public string ApiVersion { get; set; }

    [JsonPropertyName("action")]
    [JsonConverter(typeof(MeetingActionConverter))]
    public MeetingAction Action { get; set; }

    [JsonPropertyName("service")]
    [JsonConverter(typeof(MeetingServicesConverter))]
    public MeetingService Service { get; set; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; }

    [JsonPropertyName("device")]
    public string Device { get; set; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}

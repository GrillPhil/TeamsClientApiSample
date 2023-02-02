using System.Text.Json.Serialization;

namespace TeamsClientApiSample;

class MeetingEventMessage
{
    [JsonPropertyName("apiVersion")]
    public string ApiVersion { get; set; }

    [JsonPropertyName("errorMsg")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("meetingUpdate")]
    public MeetingUpdate? MeetingUpdate { get; set; }
}

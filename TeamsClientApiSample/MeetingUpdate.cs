using System.Text.Json.Serialization;

namespace TeamsClientApiSample;

class MeetingUpdate
{
    [JsonPropertyName("meetingPermissions")]
    public MeetingPermissions MeetingPermissions { get; set; }

    [JsonPropertyName("meetingState")]
    public MeetingState MeetingState { get; set; }
}

using System.Text.Json.Serialization;

namespace TeamsClientApiSample;

class MeetingPermissions
{
    [JsonPropertyName("canToggleHand")]
    public bool CanToggleHand { get; set; } = false;

    [JsonPropertyName("canToggleMute")]
    public bool CanToggleMute { get; set; } = false;

    [JsonPropertyName("canToggleVideo")]
    public bool CanToggleVideo { get; set; } = false;
}

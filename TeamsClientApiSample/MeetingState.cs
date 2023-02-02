using System.Text.Json.Serialization;

namespace TeamsClientApiSample;

class MeetingState
{
    [JsonPropertyName("isBackgroundBlurred")]
    public bool IsBackgroundBlurred { get; set; }

    [JsonPropertyName("isCameraOn")]
    public bool IsCameraOn { get; set; }

    [JsonPropertyName("isHandRaised")]
    public bool IsHandRaised { get; set; }

    [JsonPropertyName("isInMeeting")]
    public bool IsInMeeting { get; set; }

    [JsonPropertyName("isMuted")]
    public bool IsMuted { get; set; }

    [JsonPropertyName("isRecordingOn")]
    public bool IsRecordingOn { get; set; }
}

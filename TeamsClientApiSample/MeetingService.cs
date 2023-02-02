using System.Text.Json.Serialization;
using System.Text.Json;

namespace TeamsClientApiSample;

enum MeetingService
{
    BackgroundBlur,
    QueryMeetingState,
    RaiseHand,
    Recording,
    ToggleMute,
    ToggleVideo,
    Call
}
using System.Text.Json.Serialization;
using System.Text.Json;

namespace TeamsClientApiSample;

class MeetingActionConverter : JsonConverter<MeetingAction>
{
    public override MeetingAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer,
                               MeetingAction value,
                               JsonSerializerOptions options)
    {
        string serializedValue = value switch
        {
            MeetingAction.ToggleMute => "toggle-mute",
            MeetingAction.ToggleVideo => "toggle-video",
            MeetingAction.ToggleHand => "toggle-hand",
            MeetingAction.ToggleBackgroundBlur => "toggle-background-blur",
            MeetingAction.ToggleRecording => "toggle-recording",
            MeetingAction.LeaveCall => "leave-call",
            MeetingAction.ReactApplause => "react-applause",
            MeetingAction.ReactLaugh => "react-laugh",
            MeetingAction.ReactLike => "react-like",
            MeetingAction.ReactLove => "react-love",
            MeetingAction.ReactWow => "react-wow",
            MeetingAction.QueryMeetingState => "query-meeting-state",
            _ => string.Empty
        };

        writer.WriteStringValue(serializedValue);
    }
}

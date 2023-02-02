using System.Text.Json.Serialization;
using System.Text.Json;
using TeamsClientApiSample;

class MeetingServicesConverter : JsonConverter<MeetingService>
{
    public override MeetingService Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer,
                               MeetingService value,
                               JsonSerializerOptions options)
    {
        string serializedValue = value switch
        {
            MeetingService.BackgroundBlur => "background-blur",
            MeetingService.QueryMeetingState => "query_meeting_state",
            MeetingService.RaiseHand => "raise-hand",
            MeetingService.Recording => "recording",
            MeetingService.ToggleMute => "toggle-mute",
            MeetingService.ToggleVideo => "toggle-video",
            MeetingService.Call => "call",
            _ => string.Empty
        };

        writer.WriteStringValue(serializedValue);
    }
}
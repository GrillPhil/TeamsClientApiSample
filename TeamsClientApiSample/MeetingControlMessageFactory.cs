namespace TeamsClientApiSample;

static class MeetingControlMessageFactory
{
    public static MeetingControlMessage Create(string apiVersion, MeetingAction action, string manufacturer, string device)
    {
        return new MeetingControlMessage()
        {
            ApiVersion = apiVersion,
            Action = action,
            Service = ActionServiceMap[action],
            Manufacturer = manufacturer,
            Device = device,
            Timestamp = ToUnix(DateTime.Now)
        };
    }

    static Dictionary<MeetingAction, MeetingService> ActionServiceMap = new()
    {
        { MeetingAction.ToggleMute, MeetingService.ToggleMute },
        { MeetingAction.ToggleVideo, MeetingService.ToggleVideo },
        { MeetingAction.ToggleHand, MeetingService.RaiseHand },
        { MeetingAction.ToggleBackgroundBlur, MeetingService.BackgroundBlur },
        { MeetingAction.ToggleRecording, MeetingService.Recording },
        { MeetingAction.LeaveCall, MeetingService.Call },
        { MeetingAction.ReactApplause, MeetingService.Call },
        { MeetingAction.ReactLaugh, MeetingService.Call },
        { MeetingAction.ReactLike, MeetingService.Call },
        { MeetingAction.ReactLove, MeetingService.Call },
        { MeetingAction.ReactWow, MeetingService.Call },
        { MeetingAction.QueryMeetingState, MeetingService.QueryMeetingState }
    };

    static long ToUnix(DateTime dateTime)
    {
        long epochTicks = new DateTime(1970, 1, 1).Ticks;
        return ((dateTime.Ticks - epochTicks) / TimeSpan.TicksPerSecond);
    }
}

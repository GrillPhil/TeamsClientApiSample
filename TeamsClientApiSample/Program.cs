using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using TeamsClientApiSample;

string endpoint = "127.0.0.1";
int port = 8124;
string protocolVersion = "1.0.0";
string manufacturer = "Elgato";
string device = "Stream%20Deck";
string app = "Stream%20Deck";
string appVersion = "1.0.39";

var ws = new ClientWebSocket();

Console.WriteLine("Enter Teams API token:");
string token = Console.ReadLine();

Task webSocketBackgroundTask = Task.Run(async() => 
{
    await ws.ConnectAsync(new Uri($"ws://{endpoint}:{port}?token={token}&protocol-version={protocolVersion}&manufacturer={manufacturer}&device={device}&app={app}&app-version={appVersion}"), CancellationToken.None);
    Console.WriteLine("Connected to Teams. Waiting for Input...");

    // assuming this is enough for messages to fit into a single frame
    var buffer = new byte[1024]; 
    while (ws.State == WebSocketState.Open)
    {
        // this blocks until message from Teams client arrives
        var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
        if (result.MessageType == WebSocketMessageType.Close)
        {
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
        }
        else
        {
            string serializedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
            if (result.EndOfMessage)
            {
                MeetingEventMessage message = JsonSerializer.Deserialize<MeetingEventMessage>(serializedMessage);
                if (message.ErrorMessage is not null)
                {
                    Console.WriteLine($"Error: {message.ErrorMessage}");
                }
            }
        }
    }
});

while(true)
{
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.Escape)
    {
        break;
    } else
    {
        switch (key.Key) 
        {
            case ConsoleKey.D1:
                await SendAsync(MeetingAction.ToggleMute);
                break;
            case ConsoleKey.D2:
                await SendAsync(MeetingAction.ToggleVideo);
                break;
            case ConsoleKey.D3:
                await SendAsync(MeetingAction.ToggleHand);
                break;
            case ConsoleKey.D4:
                await SendAsync(MeetingAction.ReactApplause);
                break;
            case ConsoleKey.D5:
                await SendAsync(MeetingAction.ReactLaugh);
                break;
            case ConsoleKey.D6:
                await SendAsync(MeetingAction.ReactLike);
                break;
            case ConsoleKey.D7:
                await SendAsync(MeetingAction.ReactLove);
                break;
            case ConsoleKey.D8:
                await SendAsync(MeetingAction.ReactWow);
                break;
        }
    }

}

ws.Dispose();

async Task SendAsync(MeetingAction action)
{
    MeetingControlMessage message = MeetingControlMessageFactory.Create(protocolVersion, action, manufacturer, device);
    string serializedMessage = JsonSerializer.Serialize(message);
    ArraySegment<byte> data = new ArraySegment<byte>(Encoding.UTF8.GetBytes(serializedMessage));
    await ws.SendAsync(data, WebSocketMessageType.Binary, true, CancellationToken.None);
}
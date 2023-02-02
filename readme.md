# Teams Client Api Sample

With the release of the new Elgato Stream Deck plugin integration with Microsoft Teams (https://techcommunity.microsoft.com/t5/microsoft-teams-blog/delivering-new-webinar-experiences-with-microsoft-teams/ba-p/3725145) there is now also a client API for Microsoft Teams based on Websockets.

Although there is no official documentation yet it's possible to reverse engineer it as the plugin (https://apps.elgato.com/plugins/com.microsoft.teams) is written in Javascript. 

This is a sample .NET 7 console app that shows how to use the API.
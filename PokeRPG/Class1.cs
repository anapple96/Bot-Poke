using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;

namespace PokeRPG
{
    class StartMenu
    {
        private DiscordSocketClient _client;
        public async static void StartOak(SocketMessage message)
        {
            await message.Channel.SendMessageAsync("Pong!");
        }
    }
}

using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
public class Program
{
	public static void Main(string[] args)
		=> new Program().MainAsync().GetAwaiter().GetResult();

	private Task Log(LogMessage msg)
	{
		Console.WriteLine(msg.ToString());
		return Task.CompletedTask;
	}

	private DiscordSocketClient _client;

	public async Task MainAsync()
	{
		_client = new DiscordSocketClient();

		_client.Log += Log;

		await _client.LoginAsync(TokenType.Bot,
			Environment.GetEnvironmentVariable("DiscordToken"));
		await _client.StartAsync();

		_client.MessageReceived += MessageReceived;

		await Task.Delay(-1);
	}

	private async Task MessageReceived(SocketMessage message)
	{
		if (message.Content == "!ping")
		{
			await message.Channel.SendMessageAsync("Pong!");
		}
	}
}

using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
public class Program
{
	static Random rnd = new Random();
	int Lott = rnd.Next(1000000, 69420666);
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
			"t");
		await _client.StartAsync();

		_client.MessageReceived += MessageReceived;

		await Task.Delay(-1);
	}

	private async Task MessageReceived(SocketMessage message)
	{
		if (message.Content == $"/number {Lott}")
		{
			await message.Channel.SendMessageAsync($"Ding! {Lott} is the right number!");
		}

		if (message.Content == "/s Lottery")
		{
			await message.Channel.SendMessageAsync("/number [number] to guess the number!");
			Console.WriteLine($"{Lott}");
		}
	}
}

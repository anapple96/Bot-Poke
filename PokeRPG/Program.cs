using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using PokeRPG;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;
using Discord.Commands;

public class Program
{
	static Random rnd = new Random();
	int Lott = rnd.Next(1000000, 69420666);
	int Key = rnd.Next(10000, 69420);
	int i = 0;
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

		await _client.LoginAsync(TokenType.Bot,"");
		await _client.StartAsync();

		await Task.Delay(-1);
	}
}

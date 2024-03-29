using System.Threading.Tasks;
using System.Threading;
using System;

namespace DependencyInjection.Example;

public sealed class Worker : BackgroundService
{
	private readonly IMessageWriter _messageWriter;

	public Worker(IMessageWriter messageWriter) =>
		_messageWriter = messageWriter;

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			_messageWriter.Write($"Worker running at: {DateTimeOffset.Now}");
			await Task.Delay(1_000, stoppingToken);
		}
	}
}
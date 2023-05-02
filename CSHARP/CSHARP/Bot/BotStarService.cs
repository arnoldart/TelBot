using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace CSHARP.Bot;

public class BotStarService : IHostedService
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly UpdateHandler _updateHandler;
    private readonly string _botToken;
    private readonly bool _useLongPolling;
    private CancellationTokenSource? _cancellationTokenSource;

    public BotStarService(
        ITelegramBotClient telegramBotClient,
        UpdateHandler updateHandler,
        IOptions<BotOptions> botOptionsAccessor
        )
    {
        _telegramBotClient = telegramBotClient;
        _botToken = botOptionsAccessor.Value.AccesToken;
        _updateHandler = updateHandler;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _cancellationTokenSource = new();
        
        _telegramBotClient.StartReceiving(_updateHandler, cancellationToken: _cancellationTokenSource.Token);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _cancellationTokenSource?.Cancel();
        if (_useLongPolling) {
            return _telegramBotClient.CloseAsync(cancellationToken);
        } else {
            return _telegramBotClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace CSHARP.Bot;

public class UpdateHandler : IUpdateHandler
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<BotStarService> _logger;
    private User? _me;

    public UpdateHandler(
        IServiceProvider serviceProvider,
        ILogger<BotStarService> logger
    ) {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    
    private async Task<User> GetMeAsync(ITelegramBotClient botClient, CancellationToken cancellationToken) {
        if (_me is null) {
            _me = await botClient.GetMeAsync(cancellationToken);
        }
        return _me;
    }
    
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Console.WriteLine("halo bang");
    }
    
    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) {
        string errorMessage = exception switch {
            ApiRequestException apiRequestException => $"Telegram API Error:\n{apiRequestException.ErrorCode}\n{apiRequestException.Message}",
            _ => exception.ToString()
        };
        _logger.LogError(exception, "{message}", errorMessage);
       
        return Task.CompletedTask;
    }
}
using System;
using CSHARP.Bot;
using CSHARP.Wadaw.Talk;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder(args)
    .ConfigureServices(( hostBuilderContext, services) =>
    {
        IConfiguration configuration = hostBuilderContext.Configuration;
        
        services.AddTalk();
        
        // Telegram Bot
        services.AddTelegramBot(botToken: configuration["BotOptions:AccessToken"]);
        
    })
    .Build()
    .Run();
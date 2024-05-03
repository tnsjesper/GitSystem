using System.Diagnostics;
using GitSystem.Helper;
using Spectre.Console;

var version = "1.0.0";

AnsiConsole.Markup($"[bold gray]Welcome to the[/] [bold cyan]GitSystem[/]\n");
AnsiConsole.Markup($"[bold]- Version: {version}[/]\n\n");

var action = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[bold white]Perform an Action to the Git Server System[/]")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .AddChoices(new[]
        {
            "Git Login", "Lobby Server", "SMP-Spawn Server",
            "SMP-World Server", "SMP-Farm Server", "Proxy Server",
        }));


AnsiConsole.Markup($"[bold] Selected {action}![/]\n\n\n");
switch (action)
{
    case "Git Login":
    {
        AnsiConsole.Markup($"[white]:check_mark_button: Check git and gh installation[/]\n");


        if (await BashHelper.ExecuteCommand("which gh") != "")
            AnsiConsole.Markup("[gray] Github Cli is Installed![/]\n");
        else
        {
            AnsiConsole.Markup("[red] Github Cli is not installed![/]\n");
            AnsiConsole.Markup("[gray] Install Github Cli[/]\n");

            await BashHelper.ExecuteCommand("sudo apt update && sudo apt install gh");
        }

        if (await BashHelper.ExecuteCommand("which git") != "")
            AnsiConsole.Markup("[gray] Git is Installed![/]\n");
        else
        {
            AnsiConsole.Markup("[red] Git is not installed![/]\n");
            AnsiConsole.Markup("[gray] Install Git[/]\n\n");

            await BashHelper.ExecuteCommand("sudo apt install git-all");
        }


        var token = AnsiConsole.Ask<string>("[bold white]Provide a Token to login: [/]");
        AnsiConsole.Markup($"[gray]Token: {token}[/]\n");

        await BashHelper.CustomExecute($"gh auth login --with-token {token}");
    }
        break;


    case "Lobby Server":
    {
        // Lobby Server
    }
        break;


    case "SMP-Spawn Server":
    {
        AnsiConsole.Markup($"[bold] Selected {action}![/]");
    }
        break;


    case "SMP-World Server":
    {
        AnsiConsole.Markup($"[bold] Selected {action}![/]");
    }
        break;


    case "SMP-Farm Server":
    {
        AnsiConsole.Markup($"[bold] Selected {action}![/]");
    }
        break;


    case "Proxy Server":
    {
        AnsiConsole.Markup($"[bold] Selected {action}![/]");
    }
        break;
}
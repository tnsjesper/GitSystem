using System.Diagnostics;
using Spectre.Console;

var version = "1.0.0";

AnsiConsole.Markup($"[bold gray]Welcome to the[/] [bold cyan]GitSystem[/]\n");
AnsiConsole.Markup($"[bold]- Version: {version}[/]\n\n");
(int left, int top) = Console.GetCursorPosition();
var option = 1;
ConsoleKeyInfo key;
bool isSelected = false;


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


AnsiConsole.WriteLine($"Run the {action} Section.");

Process cmd = new Process();
switch (action)
{
    case "Git Login":
    {
        AnsiConsole.Markup($"[bold] Selected {action}![/]");
    }
        break;

    case "Lobby Server":
    {
        AnsiConsole.Markup($"[bold] Selected {action}![/]");
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
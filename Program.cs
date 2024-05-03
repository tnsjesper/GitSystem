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
        await AutoCommand.CheckGitInstallation(true);


        var token = AnsiConsole.Ask<string>("[bold white]:incoming_envelope: Provide a Token to login: [/]");
        AnsiConsole.Markup($"[gray]Token: {token}[/]\n");

        await BashHelper.CustomExecute($"gh auth login --with-token {token}");
    }
        break;


    case "Lobby Server":
    {
        // Lobby Server
        await AutoCommand.CheckGitInstallation(true);

        await AutoCommand.SectionPullPush("Lobby", "/crystopia/Lobby/");
    }
        break;


    case "SMP-Spawn Server":
    {
        await AutoCommand.CheckGitInstallation(true);

        await AutoCommand.SectionPullPush("SMP-Spawn", "/crystopia/SMP-Spawn");
    }
        break;


    case "SMP-World Server":
    {
        await AutoCommand.CheckGitInstallation(true);

        await AutoCommand.SectionPullPush("SMP-World", "/crystopia/SMP-World");
    }
        break;


    case "SMP-Farm Server":
    {
        await AutoCommand.CheckGitInstallation(true);

        await AutoCommand.SectionPullPush("SMP-Farm", "/crystopia/SMP-Farm");
    }
        break;


    case "Proxy Server":
    {
        await AutoCommand.CheckGitInstallation(true);

        await AutoCommand.SectionPullPush("Proxy", "/crystopia/Proxy");
    }
        break;
}
using GitSystem.Helper;
using Spectre.Console;

var version = "1.2.0";

AnsiConsole.Markup($"[bold gray]Welcome to the[/] [bold cyan]GitSystem[/]\n");
AnsiConsole.Markup($"[bold]- Version: {version}[/]\n\n");


// Here you can Change the Optons from your Section

var action = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[bold white]Perform an Action to the Git Server System[/]")
        .PageSize(10)
        .AddChoices(new[]
        {
            "Git Login", "Lobby Server", "SMP-Spawn Server",
            "SMP-World Server", "SMP-Farm Server", "Proxy Server", "Exit"
        }));


// Import the Options from the Section in the case


AnsiConsole.Markup($"[bold] Selected {action}![/]\n\n\n");
switch (action)
{
    case "Git Login":
    {
        await AutoCommand.CheckGitInstallation(true);

        await BashHelper.CustomExecute($"gh auth login");
    }
        break;


    case "Lobby Server":
    {
        await AutoCommand.CheckGitInstallation(true);

        // Edit here the Service and the pash to run git commands
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


    case "Exit":
    {
        await BashHelper.CustomExecute("^C");
    }
        break;
}
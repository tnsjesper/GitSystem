using System.Diagnostics;
using Spectre.Console;

namespace GitSystem.Helper;

public class AutoCommand
{
    public static async Task<Process> CheckGitInstallation(bool Check)
    {
        Process process = new Process();
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

        return process;
    }


    public static async Task<Process> SectionPullPush(string service, string path)
    {
        Process process = new Process();
        AnsiConsole.Markup($"\n[white]:check_mark_button: Start the Action![/]\n\n");


        var action = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold white]Selcet Pull or Push on the Service[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "Pull", "Push", "Run Command"
                }));


        switch (action)
        {
            
            case "Run Command":


            {
                
                var command = AnsiConsole.Ask<string>("[bold white]:incoming_envelope: Provide a Command: [/]");
                
                AnsiConsole.Markup($"[gray] Used: {service} in Path {path}[/]\n");
                AnsiConsole.Markup($"[white bold]Run the Run Command Action![/]\n\n\n");
                await BashHelper.CustomExecute($"cd {path} && {command}");
                AnsiConsole.Markup($"[green bold]Done![/] [white bold]Runned Command in {path}[/]\n");
            }
                break;
            
            case "Pull":


            {
                AnsiConsole.Markup($"[gray] Used: {service} in Path {path}[/]\n");
                AnsiConsole.Markup($"[white bold]Run the Pull Action![/]\n\n\n");
                await BashHelper.CustomExecute($"cd {path} && git fetch && git pull -r");
                AnsiConsole.Markup($"[green bold]Done![/] [white bold]Pulled in {path}[/]\n");
            }
                break;

            case "Push":
            {
                AnsiConsole.Markup($"[gray] Used: {service} in Path {path}[/]\n");
                AnsiConsole.Markup($"[white bold]Run the Push Action![/]\n\n\n");
                await BashHelper.CustomExecute($"cd {path} && git push");
                AnsiConsole.Markup(
                    $"[green bold]Done![/][white bold] Pushed in [link=https://github.com/Crystopia/Server.{service}]Server.{service}[/][/]\n");
                AnsiConsole.Markup($"https://github.com/Crystopia/Server.{service}\n");
            }
                break;
        }


        return process;
    }
}
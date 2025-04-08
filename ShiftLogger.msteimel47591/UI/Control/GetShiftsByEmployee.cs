﻿using Spectre.Console;
using UI.Models;
using UI.Service;
using UI.View;

namespace UI.Control;

internal class GetShiftsByEmployee
{
    public static void Get()
    {
        Helpers.PrintHeader();
        List<Shift> shifts = new();
        ShiftService shiftService = new();

        string name = Helpers.GetName();

        try
        {
            shifts = shiftService.GetShiftByEmployee(name).Result;
        }
        catch (Exception e)
        {

            AnsiConsole.MarkupLine($"[Red]There was a problem getting information from the server[/]");
            AnsiConsole.MarkupLine($"[Red]{e.Message}\n\n[/]");

            AnsiConsole.WriteLine("Press any key to return");
            Console.ReadLine();
            return;
        }

        if (shifts.Count != 0)
        {
            ViewShifts.Show(shifts);
        }
        else
        {
            AnsiConsole.MarkupLine($"[Red]No data found[/]\n\n");
            AnsiConsole.WriteLine("Press any key to return");
            Console.ReadLine();
        }

    }
}

﻿using DbUp;
using System;
using System.Reflection;
using DbUp.Reboot;

class Program
{
    static int Main(string[] args)
    {
        var connectionString = "Server=(localdb)\\v11.0;Integrated Security=true;AttachDbFileName=C:\\Users\\bholt\\DbUpTest.mdf;";

        var engine =
            DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

        ScriptingUpgrader upgradeScriptingEngine = new ScriptingUpgrader(connectionString, engine);
        var result = upgradeScriptingEngine.Run(args);

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
            return -1;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Success!");
        Console.ResetColor();
        return 0;
    }
}
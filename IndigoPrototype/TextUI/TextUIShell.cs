﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndigoEngine;
using IndigoEngine.Agents;

namespace TextUI
{
    /// <summary>
    /// If smb forgot to specify model
    /// </summary>
    public class UnsetModelException : Exception
    {
        public UnsetModelException()
        {
        }

        public UnsetModelException(string message)
            : base(message)
        {
        }

        public UnsetModelException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    /// <summary>
    /// For wrong input during textUI
    /// </summary>
    public class WrongInputException : Exception
    {
        public WrongInputException()
        {
        }

        public WrongInputException(string message)
            : base(message)
        {
        }

        public WrongInputException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Static class, making console UI.
    /// </summary>
    static class TextUIShell
    {
        //List of available commands
        static List<Command> commands = new List<Command>();

        //Attached model to observe
        static IObservableModel model = null;

        //Exit flag
        static bool isRunning = true;

        /// <summary>
        /// Method for commands storage. Add them here.
        /// </summary>
        static void Initialise()
        {
            commands.Add(new Command("test", "Writes some test output", args => { Console.WriteLine("Some Test Output"); }));

            commands.Add(new Command("help", "Prints all possible commands with description", args =>
            {
                foreach (Command c in commands)
                    Console.WriteLine(c.Description);
            }));

            commands.Add(new Command("exit", "Stops the entire UI", args =>
            {
                if(model.State == ModelState.Running && model.State == ModelState.Paused)
                Console.WriteLine("Stopping model...");
                model.Stop();
                Console.WriteLine("Model stopped...");
                isRunning = false;
            }));

            commands.Add(new Command("start", "Starts model", args => { model.Start(); }));

            commands.Add(new Command("pause", "Pauses model", args => { model.Pause(); }));

            commands.Add(new Command("stop", "Stops model", args => { model.Stop(); }));

            commands.Add(new Command("resume", "Resumes model from pause", args => { model.Resume(); }));

            commands.Add(new Command("state", "Shows model state", args => { Console.WriteLine(model.State.ToString()); }));

            commands.Add(new Command("iteration", "Shows model loop iteration", args => { Console.WriteLine(model.ModelIterations); }));

            commands.Add(new Command("tick", "Shows model loop iteration tick interval", args => { Console.WriteLine(model.ModelIterationTick); }));

            commands.Add(new Command("settick", "Sets model loop iteration in ms (ex: -settick 3000)", args =>
            {
                var ms = args[1] as string;
                model.ModelIterationTick = TimeSpan.FromMilliseconds(Convert.ToInt16(ms));
            }));

            commands.Add(new Command("agents", "Lists all agents in the world", args =>
            {
                foreach (Agent agent in model.Agents)
                    Console.WriteLine(agent.ToString());                
            }));
        }

        /// <summary>
        /// Property for attaching model. Think i'll modify thir connection somehow later
        /// </summary>
        public static IObservableModel Model
        {
            set
            {
                model = value;
            }
        }

        static TextUIShell()
        {
            Initialise();
        }

        /// <summary>
        /// Main loop for UI
        /// </summary>
        public static void Run()
        {
            if (model == null)
            {
                throw new UnsetModelException("You shoud specify model to watch for using Model property before calling Run method");
            }

            Console.WriteLine("Indigo prj, text UI.");
            Console.WriteLine("Type -help to get list of all available commands");

            while(isRunning)
            {
                try
                {
                string input = Console.ReadLine();

                string[] parsedInput = input.Split(' ');

                if (parsedInput.Length == 0)
                    throw new WrongInputException("Empty string in input. Type -help to see available commands.");

                if(!parsedInput[0].StartsWith("-"))
                    throw new WrongInputException("Each command shoud start with -. Don't know why, actualy.");

                if(!commands.Exists(c => c.Name == parsedInput[0].Substring(1)))
                    throw new WrongInputException("There in no command with this name. Type -help to see list of available commands.");

                //Execute typed command
                commands.First(c => c.Name == parsedInput[0].Substring(1)).Execute(parsedInput);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //Stop the model here
        }
    }
}
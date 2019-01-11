namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private  IReader reader;
        private  IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while(this.isRunning)
            {
                var input = this.reader.ReadLine();

                IList<string> inputParameters = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                string result = this.commandInterpreter.ProcessInput(inputParameters);

                if (input == "Terminate")
                {
                    this.isRunning = false;
                }

                this.writer.WriteLine(result);
                
            }
        }
    }
}
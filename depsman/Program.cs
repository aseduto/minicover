using System;
using McMaster.Extensions.CommandLineUtils;

namespace depsman
{
    class Program
    {
        static int Main(string[] args)
        {
            
            var commandLineApplication = new CommandLineApplication();
            commandLineApplication.Name = "depsman";
            commandLineApplication.Description = "depsman";

            
            commandLineApplication.Command("hello", command =>
            {
                Console.WriteLine("Hello World!");
            });

            commandLineApplication.HelpOption("-h | --help");

            try
            {

                int r = commandLineApplication.Execute(args);

                return r;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return 99;
            }
        }

    }
}

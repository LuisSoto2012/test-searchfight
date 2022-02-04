using System;
using searchfight.Factory;
using searchfight.Services.Configuration;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            // Validate that there are 2 arguments in command line

            if (args.Length >= 2)
            {
                // Design Pattern: FACTORY -> Since we need flexibility in creating different objects (search engines) but providing a single class (abstract)
                
                ISearchServiceFactory factory = new SearchServiceConfiguration();
                var services = factory.GetServices();

                foreach(var arg in args)
                {
                    // output example -> .net: Google: 4450000000 MSN Search: 12354420 
                    
                    Console.Write($"{arg}: ");

                    foreach (var service in services)
                        Console.Write($"{service.GetResults(arg)} ");
                    
                    Console.Write("\n");
                }

                // output example (next line) ->    Google winner: .net 
                //                                  MSN Search winner: java
                foreach (var service in services)
                    Console.WriteLine(service.WinnerToString());

                // output (next line) -> Total winner: .net 
                
                Console.WriteLine($"Total winner: {factory.GetFinalWinner(services)}");

                Console.ReadKey();
            }
            
            // Write message if args < 2
            
            Console.WriteLine("Need two (2) words.");
        }
    }
}
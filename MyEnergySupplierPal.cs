using MyEnergySupplierPal.Calculator;
using MyEnergySupplierPal.Reader;
using MyEnergySupplierPal.Writer;

namespace MyEnergySupplierPal
{
    /// <summary>
    /// This class is the starting point of the main application code
    /// </summary>
    public class MyEnergySupplierPal
    {
        private readonly IJsonReader _jsonReader;
        private readonly ICostCalculator _costCalculator;
        private readonly IConsoleWriter _consoleWriter;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="jsonReader"></param>
        /// <param name="costCalculator"></param>
        /// <param name="consoleWriter"></param>
        public MyEnergySupplierPal(IJsonReader jsonReader, ICostCalculator costCalculator, IConsoleWriter consoleWriter)
        {
            _jsonReader = jsonReader;
            _costCalculator = costCalculator;
            _consoleWriter = consoleWriter;
        }

        /// <summary>
        /// This method will perform the actual execution of the code
        /// </summary>
        /// <returns></returns>
        public bool Execute()
        {
            // Initialize the variables
            string input = string.Empty;
            string command = string.Empty;
            List<Plan> availablePlans = new List<Plan>();

            try
            {
                do
                {
                    Console.WriteLine("\nPlease enter the command below: ");
                    var strinput = Console.ReadLine();
                    input = (string.IsNullOrEmpty(strinput) ? string.Empty : strinput);
                    if (!string.IsNullOrEmpty(input))
                    {
                        int indexOfFirstSpace = input.IndexOf(' ');
                        command = (indexOfFirstSpace > 0) ? input.Substring(0, indexOfFirstSpace) : input;
                        
                        switch (command)
                        {
                            case "input":
                                // Read the input Json filepath
                                string filepath = input.Substring(indexOfFirstSpace + 1);

                                // Create an object of the JSON Reader class
                                availablePlans = _jsonReader.ReadInputJson(filepath);
                                if (availablePlans != null && availablePlans.Count > 0)
                                {
                                    Console.WriteLine("File read successfully");
                                }
                                else 
                                {
                                    Console.WriteLine("Error Occurred. Please try again");
                                }
                                break;
                            case "annual_cost":
                                if (availablePlans != null && availablePlans.Count > 0)
                                {
                                    int total_usage = Convert.ToInt32(input.Substring(indexOfFirstSpace + 1));
                                    var result = _costCalculator.CalculateTotalCost(availablePlans, total_usage);
                                    _consoleWriter.WriteOutput(result);
                                }
                                else
                                {
                                    Console.WriteLine("No available power plans.");
                                }
                                break;
                            case "exit":
                                Console.WriteLine("Stopping the program...");
                                break;
                            default:
                                Console.WriteLine("Unknown command: {0}", command);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command. Please try again.");
                    }
                }
                while (command != "exit");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}

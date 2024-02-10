using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnergySupplierPal.Writer
{
    /// <summary>
    /// This class is used to write the final output to the console
    /// </summary>
    public class ConsoleWriter : IConsoleWriter
    {
        /// <summary>
        /// This method will write the final output on the console
        /// </summary>
        public void WriteOutput(Dictionary<Plan, double> planCostMatrix)
        {
            try
            {
                if (planCostMatrix == null || planCostMatrix.Count == 0)
                {
                    throw new Exception("No data found to write on console.");
                }

                // Sort the ouput by ascending values of the cost per plan
                planCostMatrix = planCostMatrix.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.Write("\n");
                Console.WriteLine("Output: ");
                foreach (var kv in planCostMatrix)
                {
                    // Print the output on the console
                    Console.WriteLine($"{kv.Key.Supplier_Name},{kv.Key.Plan_Name},{kv.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

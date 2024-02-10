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
    public interface IConsoleWriter
    {
        /// <summary>
        /// This method will write the final output on the console
        /// </summary>
        void WriteOutput(Dictionary<Plan, double> planCostMatrix);
    }
}

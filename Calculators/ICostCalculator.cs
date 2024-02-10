namespace MyEnergySupplierPal.Calculator
{
    /// <summary>
    /// This class will calculate the total power cost for a given plan
    /// </summary>
    public interface ICostCalculator
    {
        /// <summary>
        /// This method will calculate the total cost for a given plan and consumption
        /// </summary>
        /// <returns></returns>
        Dictionary<Plan, double> CalculateTotalCost(List<Plan> plans, double consumption);
    }
}

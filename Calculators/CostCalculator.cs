using System.Numerics;

namespace MyEnergySupplierPal.Calculator
{
    /// <summary>
    /// This class will calculate the total power cost for a given plan
    /// </summary>
    public class CostCalculator : ICostCalculator
    {
        const double VATPercent = 5.0;
        const double TotalDaysPerYear = 365;

        /// <summary>
        /// This method will calculate the total cost for a given plan and consumption
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="consumption"></param>
        /// <returns></returns>
        public Dictionary<Plan, double> CalculateTotalCost(List<Plan> plans, double consumption)
        {
            var result = new Dictionary<Plan, double>();
            double totalCost = 0.0;
            double consumptionReset = consumption;

            foreach (Plan plan in plans)
            {
                totalCost = 0.0;

                // Add standing charge
                totalCost += CalculateAnnualStandingCharge(plan.Standing_Charge);

                // Calculate total power charges
                totalCost += CalculateConsumptionCharge(plan.Prices, consumption);

                // Calculate and add VAT to the total cost
                double vat = CalculateTotalVAT(totalCost);
                totalCost += vat;

                // Convert the cost into rupees and round the result to decimal points
                totalCost = totalCost / 100;
                result[plan] = Math.Round(totalCost, 2);
            }

            return result;
        }

        /// <summary>
        /// This method will calculate the power charges as per the rates
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="consumption"></param>
        /// <returns></returns>
        private double CalculateConsumptionCharge(List<Price> prices, double consumption)
        {
            double consumptionCharge = 0.0;
            foreach (var price in prices)
            {
                if (price.Threshold >= consumption || price.Threshold == 0)
                {
                    consumptionCharge += price.Rate * consumption;
                    break;
                }
                else
                {
                    consumptionCharge += price.Rate * price.Threshold;
                    consumption -= price.Threshold;
                }
            }
            return consumptionCharge;
        }

        /// <summary>
        /// This method calculated annual standing charges
        /// </summary>
        /// <param name="chargePerDay"></param>
        /// <returns></returns>
        private double CalculateAnnualStandingCharge(double chargePerDay) 
        {
            return chargePerDay * TotalDaysPerYear;
        }

        /// <summary>
        /// This method calculates VAT on a given amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private double CalculateTotalVAT(double amount) 
        {
            return amount * (VATPercent / 100);
        }
    }
}

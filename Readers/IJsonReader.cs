namespace MyEnergySupplierPal.Reader
{
    /// <summary>
    /// This class will handle all the operations related to the JSON Files
    /// </summary>
    public interface IJsonReader
    {
        /// <summary>
        /// This method will read the input json file and return all the available power plans which are stored in the file
        /// </summary>
        /// <returns></returns>
        List<Plan> ReadInputJson(string filepath);
    }
}

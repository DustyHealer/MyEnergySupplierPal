using MyEnergySupplierPal.Reader;
using Newtonsoft.Json;

/// <summary>
/// This class will handle all the operations related to the JSON Files
/// </summary>
public class JsonReader : IJsonReader
{
    /// <summary>
    /// This method will read the input json file and return all the available power plans which are stored in the file
    /// </summary>
    /// <returns></returns>
    public List<Plan> ReadInputJson(string filepath)
    {
        try
        {
            string text = string.Empty;

            // Check if the input filepath exists
            if (File.Exists(filepath))
            {
                text = File.ReadAllText(filepath);
            }
            else
            {
                throw new Exception("Input file path is invalid. Please try again.");
            }

            // Deserialize the text into the object
            var result = JsonConvert.DeserializeObject<List<Plan>>(text);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Input file is empty. Please try again");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return new List<Plan>();
    }
}
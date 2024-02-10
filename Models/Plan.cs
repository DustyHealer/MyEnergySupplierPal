/// <summary>
/// This model class will store the different power plans available to the user
/// </summary>
public class Plan
{
    public string Supplier_Name { get; set; }
    public string Plan_Name { get; set; }
    public double Standing_Charge { get; set; }
    public List<Price> Prices { get; set; }
}
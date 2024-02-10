// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using MyEnergySupplierPal.Calculator;
using MyEnergySupplierPal.Reader;
using MyEnergySupplierPal.Writer;

try
{
    //setup our DI
    var serviceProvider = new ServiceCollection()
        .AddSingleton<IJsonReader, JsonReader>()
        .AddSingleton<ICostCalculator, CostCalculator>()
        .AddSingleton<IConsoleWriter, ConsoleWriter>()
        .AddSingleton<MyEnergySupplierPal.MyEnergySupplierPal>()
        .BuildServiceProvider();

    var energySupplier = serviceProvider.GetService<MyEnergySupplierPal.MyEnergySupplierPal>();
    var isSuccess = energySupplier.Execute();
}
catch (Exception ex)
{
    Console.WriteLine($"Exception occurred: {ex.Message}");
    Console.ReadKey();
}
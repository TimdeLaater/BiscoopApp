using DomainServices.Interfaces;

namespace Domain.Strategies.Export;

public class ExportPlainText : IExport
{
    public void Export(List<KeyValuePair<string, dynamic>> exportData)
    {
        var id = exportData.First(kvp => kvp.Key == "ID").Value;
        var aantal = exportData.First(kvp => kvp.Key == "Aantal").Value;
        var prijs = exportData.First(kvp => kvp.Key == "Prijs").Value;

        var stringData = "ID: " + id + ". " + aantal + " tickets." + " Prijs: €" + prijs;

        var di = new DirectoryInfo("../../../");
        var path = di.FullName + "Orders/PlainText/Orders.txt";

        if (!File.Exists(path))
        {
            // Create a file to write to.
            using var sw = File.CreateText(path);
            sw.WriteLine(stringData);
        }
        using (var sw = File.AppendText(path))
        {
            sw.WriteLine(stringData);
        }
    }
}
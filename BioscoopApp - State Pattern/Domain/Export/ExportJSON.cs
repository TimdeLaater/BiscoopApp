using BioscoopApp.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace BioscoopApp.Domain.Export;

public class ExportJson : IExport
{
    public void Export(List<KeyValuePair<string, dynamic>> exportData)
    {
        var di = new DirectoryInfo("../../../");
        var path = di.FullName + "Orders/JSON/Orders.json";
        List<object>? array;

        using (var r = new StreamReader(path))
        {
            var json = r.ReadToEnd();
            array = JsonSerializer.Deserialize<List<object>>(json);
        }

        var itemToAdd = new JsonObject
        {
            ["ID"] = exportData.First(kvp => kvp.Key == "ID").Value,
            ["Aantal"] = exportData.First(kvp => kvp.Key == "Aantal").Value,
            ["Prijs"] = exportData.First(kvp => kvp.Key == "Prijs").Value
        };

        array!.Add(itemToAdd);
        var jsonAdd = JsonSerializer.Serialize(array);
        File.WriteAllText(path, jsonAdd);
    }
}
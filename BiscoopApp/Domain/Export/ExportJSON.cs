using BiscoopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace BiscoopApp.Domain.Export
{
    public class ExportJSON : IExport
    {
        public void Export(List<KeyValuePair<string, dynamic>> exportData)
        {
            DirectoryInfo di = new DirectoryInfo("../../../");
            string path = di.FullName + "Orders/JSON/Orders.json";
            var array = new List<object>();

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                array = JsonSerializer.Deserialize<List<object>>(json);
            }

            var itemToAdd = new JsonObject();
            itemToAdd["ID"] = exportData.Where(kvp => kvp.Key == "ID").First().Value;
            itemToAdd["Aantal"] = exportData.Where(kvp => kvp.Key == "Aantal").First().Value;
            itemToAdd["Prijs"] = exportData.Where(kvp => kvp.Key == "Prijs").First().Value;

            array!.Add(itemToAdd);

            string jsonAdd = JsonSerializer.Serialize(array);
            File.WriteAllText(path, jsonAdd);
        }
    }
}

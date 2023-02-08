using BiscoopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscoopApp.Domain.Export
{
    public class ExportPlainText : IExport
    {
        public void Export(List<KeyValuePair<string, dynamic>> exportData)
        {
            var ID =  exportData.Where(kvp => kvp.Key == "ID").First().Value;
            var Aantal = exportData.Where(kvp => kvp.Key == "Aantal").First().Value;
            var Prijs =  exportData.Where(kvp => kvp.Key == "Prijs").First().Value;

            string stringData = "Id: " + ID + ". " + Aantal + " tickets." + " Prijs: €" + Prijs;

            DirectoryInfo di = new DirectoryInfo("../../../");
            string path = di.FullName + "Orders/PlainText/Orders.txt";

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(exportData);
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(exportData);
            }
        }
    }
}

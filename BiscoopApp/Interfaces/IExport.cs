using System;
namespace BiscoopApp.Interfaces
{
    public interface IExport
    {
        public void Export(List<KeyValuePair<string, dynamic>> exportData);
    }
}

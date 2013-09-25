using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GitTrainingApp.Common.Entities;

namespace GitTrainingApp.DAL
{
    class MainRepository : IMainRepository
    {
        private List<LookupItem> _dataStore;
        private string _dataStoreFullPath;

        internal MainRepository()
        {
            _dataStore = new List<LookupItem>();
            string folder = Directory.GetCurrentDirectory();
            string fileName = ConfigurationManager.AppSettings["DataStoreFileName"];

            if (String.IsNullOrWhiteSpace(fileName))
                fileName = "Dictionary.xml";

            _dataStoreFullPath = folder + "\\" + fileName;
        }

        public ICollection<Common.Entities.LookupItem> RetrieveAll()
        {
            return _dataStore;
        }

        public IQueryable<Common.Entities.LookupItem> RetrieveQueryable()
        {
            return _dataStore.AsQueryable();
        }

        public LookupItem RetrieveById(string id)
        {
            LookupItem result = _dataStore.Where(o => o.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            return result ?? new LookupItem(id);
        }

        public void Save(Common.Entities.LookupItem item)
        {
            if (item == null)
                throw new Exception("Cannot save null object.");

            LookupItem result = _dataStore.Where(o => o.Id.Equals(item.Id, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (result == null)
            {
                //add
                _dataStore.Add(item);
            }
            else
            {
                //update
                result.Value = item.Value;
            }
        }

        public void RemoveById(string id)
        {
            LookupItem result = _dataStore.Where(o => o.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (result != null)
            {
                _dataStore.Remove(result);
            }
            else
            {
                throw new Exception("Item not found.");
            }
        }

        public void LoadDataStore()
        {
            if (File.Exists(_dataStoreFullPath))
            {
                //load
                using (StreamReader sr = new StreamReader(_dataStoreFullPath))
                {
                    string fileContent = sr.ReadToEnd();
                    if (!String.IsNullOrWhiteSpace(fileContent))
                    {
                        XElement root = XDocument.Parse(fileContent).Root;

                        foreach (XElement elem in root.Descendants("Entry"))
                            _dataStore.Add(new LookupItem(elem.Attribute("id").Value, elem.Value));
                    }
                }
            }
        }

        public void SaveDataStore()
        {
            XElement root = new XElement("Dictionary");
            foreach (LookupItem item in this._dataStore)
            {
                XElement elem = new XElement("Entry", new XAttribute("id", item.Id), item.Value);
                root.Add(elem);
            }

            string fileContent = root.ToString();

            using (StreamWriter sw = new StreamWriter(_dataStoreFullPath, false))
            {
                sw.Write(fileContent);
            }
        }
    }
}

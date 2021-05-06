using Newtonsoft.Json;
using Smart.DataTypes;
using Smart.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataLoadApp
{
    public class Loader
    {
        private string _folder = Path.Combine(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName);

        private string _mgmtJsonLocation = @"\JsonFiles\mgmt.json";
        private string _propertiesJsonLocation = @"\JsonFiles\properties.json";

        private ElasticSearchManager elasticSerchManager;

        public Loader()
        {
            string address = ConfigurationManager.AppSettings["ElasticURL"];
            string username = ConfigurationManager.AppSettings["ElasticUsername"];
            string password = SimpleCryptoManager.Instance.Decrypt(ConfigurationManager.AppSettings["ElasticPassword"]);

            elasticSerchManager = new ElasticSearchManager(address, username, password);
        }

        public void CreateIndexes()
        {
            elasticSerchManager.CreateIndexes();
        }

        public void LoadMgmtJson()
        {


            List<MgmtRoot> items;
            using (StreamReader r = new StreamReader(_folder + _mgmtJsonLocation))
            {
                string json = r.ReadToEnd();
                json = json.Replace(Environment.NewLine, "");
                items = JsonConvert.DeserializeObject<List<MgmtRoot>>(json);
            }

            List<Mgmt> mgmtItems = items.Select(x => x.mgmt).Distinct().ToList();
            elasticSerchManager.LoadMgmt(mgmtItems);
        }

        public void LoadPropertiesJson()
        {
            List<PropertyRoot> items;

            using (StreamReader r = new StreamReader(_folder + _propertiesJsonLocation))
            {
                string json = r.ReadToEnd();
                json = json.Replace(Environment.NewLine, "");
                json = json.Replace("]JSON_F52E2B61-18A1-11d1-B105-00805F49916B[", ",");
                items = JsonConvert.DeserializeObject<List<PropertyRoot>>(json);
            }

            List<Property> propertyItems = items.Select(x => x.property).Distinct().ToList();
            elasticSerchManager.LoadProperty(propertyItems);
        }


    }
}

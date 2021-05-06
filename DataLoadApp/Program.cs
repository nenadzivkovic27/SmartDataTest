using Smart.Managers;
using System;

namespace Smart.DataLoadApp
{
    public class DataLoadApp
    {

        static void Main(string[] args)
        {
            Loader loader = new Loader();
            loader.CreateIndexes();
            loader.LoadMgmtJson();
            loader.LoadPropertiesJson();
        }

    
    }
}

using System.Collections.Generic;

namespace FunCraftersTask.Data {
    public class DataLoaderDataStore {
        public int availableDataCount;
        public int indexToLoad;

        public IList<DataItem> items;


        public readonly int ITEMS_TO_SHOW = 5;
    }
}
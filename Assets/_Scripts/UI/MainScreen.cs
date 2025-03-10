using FunCraftersTask.Data;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FunCraftersTask.UI {
    public class MainScreen : MonoBehaviour {
        [Inject] DataLoaderHelper dataLoaderHelper;
        [Inject] DataLoaderDataStore dataLoaderDS;

        [SerializeField] Transform itemsContainer;
        [SerializeField] Item itemPrefab;

        List<Item> spawnedItems = new();

        void Start() {
            dataLoaderHelper.itemsLoaded += HandleItemsLoaded;
        }

        void HandleItemsLoaded(IList<DataItem> list) {
            ShowItems(list);
        }

        void ShowItems(IList<DataItem> list) {
            var i = 0;
            for (; i < list.Count; i++) {
                var item = list[i];
                var index = dataLoaderDS.indexToLoad + i + 1;
                if (spawnedItems.Count > i) {
                    spawnedItems[i].Setup(item, index);
                } else {
                    var spawnedItem = Instantiate(itemPrefab, itemsContainer);
                    spawnedItem.Setup(item, index);
                    spawnedItems.Add(spawnedItem);
                }
            }

            for (; i < spawnedItems.Count; i++)
                spawnedItems[i].gameObject.SetActive(false);
        }
    }
}
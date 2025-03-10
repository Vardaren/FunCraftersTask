using FunCraftersTask.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace FunCraftersTask.UI {
    public class MainScreen : MonoBehaviour {
        [Inject] DataLoaderHelper dataLoaderHelper;
        [Inject] DataLoaderDataStore dataLoaderDS;

        [SerializeField] Transform itemsContainer;
        [SerializeField] Item itemPrefab;
        [SerializeField] CategoryAssets categoryAssets;

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
                var uiItem = UIItem();

                if (spawnedItems.Count > i)
                    spawnedItems[i].Setup(uiItem);
                else
                    SpawnNewItem(uiItem);

            }

            for (; i < spawnedItems.Count; i++)
                spawnedItems[i].Hide();


            UIItemData UIItem() {
                var index = dataLoaderDS.indexToLoad + i + 1;
                var sprite = categoryAssets.categorySprites.FirstOrDefault(x => x.categoryType == list[i].Category).sprite;
                var uiItem = new UIItemData(index.ToString(), list[i], sprite);
                return uiItem;
            }

            void SpawnNewItem(UIItemData data) {
                var spawnedItem = Instantiate(itemPrefab, itemsContainer);
                spawnedItem.Setup(data);
                spawnedItems.Add(spawnedItem);
            }
        }

        void OnDestroy() {
            dataLoaderHelper.itemsLoaded -= HandleItemsLoaded;
        }
    }
}
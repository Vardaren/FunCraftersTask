using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainScreen : MonoBehaviour {
    [Inject] DataLoaderHelper dataLoaderHelper;
    [Inject] DataLoaderDataStore dataLoaderDS;

    [SerializeField] Transform itemsContainer;
    [SerializeField] Image loader;
    [SerializeField] Item itemPrefab;

    async void Start() {
        dataLoaderHelper.SetupServer();
        dataLoaderHelper.itemsLoaded += HadleItemsLoaded;
        await GetItemsCount();
        GetInitialItems().Forget();
    }

    void HadleItemsLoaded(IList<DataItem> list) {
        ShowItems(list);
    }

    void ShowItems(IList<DataItem> list) {
        foreach (DataItem item in list) {
            var spawnedItem = Instantiate(itemPrefab, itemsContainer);
            spawnedItem.Setup(item);
        }
    }

    async UniTask GetItemsCount() {
        loader.gameObject.SetActive(true);
        dataLoaderDS.availableDataCount = await dataLoaderHelper.GetItemsCount();
        loader.gameObject.SetActive(false);
    }

    async UniTaskVoid GetInitialItems() {
        loader.gameObject.SetActive(true);
        await dataLoaderHelper.RequestData();
        loader.gameObject.SetActive(false);
    }
}

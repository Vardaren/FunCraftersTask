using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainScreen : MonoBehaviour {
    [Inject] DataLoaderHelper dataLoaderHelper;
    [Inject] DataLoaderDataStore dataLoaderDS;

    [SerializeField] Image loader;
    [SerializeField] Item itemPrefab;

    void Start() {
        dataLoaderHelper.SetupServer();
        GetItemsCount().Forget();
    }

    async UniTaskVoid GetItemsCount() {
        loader.gameObject.SetActive(true);
        dataLoaderDS.availableDataCount = await dataLoaderHelper.GetItemsCount();
        loader.gameObject.SetActive(false);
    }

    async UniTaskVoid GetInitialItems() {
        loader.gameObject.SetActive(true);
        dataLoaderDS.items = await dataLoaderHelper.RequestData();
        loader.gameObject.SetActive(false);
    }
}

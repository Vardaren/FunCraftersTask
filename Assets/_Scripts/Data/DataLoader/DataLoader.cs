using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class DataLoader : MonoBehaviour {
    [Inject] DataLoaderHelper dataLoaderHelper;
    [Inject] DataLoaderDataStore dataLoaderDS;

    [SerializeField] Loader loader;

    async void Start() {
        dataLoaderHelper.SetupServer();
        await GetItemsCount();
        RequestInitialItems();
    }

    void RequestInitialItems() {
        RequestData().Forget();
    }

    async UniTask GetItemsCount() {
        loader.Show();
        dataLoaderDS.availableDataCount = await dataLoaderHelper.GetItemsCount();
        loader.Hide();
    }

    public async UniTaskVoid RequestData() {
        loader.Show();
        await dataLoaderHelper.RequestData();
        loader.Hide();
    }

    void OnDestroy() {
        dataLoaderHelper.CancelAndDispose();
    }
}

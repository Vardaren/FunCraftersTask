using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainScreen : MonoBehaviour {
    [Inject] DataLoaderHelper dataLoaderHelper;

    [SerializeField] Image loader;

    void Start() {
        dataLoaderHelper.LoadData();
        LoadData().Forget();
    }

    async UniTaskVoid LoadData() {
        loader.gameObject.SetActive(true);
        int availableData = await dataLoaderHelper.GetItemsCount();
        loader.gameObject.SetActive(false);
        Debug.Log(availableData);
    }
}

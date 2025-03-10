using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainScreenButtons : MonoBehaviour {
    [Inject] DataLoaderHelper dataLoaderHelper;
    [Inject] DataLoaderDataStore dataLoaderDS;

    [SerializeField] Button previousButton;
    [SerializeField] Button nextButton;
    void Start() {
        previousButton.onClick.AddListener(HandlePreviosButtonClicked);
        nextButton.onClick.AddListener(HandleNextButtonClicked);
    }

    void HandlePreviosButtonClicked() {
        var previousIndex = dataLoaderDS.indexToLoad - dataLoaderDS.ITEMS_TO_SHOW;
        if (previousIndex >= 0) {
            dataLoaderDS.indexToLoad = previousIndex;
            dataLoaderHelper.RequestData().Forget();
        }
    }

    void HandleNextButtonClicked() {
        var nextIndex = dataLoaderDS.indexToLoad + dataLoaderDS.ITEMS_TO_SHOW;
        if (nextIndex < dataLoaderDS.availableDataCount) {
            dataLoaderDS.indexToLoad = nextIndex;
            dataLoaderHelper.RequestData().Forget();
        }
    }
}

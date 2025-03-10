using FunCraftersTask.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FunCraftersTask.UI {
    public class MainScreenButtons : MonoBehaviour {
        [Inject] DataLoader dataLoader;
        [Inject] DataLoaderDataStore dataLoaderDS;
        [Inject] DataLoaderHelper dataLoaderHelper;

        [SerializeField] Button previousButton;
        [SerializeField] Button nextButton;

        void Start() {
            previousButton.onClick.AddListener(() => ChangeDataSet(-dataLoaderDS.ITEMS_TO_SHOW));
            nextButton.onClick.AddListener(() => ChangeDataSet(dataLoaderDS.ITEMS_TO_SHOW));

            dataLoaderHelper.itemsLoaded += UpdateButtonInteractivity;
        }

        void UpdateButtonInteractivity(IList<DataItem> _) {
            previousButton.interactable = dataLoaderDS.indexToLoad - dataLoaderDS.ITEMS_TO_SHOW >= 0;
            nextButton.interactable = dataLoaderDS.indexToLoad + dataLoaderDS.ITEMS_TO_SHOW < dataLoaderDS.availableDataCount;
        }

        void ChangeDataSet(int itemsToShow) {
            var newIndex = dataLoaderDS.indexToLoad + itemsToShow;

            if (newIndex >= 0 && newIndex < dataLoaderDS.availableDataCount) {
                dataLoaderDS.indexToLoad = newIndex;
                dataLoader.RequestData().Forget();
            }
        }
    }
}

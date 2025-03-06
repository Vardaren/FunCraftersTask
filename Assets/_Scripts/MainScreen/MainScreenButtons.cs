using System;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenButtons : MonoBehaviour {
    [SerializeField] Button previousButton;
    [SerializeField] Button nextButton;

    void Start() {
        previousButton.onClick.AddListener(HandlePreviosButtonClicked);
        nextButton.onClick.AddListener(HandleNextButtonClicked);
    }

    void HandlePreviosButtonClicked() {
        throw new NotImplementedException();
    }

    void HandleNextButtonClicked() {
        throw new NotImplementedException();
    }
}

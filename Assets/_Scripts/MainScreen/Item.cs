using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {
    [SerializeField] GameObject glow;
    [SerializeField] Image category;
    [SerializeField] TMP_Text index;
    [SerializeField] TMP_Text descritipion;
    [SerializeField] CategoryAssets categoryAssets;

    public void Setup(DataItem item) {
        glow.SetActive(item.Special);
        category.sprite = categoryAssets.categorySprites.FirstOrDefault(x => x.categoryType == item.Category).sprite;
        descritipion.text = item.Description;
    }
}

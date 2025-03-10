using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FunCraftersTask.UI {
    public class Item : MonoBehaviour {
        [SerializeField] GameObject glow;
        [SerializeField] Image category;
        [SerializeField] TMP_Text indexText;
        [SerializeField] TMP_Text descritipionText;
        [SerializeField] CategoryAssets categoryAssets;

        public void Setup(DataItem item, int index) {
            gameObject.SetActive(true);
            glow.SetActive(item.Special);
            category.sprite = categoryAssets.categorySprites.FirstOrDefault(x => x.categoryType == item.Category).sprite;
            indexText.text = index.ToString();
            descritipionText.text = item.Description;
        }
    }
}
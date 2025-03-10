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

        void Show() => gameObject.SetActive(true);

        public void Setup(UIItemData item) {
            Show();
            glow.SetActive(item.Special);
            category.sprite = item.CategoryIcon;
            indexText.text = item.Index;
            descritipionText.text = item.Description;
        }

        public void Hide() => gameObject.SetActive(false);
    }
}
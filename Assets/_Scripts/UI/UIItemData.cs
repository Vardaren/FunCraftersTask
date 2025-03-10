using UnityEngine;

namespace FunCraftersTask.UI {
    public class UIItemData {
        public string index;
        public bool special;
        public Sprite categoryIcon;
        public string description;

        public UIItemData(string index, DataItem dataItem, Sprite categoryIcon) {
            this.index = index;
            this.special = dataItem.Special;
            this.categoryIcon = categoryIcon;
            this.description = dataItem.Description;
        }
    }
}
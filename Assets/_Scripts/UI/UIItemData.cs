using UnityEngine;

namespace FunCraftersTask.UI {
    public class UIItemData {
        public string Index { get; }
        public bool Special { get; }
        public Sprite CategoryIcon { get; }
        public string Description { get; }

        public UIItemData(string index, DataItem dataItem, Sprite categoryIcon) {
            Index = index;
            Special = dataItem.Special;
            CategoryIcon = categoryIcon;
            Description = dataItem.Description;
        }
    }
}
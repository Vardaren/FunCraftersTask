using System;
using System.Collections.Generic;
using UnityEngine;
using static DataItem;

public class CategoryAssets : ScriptableObject {
    public List<CategorySprite> categorySprites;
}


[Serializable]
public class CategorySprite {
    public CategoryType categoryType;
    public Sprite sprite;
}

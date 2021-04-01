using UnityEngine;

namespace Scenes.InventoryDemo.Extras
{
    /**
     * The data model for game items, only purpose is sharing the fields.
     */
    [CreateAssetMenu(fileName = "New Item", menuName = "Game Items/New Item")]
    public class ItemModel : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        public Sprite itemSprite;
        public ItemType itemType;
        public int itemValue;
    }
}

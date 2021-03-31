using UnityEngine;

namespace Scenes.InventoryDemo
{
    [CreateAssetMenu(fileName = "New Game Item", menuName = "Game Items/New Item")]
    public class ItemModel : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        public Sprite itemSprite;
    }
}

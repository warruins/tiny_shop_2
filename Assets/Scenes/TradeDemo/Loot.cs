using UnityEngine;
using UnityEngine.UI;

namespace Scenes.TradeDemo
{
    public class Loot : MonoBehaviour
    {
        public string itemName;
        public string itemDescription;
        public Sprite itemImage;
        public int goldValue;
        public int quantity;
        private Image imageRenderer;

        private void Start()
        {
            imageRenderer = GetComponent<Image>();
            imageRenderer.sprite = itemImage;
        }

        public int GetValue()
        {
            return goldValue * quantity;
        }
    }
}

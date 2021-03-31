using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.InventoryDemo
{
    public enum ItemType { Lootable, Craftable }
    
    /**
     * Display and update information about items.
     */
    public class GameItem : MonoBehaviour
    {
        public Text itemName;
        public Text itemDescription;
        public Sprite itemSprite;
        private Image image;
        private CanvasGroup canvasGroup;

        private void Start()
        {
            image = GetComponent<Image>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            GetSprite();
        }

        public void GetSprite()
        {
            if (IsSpriteNull())
            {
                canvasGroup.alpha = 0;
            }
            else
            {
                image.sprite = itemSprite;
                canvasGroup.alpha = 1;
            }
        }

        private bool IsSpriteNull() => itemSprite == null;
    }
}

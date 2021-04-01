using System;
using Scenes.InventoryDemo.Extras;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.InventoryDemo
{
    /**
     * Display item slot background and current item data.
     */
    public class ItemSlot : MonoBehaviour
    {
        public ItemModel item;
        public GameItem itemView;

        private void Start()
        {
            itemView = GetComponentInChildren<GameItem>();
        }

        private void Update()
        {
            if(item != null) DisplayItem();
        }

        public void DisplayItem()
        {
            itemView.itemSprite = item.itemSprite;
        }
    }
}

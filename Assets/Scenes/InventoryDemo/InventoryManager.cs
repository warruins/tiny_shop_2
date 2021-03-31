using System;
using UnityEngine;

namespace Scenes.InventoryDemo
{
    /**
     * Loads and saves inventory data.
     */
    public class InventoryManager : MonoBehaviour
    {
        public Inventory inventory;
        private ItemSlot[] slots;

        private void Start()
        {
            slots = gameObject.GetComponentsInChildren<ItemSlot>();
            inventory.LoadPlayerInventory();
        }

        private void Update()
        {
            if (slots.Length > 0)
            {
                AddItemsToSlots();
            }
        }

        private void AddItemsToSlots()
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                slots[i].item = inventory.items[i];
            }
        }
    }
}

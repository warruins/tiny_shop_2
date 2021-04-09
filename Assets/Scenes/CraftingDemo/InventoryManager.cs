using Scenes.InventoryDemo;
using UnityEngine;

namespace Scenes.CraftingDemo
{
    /**
     * Loads and saves inventory data.
     */
    public class InventoryManager : MonoBehaviour
    {
        public Inventory inventory;
        public Recipe currentRecipe;
        private ItemSlot[] slots;
        private bool readyToCraft;

        private void Start()
        {
            slots = gameObject.GetComponentsInChildren<ItemSlot>();
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
            CheckIngredients();
        }

        // TODO: Tie to click event on UI controller buttons.
        public void CheckIngredients()
        {
            foreach (var ingredient in currentRecipe.ingredients)
            {
                if (!inventory.items.Contains(ingredient))
                {
                    readyToCraft = false;
                    return;
                }
            }
            readyToCraft = true;
        }

        public bool ReadyToCraft() => readyToCraft;

        public void CraftRecipe()
        {
            if (ReadyToCraft())
            {
                Debug.Log("Ready to craft!");
                // Update crafting progress bar.
                // when bar is full, add item from recipe to inventory
                // remove item quantities from inventory
            }
        }
    }
}
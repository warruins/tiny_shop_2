using System.Collections.Generic;
using Scenes.InventoryDemo;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.CraftingDemo
{
    /**
     * Loads and saves inventory data.
     */
    public class InventoryManager : MonoBehaviour
    {
        public Inventory inventory;
        public Recipe currentRecipe;
        public Image progressBar;
        
        private List<ItemSlot> slots;
        private List<ItemSlot> currentSlots;
        private bool readyToCraft;
        private bool startCrafting;
        
        private bool ReadyToCraft() => readyToCraft;
        private bool CraftingComplete() => progressBar.fillAmount >= 0.990;

        private void Start()
        {
            slots = new List<ItemSlot>(gameObject.GetComponentsInChildren<ItemSlot>());
            AddItemsToSlots();
        }

        private void Update()
        {
            if (slots.Count > 0)
            {
                AddItemsToSlots();
            }

            if (startCrafting)
            {
                FillProgressBar();
                if (CraftingComplete())
                {
                    inventory.items.Add(currentRecipe.recipe);
                    startCrafting = false;
                }
            }
            UpdateSlots();
        }

        // FIXME: Need a way to manage slots for duplicates and updating
        private void AddItemsToSlots()
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                slots[i].item = inventory.items[i];
            }
            CheckIngredients();
        }

        private void UpdateSlots()
        {
            foreach (var slot in slots)
            {
                if (inventory.items.Contains(slot.item))
                {
                    continue;
                }
                slot.item = null;
            }
        }

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

        public void CraftRecipe()
        {
            if (ReadyToCraft())
            {
                startCrafting = true;
                UpdateInventory();
            }
            else
            {
                progressBar.fillAmount = 0;
                startCrafting = false;
            }
        }
        
        private void FillProgressBar()
        {
            progressBar.fillAmount += 0.0025f;
        }

        private void UpdateInventory()
        { 
            foreach (var item in currentRecipe.ingredients)
            {
                inventory.items.Remove(item);
            }
        }
    }
}
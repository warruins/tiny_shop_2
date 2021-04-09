using System;
using Scenes.InventoryDemo;
using Scenes.InventoryDemo.Extras;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.CraftingDemo
{
    public class Recipe : MonoBehaviour
    {
        public Image image;
        public Text title;
        public ItemModel[] ingredients;
        public ItemModel recipe;
        public GameObject prefab;
        public GameObject materialsPanel;
        
        private void Start()
        {
            image.sprite = recipe.itemSprite;
            title.text = recipe.itemName;
            DisplayIngredients();
        }

        public void DisplayIngredients()
        {
            foreach (var ingredient in ingredients)
            {
                var panel = Instantiate(prefab, materialsPanel.transform, true);
                var item = panel.GetComponent<Slot>();
                item.item = ingredient;
            }
        }
    }
}

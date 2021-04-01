using System;
using System.Collections.Generic;
using Scenes.InventoryDemo.Extras;
using UnityEngine;

namespace Scenes.InventoryDemo
{
    /**
     * Loading and storage of inventory items in the game.
     */
    [Serializable]
    public class Inventory 
    {
        public List<ItemModel> items;

        public void LoadPlayerInventory()
        {
            var demoItems = Resources.LoadAll<ItemModel>("Items");
            foreach (var item in demoItems)
            {
                items.Add(item);
            }
            Debug.Log("Size: " + Size());
        }
        
        public int Size() => items.Count -1;
    }
}

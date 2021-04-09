using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.InventoryDemo.Extras;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemModel item;
    public Image image;

    private void Start()
    {
        if (item)
        {
            image.sprite = item.itemSprite;
        }

    }
}

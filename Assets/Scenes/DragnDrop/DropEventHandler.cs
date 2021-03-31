using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.DragnDrop
{
    public class DropEventHandler : MonoBehaviour, IDropHandler
    {
        private RectTransform rect;

        private void Start()
        {
            rect = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Item dropped.");
            RectTransform eventRect = eventData.pointerDrag.GetComponent<RectTransform>();
            eventRect.anchoredPosition = rect.anchoredPosition;
        }
    }
}

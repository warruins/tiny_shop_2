using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.DragnDrop
{
    public class DragEventHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public CanvasGroup canvasGroup;
        private RectTransform rect;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            rect = GetComponent<RectTransform>();
        }


        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging: ", eventData.pointerDrag);
            rect.anchoredPosition += eventData.delta;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Begin dragging...");
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("End drag");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }
}

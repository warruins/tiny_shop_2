using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scenes.TradeDemo
{
    public class ItemBox : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Loot item;
        public Button quantityButton;
        public Text helpText;
        public Text tooltip;
        public Text valueText;
        private Text quantityText;
        private int quantity;
        private CanvasGroup canvasGroup;
        private Image itemBox;
        private bool selected;
        private int calculatedValue;

        private void Start()
        {
            itemBox = gameObject.GetComponentInChildren<Image>();
            quantityText = quantityButton.GetComponentInChildren<Text>();
            canvasGroup = itemBox.GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
        }

        private void Update()
        {
            quantityText.text = item.quantity.ToString();
            valueText.text = item.goldValue.ToString();
        }

        public void UpdateQuantity()
        {
            // TODO: Not fully implemented, quantity isnt used in final calculation!
            if (quantity <= item.quantity)
            {
                quantity += 1;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            selected = !selected;
            helpText.gameObject.SetActive(selected);
            if (IsSelected() && item != null)
            {
                calculatedValue = item.GetValue();
                canvasGroup.alpha = 1;
            }
            else
            {
                calculatedValue = 0;
                canvasGroup.alpha = 0;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.text = $"{item.itemName}\n{item.itemDescription}";
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.text = null;
        }

        public int GetValue() => calculatedValue;
        public bool IsSelected() => selected;
    }
}

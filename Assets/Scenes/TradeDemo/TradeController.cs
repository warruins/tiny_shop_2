using UnityEngine;
using UnityEngine.UI;

namespace Scenes.TradeDemo
{
    public class TradeController : MonoBehaviour
    {
        public Text textBox;
        private int total;
        private ItemBox[] itemBoxes;

        void Start()
        {
            itemBoxes = GetComponentsInChildren<ItemBox>();
        }

        void FixedUpdate()
        {
            textBox.text = total.ToString();
        }

        public void Sell()
        {
            // TODO: this sells ALL of the item, does not use the Quantity button in calculation!
            foreach (var itemBox in itemBoxes)
            {
                total += itemBox.GetValue();
            }
        }

        public void Reset()
        {
            total = 0;
        }
    }
}

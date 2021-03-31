using UnityEngine;

namespace Scenes.InventoryDemo
{
    public class InventoryManager : MonoBehaviour
    {
        public Canvas menu;
        private bool isOpen = false;

        public void ToggleMenu()
        {
            isOpen = !isOpen;
            menu.gameObject.SetActive(isOpen);
        }
    }
}

using UnityEngine;

namespace Scenes.MenuDemo
{
    public class MenuController : MonoBehaviour
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

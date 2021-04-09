using UnityEngine;
using UnityEngine.UI;

namespace Scenes.CraftingDemo
{
    public class UIController : MonoBehaviour
    {
        public Button craftButton;
        private bool active;

        public void Activate()
        {
            active = !active;
            craftButton.gameObject.SetActive(active);
        }
    }
}

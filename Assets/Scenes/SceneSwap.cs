using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes
{
    public class SceneSwap : MonoBehaviour
    {
        public int number;
        public new string name;
        public Text buttonText;

        private void Start()
        {
            buttonText.text = name;
        }

        public void GetScene()
        {
            SceneManager.LoadSceneAsync(number);
        }
    }
}

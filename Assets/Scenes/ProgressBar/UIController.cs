using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.ProgressBar
{
    public class UIController : MonoBehaviour
    {
        public Image bar;
        private bool startFill;

        private void Update()
        {
            if (startFill)
            {
                bar.fillAmount += 0.0025f;
            }
        }

        public void Fill()
        {
            startFill = true;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
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

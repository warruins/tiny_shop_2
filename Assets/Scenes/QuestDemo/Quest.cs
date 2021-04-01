using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [Header("Quest Details")]
    public Text title;
    public Text summary;
    public Image icon;

    [Header("Reward Details")] 
    public Text reward;
    public Image rewardIcon;
}

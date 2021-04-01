using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.QuestDemo.Extras;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [Header("Quest Details")] 
    public ScriptableQuest quest;
    [SerializeField] private Text title;
    [SerializeField] private Text summary;
    [SerializeField] private Image icon;
    [Header("Debug")]
    public bool completed;
    
    [Header("Reward Details")] 
    [SerializeField] private Text reward;
    [SerializeField] private Image rewardIcon;

    [Header("Buttons")] 
    public Button button;
    public Image buttonImage;
    public Text buttonText;
    public Sprite buttonAlt;
    public bool delivered;
    
    private void Start()
    {
        title.text = quest.title;
        summary.text = quest.summary;
        icon.sprite = quest.icon;
        reward.text = quest.reward;
        rewardIcon.sprite = quest.rewardIcon;
        buttonImage = button.GetComponent<Image>();
        buttonText = button.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (IsAccepted() && IsComplete())
        {
            button.interactable = true;
        }
    }

    public void Accept()
    {
        quest.accepted = true;
        button.interactable = false;
        buttonText.text = "Deliver";
        buttonImage.sprite = buttonAlt;
    }

    public void Deliver()
    {
        if (IsAccepted() && IsComplete())
        {
            delivered = true;
            // TODO: add reward to player inventory
            // TODO: remove quest from quest log
        }
    }

    public bool IsAccepted() => quest.accepted;
    public bool IsComplete() => completed; //quest.complete;
    public bool IsDelivered() => delivered;
}

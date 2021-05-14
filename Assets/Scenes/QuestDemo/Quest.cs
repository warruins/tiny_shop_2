using Scenes.QuestDemo.Extras;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [Header("Quest Details")] 
    public ScriptableQuest quest;
    public bool complete;
    public bool delivered;
    [SerializeField] private Text title;
    [SerializeField] private Text summary;
    [SerializeField] private Image icon;
    
    [Header("Reward Details")] 
    [SerializeField] private Text reward;
    [SerializeField] private Image rewardIcon;

    [Header("Buttons")] 
    public Button button;
    
    private void Start()
    {
        title.text = quest.title;
        summary.text = quest.summary;
        icon.sprite = quest.icon;
        reward.text = quest.reward;
        rewardIcon.sprite = quest.rewardIcon;
        complete = quest.complete;
        delivered = quest.delivered;
    }

    private void Update()
    {
        if (IsComplete())
        {
            button.interactable = true;
        }
    }

    public void Deliver()
    {
        if (IsComplete())
        {
            quest.delivered = true;
            gameObject.SetActive(false);
            // TODO: add reward to player inventory
        }
    }

    public bool IsComplete() => quest.complete; 
}

using System;
using System.Collections.Generic;
using System.Linq;
using Scenes.InventoryDemo.Extras;
using Scenes.QuestDemo.Extras;
using UnityEngine;

namespace Scenes.QuestDemo
{
    public class QuestLogController : MonoBehaviour
    {
        public List<ScriptableQuest> quests;
        private Quest[] questCanvases;
        private List<ItemModel> inventory;

        private void Start()
        {
            questCanvases = GetComponentsInChildren<Quest>();
            inventory = GetComponentInParent<UIManager>().inventory;
            GetNewQuests();
            DisplayQuests();
        }

        private void Update()
        {
            CheckQuestUpdates();
        }

        private void CheckQuestUpdates()
        {
            foreach (var quest in quests.ToList())
            {
                GetCompletionStatus(quest);
                if (quest.complete && quest.delivered) RemoveQuest(quest);
            }
        }

        public void GetNewQuests()
        {
            var newQuests = Resources.LoadAll<ScriptableQuest>("Quests");
            foreach (var quest in newQuests)
            {
                if (!quest.complete) quests.Add(quest);
            }
        }

        private void DisplayQuests()
        {
            for (int i = 0; i < questCanvases.Length; i++)
            {
                questCanvases[i].quest = quests[i];
            }
        }

        private void GetCompletionStatus(ScriptableQuest quest)
        {
            foreach (var item in inventory)
            {
                // check quest.objective presence in player inventory
                if (item.itemName == quest.objective)
                {
                    // mark quest.complete if found
                    quest.complete = true;
                }
            }
        }

        public void RemoveQuest(ScriptableQuest quest)
        {
            // TODO: Remove the quest canvas so it doesnt display on the log.
            quests.Remove(quest);
        }
    }
}

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
        public Quest questPrefab;
        public List<ScriptableQuest> quests;
        private List<ItemModel> inventory;
        private List<Quest> questList;

        private void Start()
        {
            // ?: not clear why I have to initialize this but not quests
            questList = new List<Quest>(); 
            inventory = GetComponentInParent<UIManager>().inventory;
            GetNewQuests();
        }

        private void Update()
        {
            CheckQuestUpdates();
        }

        private void CheckQuestUpdates()
        {
            foreach (var quest in questList)
            {
                GetCompletionStatus(quest);
                if (quest.complete && quest.delivered) RemoveQuest(quest);
            }
        }

        private void GetNewQuests()
        {
            var newQuests = Resources.LoadAll<ScriptableQuest>("Quests");
            foreach (var quest in newQuests)
            {
                if (quest.complete && quest.delivered) continue;
                var questObj = Instantiate(questPrefab, transform);
                questObj.quest = quest;
                questList.Add(questObj);
            }
        }

        private void GetCompletionStatus(Quest quest)
        {
            foreach (var item in inventory)
            {
                // If quest.objective is in player inventory...
                if (item.itemName == quest.quest.objective)
                {
                    // ...then quest.complete
                    quest.quest.complete = true;
                }
            }
        }

        public void RemoveQuest(Quest quest)
        {
            questList.Remove(quest);
        }
    }
}

using UnityEngine;

namespace Scenes.QuestDemo.Extras
{
    public class ScriptableQuest : ScriptableObject
    {
        public string title;
        public string summary;
        public string details;
        public Sprite icon;
        public string reward;
        public Sprite rewardIcon;
        public string objective;
        public bool complete;
        public bool delivered;
    }
}

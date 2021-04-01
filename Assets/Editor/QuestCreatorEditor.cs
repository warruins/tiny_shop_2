using System;
using Scenes.QuestDemo.Extras;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class QuestCreatorEditor : EditorWindow
    {
        /**
     * Game Item Editor
     * Quick and easy tool to generate new objects within the game.
     */
        private string questsPath = "Assets/Resources/Quests/{0}.asset";
        private ScriptableQuest quest;
   
        private float labelWidth = 150f;
        public float textareaHeight = 100f;
    
        [MenuItem("Game/Quest Creator")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow(typeof(QuestCreatorEditor));
            Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/StaticAssets/Icons/quest.png");
            GUIContent titleContent = new GUIContent("Quest Creator", icon);
            window.titleContent = titleContent;
        }

        private void OnEnable()
        {
            CreateQuestInstance();
        }

        private void OnGUI()
        {
            DisplayQuestOptions();

            GUILayout.Space(20f);
            if (GUILayout.Button("Save"))
            {
                SaveQuest();
                ClearForm();
            }
        }

        void CreateQuestInstance()
        {
            quest = CreateInstance<ScriptableQuest>();
        }
        
        void SaveQuest()
        {
            var path = String.Format(questsPath, quest.title);
            var newPath = AssetDatabase.GenerateUniqueAssetPath(path);
            AssetDatabase.CreateAsset(quest, newPath);
            AssetDatabase.SaveAssets();
        }

        void ClearForm()
        {
            CreateQuestInstance();
        }
    
        void DisplayQuestOptions()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Quest Options", EditorStyles.boldLabel);
            GUILayout.EndHorizontal();
            GUILayout.Space(20f);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Title", GUILayout.Width(labelWidth));
            quest.title = EditorGUILayout.TextField(quest.title);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Summary", GUILayout.Width(labelWidth));
            quest.summary = EditorGUILayout.TextArea(quest.summary,GUILayout.Height(textareaHeight));
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Description", GUILayout.Width(labelWidth));
            quest.details = EditorGUILayout.TextArea(quest.details,GUILayout.Height(textareaHeight));
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Quest Icon", GUILayout.Width(labelWidth));
            quest.icon = EditorGUILayout.ObjectField(quest.icon,typeof(Sprite), true) as Sprite;
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Objective", GUILayout.Width(labelWidth));
            quest.objective = EditorGUILayout.TextField(quest.objective);
            GUILayout.EndHorizontal();

            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Reward", GUILayout.Width(labelWidth));
            quest.reward = EditorGUILayout.TextField(quest.reward);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Reward Icon", GUILayout.Width(labelWidth));
            quest.rewardIcon = EditorGUILayout.ObjectField(quest.rewardIcon, typeof(Sprite), true) as Sprite;
            GUILayout.EndHorizontal();
        }
    }
}
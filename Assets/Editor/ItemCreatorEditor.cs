using System;
using Scenes.InventoryDemo;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    /**
     * Loot Creator
     * Quick and easy tool to generate new objects within the game.
     */
    public class ItemCreatorEditor : EditorWindow
    {
        
        private readonly string itemsPath = "Assets/Resources/Items/{0}.asset";
        private ItemType itemType;
        private ItemModel itemModel;
    
        public float labelWidth = 150f;
    
        [MenuItem("Game/Loot Creator")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow(typeof(ItemCreatorEditor));
            Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/StaticAssets/Icons/loot.png");
            GUIContent titleContent = new GUIContent("Item Creator", icon);
            window.titleContent = titleContent;
        }

        private void OnEnable()
        {
            CreateItemInstance();
        }

        private void OnGUI()
        {
            DisplayLootableOptions();

            GUILayout.Space(20f);
            if (GUILayout.Button("Save"))
            {
                SaveItem();
                ClearForm();
            }
        }

        void CreateItemInstance()
        {
            itemModel = CreateInstance<ItemModel>();
            itemModel.itemType = itemType;
        }

        void SaveItem()
        {
            // Finally, save the new asset to the specified location.
            var path = String.Format(itemsPath, itemModel.itemName);
            var newTitle = AssetDatabase.GenerateUniqueAssetPath(path);
            AssetDatabase.CreateAsset(itemModel, newTitle);
            AssetDatabase.SaveAssets();
        }

        void ClearForm()
        {
            CreateItemInstance();
        }

        void DisplayLootableOptions()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Loot Options", EditorStyles.boldLabel);
            GUILayout.EndHorizontal();
            GUILayout.Space(20f);
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Item Type", GUILayout.Width(labelWidth));
            itemModel.itemType = (ItemType)EditorGUILayout.EnumPopup(itemModel.itemType);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Item Name", GUILayout.Width(labelWidth));
            itemModel.itemName = EditorGUILayout.TextField(itemModel.itemName);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Description", GUILayout.Width(labelWidth));
            itemModel.itemDescription = EditorGUILayout.TextArea(itemModel.itemDescription,GUILayout.Height(100));
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Icon", GUILayout.Width(labelWidth));
            itemModel.itemSprite = EditorGUILayout.ObjectField(itemModel.itemSprite, typeof(Sprite), true) as Sprite;
            GUILayout.EndHorizontal();
        
        }
    }
}
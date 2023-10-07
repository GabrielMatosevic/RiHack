using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class EWInventoryAdd : EditorWindow
{
    InventorySystem inventory;

    string _itemName;
    AItem.ItemType _type;
    int _buyVal;
    int _sellVal;

    bool shouldSave = false;
    bool hasSaved = false;

    InventorySave _dataMangement;

    [MenuItem("Inventory/Add Item")]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow(typeof(EWInventoryAdd), true, "Add Item to Inventory");
        window.maxSize = new Vector2(500, 350f);
        window.minSize = window.maxSize;
    }
    private void OnEnable()
    {
        _dataMangement = FindObjectOfType<InventorySave>();
    }

    private void OnGUI()
    {

        #region Title
        GUILayout.Space(15);
        GUILayout.Label("Add Item", new GUIStyle()
        {
            fontSize = 20,
            normal = new GUIStyleState() { textColor = Color.white },
            alignment = TextAnchor.MiddleCenter
        });

        EditorGUILayout.Space(50);
        #endregion
        EditorGUILayout.LabelField("Inventory Settings", EditorStyles.boldLabel);
        if (hasSaved)
        {
            EditorGUILayout.LabelField("Reopen window to add item to another inventory!", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Character inventory", inventory.gameObject.name);
        }
        else
        {
            inventory = (InventorySystem)EditorGUILayout.ObjectField("Character inventory", inventory, typeof(InventorySystem), true);
        }


        EditorGUILayout.Space(10);
        #region Item Settings
        EditorGUILayout.LabelField("Item Settings", EditorStyles.boldLabel);

        _itemName = EditorGUILayout.TextField("Item Name", _itemName);
        _type = (AItem.ItemType)EditorGUILayout.EnumPopup("Primitive to create:", _type);
        _buyVal = EditorGUILayout.IntField("Buy Value", _buyVal);
        _sellVal = EditorGUILayout.IntField("Sell Value", _sellVal);
        #endregion
        EditorGUILayout.Space(10);
        shouldSave = EditorGUILayout.Toggle("Should save", shouldSave);
        //Add Button Part
        float button_height = 50;
        if (GUI.Button(new Rect(0, maxSize.y - button_height, maxSize.x, button_height), "Add new item"))
        {
            try
            {
                
                inventory.Add(new Item(0, _type, _itemName, _buyVal, _sellVal, 1));
                if (shouldSave)
                {
                    inventory.PrintInventory();
                    _dataMangement.Save();
                    hasSaved = true;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("You have to assign the inventory object first!");
            }
        }
        
    }
}

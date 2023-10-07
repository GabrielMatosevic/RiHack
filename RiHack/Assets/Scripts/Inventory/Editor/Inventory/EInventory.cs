using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InventorySystem))]
public class EInventory : Editor
{
    [SerializeField] InventorySystem inventoryReferenceP;
    InventorySave _dataMangement;

    //[System.Obsolete]
    private void OnEnable()
    {
        inventoryReferenceP = FindObjectOfType<InventorySystem>();
        try
        {
            _dataMangement = inventoryReferenceP.gameObject.GetComponent<InventorySave>();
        }
        catch
        {
            Debug.LogError("You have to add InventorySave component to your inventory GameObject");
        }
        _dataMangement.Clear();
        _dataMangement.Load();
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (inventoryReferenceP.Inventory != null)
        {
            try
            {
                foreach (var kvp in inventoryReferenceP.Inventory)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField($"ID: {kvp.Key} Name: {kvp.Value.ItemName} Amount: {kvp.Value.AmountInInventory} ");
                    if (GUILayout.Button("+"))
                    {
                        inventoryReferenceP.Add(kvp.Value);
                    }
                    if (GUILayout.Button("-"))
                    {
                        inventoryReferenceP.Remove(kvp.Value);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
            catch{}
        }
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
        {
            _dataMangement.Save();
        }

        if (GUILayout.Button("Load"))
        {
            _dataMangement.Clear();
            _dataMangement.Load();
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Clear"))
        {
            _dataMangement.Clear();
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Show In Explorer"))
        {
            _dataMangement.ShowExplorer();
        }
        Repaint();
    }
}

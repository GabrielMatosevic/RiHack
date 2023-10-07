using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventorySave))]
[System.Serializable]
public class InventorySystem : MonoBehaviour
{
    private Dictionary<int, AItem> inventory = new Dictionary<int, AItem>();

    public Dictionary<int, AItem> Inventory { get => inventory; set => inventory = value; }

    public void Add(AItem item)
    {
        int x = GetKeyFromValue(item.ItemName);
        if (Inventory.ContainsKey(x))
        {
            Inventory[x].AmountInInventory += 1;
        }
        else
        {
            Inventory.Add(Inventory.Count + 1, item);
            item.ItemID = Inventory.Count;
        }
    }

    public void Remove(AItem item)
    {
        if (Inventory.ContainsValue(item))
        {
            Inventory[item.ItemID].AmountInInventory -= 1;
            if (Inventory[item.ItemID].AmountInInventory == 0)
            {
                Inventory.Remove(item.ItemID);
            }
        }
    }

    public void PrintInventory()
    {
        string value = "";
        if (Inventory != null)
        {
            foreach (var item in Inventory)
            {
                value += $"({item.Key}, {item.Value.ItemName}, {item.Value.AmountInInventory}) \t\r";
            }
        }
    }

    public int GetKeyFromValue(string name)
    {
        foreach (var kv in Inventory)
        {
            if (kv.Value.ItemName == name)
            {
                return kv.Key;
            }
        }
        return Inventory.Count + 1;
    }

}

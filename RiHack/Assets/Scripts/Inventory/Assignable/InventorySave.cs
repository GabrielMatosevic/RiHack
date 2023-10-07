using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class InventorySave : MonoBehaviour
{
    [SerializeField] private string filename;
    private InventorySystem inventory => gameObject.GetComponent<InventorySystem>();
    private List<ItemData> items = new List<ItemData>();
    
    protected string Path => Application.persistentDataPath + "/Inventory/" + filename;

    private void Start()
    {
        Clear();
        Load();
    }
    public void Save()
    {
        MYC_InventoryData data = new MYC_InventoryData();
        foreach (KeyValuePair<int, AItem> pair in inventory.Inventory)
        {

            ItemData curVal = new ItemData(pair.Value.ItemID, (int)pair.Value.ItemTypeValue, pair.Value.ItemName, pair.Value.BuyValue, pair.Value.SellValue, pair.Value.AmountInInventory);
            if (items.Any(item => item._itemID == pair.Value.ItemID))
            {
                items.Remove(items.Find(item => item._itemID == pair.Value.ItemID));
            }
            items.Add(curVal);

        }
        data.itemDatas = items;
        if (!File.Exists(Path))
        {
            (new FileInfo(Path)).Directory.Create();
        }
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(data, true));
        }
        catch (UnauthorizedAccessException)
        {
            Debug.LogError("You haven't specified filename in InventorySave component!");
        }
        
    }

    public void Load()
    {
        if (File.Exists(Path))
        {
            MYC_InventoryData data = JsonUtility.FromJson<MYC_InventoryData>(File.ReadAllText(Path));
            items = data.itemDatas;
            inventory.PrintInventory();
            foreach (var item in items)
            {
                AItem tempItem = new Item(item._itemID, (AItem.ItemType)item._itemType, item._itemName, item._buyValue, item._sellValue, item._amount);
                inventory.Add(tempItem);

            }
            inventory.PrintInventory();
        }
    }

    public void Clear()
    {
        inventory.Inventory.Clear();
        items.Clear();
    }

    public void ShowExplorer()
    {
        string itemPath = Path.Replace(@"/", @"\");   // explorer doesn't like front slashes
        System.Diagnostics.Process.Start("explorer.exe", "/select," + itemPath);
    }
}
[System.Serializable]
public class MYC_InventoryData
{
    public List<ItemData> itemDatas;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : AItem
{
    public Item(int itemID, ItemType itemType, string itemName, int buyValue, int sellValue, int amount)
    {
        this.itemID = itemID;
        this.itemType = itemType;
        this.itemName = itemName;
        this.buyValue = buyValue;
        this.sellValue = sellValue;
        this.amountInInventory = amount;
    }

}

[System.Serializable]
public class ItemData
{
    public int _itemID;
    public int _itemType;
    public string _itemName;
    public int _buyValue;
    public int _sellValue;
    public int _amount;

    public ItemData(int itemID, int itemType, string itemName, int buyValue, int sellValue, int amount)
    {
        _itemID = itemID;
        _itemType = itemType;
        _itemName = itemName;
        _buyValue = buyValue;
        _sellValue = sellValue;
        _amount = amount;
    }
}

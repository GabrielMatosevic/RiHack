using UnityEngine;

[System.Serializable]
public abstract class AItem : MonoBehaviour
{
    #region Definition of types of items
    public enum ItemType
    {
        WEAPON,
        ARMOR,
        HEALTH,
        COLLECTABLE
    }
    #endregion

    #region Attributes definitions
    [Header("Item Settings")]
    protected int itemID;
    [SerializeField] protected ItemType itemType;
    [SerializeField] protected string itemName;

    [Space]
    [SerializeField] protected int buyValue;
    [SerializeField] protected int sellValue;
    [SerializeField] protected int amountInInventory = 1;
    #endregion

    #region Properties definitions
    public int ItemID { get => itemID; set => itemID = value; }
    public string ItemName { get => itemName; }
    public ItemType ItemTypeValue { get => itemType; }
    public int BuyValue { get => buyValue; set => buyValue = value; }
    public int SellValue { get => sellValue; set => sellValue = value; }
    public int AmountInInventory { get => amountInInventory; set => amountInInventory = value; }
    #endregion

    void Start()
    {
        amountInInventory = amountInInventory == 0 ? 1 : amountInInventory;
    }
}

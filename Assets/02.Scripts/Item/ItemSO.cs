using UnityEngine;
using Utils.EnumType;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item/ItemSO")]
public class ItemSO : ScriptableObject
{
    public int id;
    public Sprite itmeImage;
    public string itemEName;
    public string itemKName;
    public float price;
    public int packageQuantity;
    public ItemCategoryType categoryType;
    public ItemCategory category;
}
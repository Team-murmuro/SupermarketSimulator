using System.Linq;
using UnityEngine;
using Utils.EnumType;

public class Inventory : MonoBehaviour
{
    private GameObject inventoryBase;
    private GameObject slotParent;
    private Slot[] slots;

    private void Start()
    {
        inventoryBase = transform.GetChild(0).gameObject;
        slotParent = inventoryBase.transform.GetChild(0).gameObject;

        slots = slotParent.GetComponentsInChildren<Slot>();
        System.Array.ForEach(slots, slot => slot.Init());
    }

    // 아이템 획득 
    public void GetItem(ItemSO _item, int _count)
    {
        // 같은 종류이 아이템이 있다면
        if(_item.categoryType != ItemCategoryType.Equipment)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null && slots[i].item.categoryType == _item.categoryType)
                {
                    slots[i].SetSlot(_count);
                    return;
                }
            }
        }

        // 같은 종류의 아이템이 없다면
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }

    // 아이템 사용
    public void UesItem(ItemSO _item, int _count)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null && slots[i].item.categoryType == _item.categoryType)
            {
                slots[i].SetSlot(_count);
                return;
            }
        }
    }
}

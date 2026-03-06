using UnityEngine;
using UnityEngine.UI;
using Utils.EnumType;

public class Inventory : MonoBehaviour
{
    private GameObject inventoryBase;
    private GameObject slotParent;
    private Slot[] slots;

    private int selectSlot = 0;      // 퀵슬롯 선택 번호
    private GameObject selectImage;  // 선택한 슬롯 이미지

    public GameObject itemPrefab;
    private PlayerController player;

    private void Start()
    {
        inventoryBase = transform.GetChild(0).gameObject;
        slotParent = inventoryBase.transform.GetChild(1).gameObject;

        slots = slotParent.GetComponentsInChildren<Slot>();
        System.Array.ForEach(slots, slot => slot.Init());

        selectImage = inventoryBase.transform.GetChild(0).gameObject;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        InputNumber();
    }

    private void InputNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectSlot(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            SelectSlot(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            SelectSlot(4);
    }

    // 인벤토리 선택
    public void SelectSlot(int _index)
    {
        selectSlot = _index;
        selectImage.transform.position = slots[selectSlot].transform.position;
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

    // 아이템 버림
    public void DropItem(ItemSO _item)
    {
        GameObject _itemPrefab = Instantiate(itemPrefab, player.transform.position, Quaternion.identity);
        _itemPrefab.GetComponent<Item>().item = _item;
        _itemPrefab.GetComponent<SpriteRenderer>().sprite = _item.itmeImage;
    }
}
using UnityEngine;
using UnityEngine.UI;
using Utils.EnumType;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public ItemSO item;             // 획득한 아이템
    public int itemCount;           // 획득한 아이템 개수

    private Image itemImage;        // 아이템 이미지
    private Text countText;         // 아이템 개수 텍스트
    private GameObject countObject;

    private Inventory inventory;
    private RectTransform baseRect;  // Invemtory_Base 영역
    
    public void Init()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
        countObject = itemImage.transform.GetChild(0).gameObject;
        countText = countObject.GetComponentInChildren<Text>();

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        baseRect = inventory.transform.GetChild(0).GetComponent<RectTransform>();
    }

    // 아이템 이미지 투명도 조절
    public void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 인벤토리에 새로운 아이템 추가
    public void AddItem(ItemSO _item, int _count)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itmeImage;

        if(item.categoryType != ItemCategoryType.Equipment)
        {
            countObject.SetActive(true);
            countText.text = itemCount.ToString();
        }
        else
        {
            countObject.SetActive(false);
            countText.text = "0";
        }

        SetColor(1f);
    }

    // 해당 슬롯의 아이템 개수 업데이트
    public void SetSlot(int _count)
    {
        itemCount += _count;
        countText.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    // 해당 슬롯 삭제
    public void ClearSlot()
    {
        item = null;
        itemCount = 0;
        countText.text = "0";
        itemImage.sprite = null;
        countObject.SetActive(false);

        SetColor(0);
    }

    // 해당 슬롯 자리 변경
    public void ChangeSlot()
    {
        ItemSO tempItem = item;
        int tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        if (tempItem != null)
            DragSlot.instance.dragSlot.AddItem(tempItem, tempItemCount);
        else
            DragSlot.instance.dragSlot.ClearSlot();
    }

    // 마우스 드래그가 시작했을 때 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.SetDragImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    // 마우스 드래그 하는 동안 계속 호출 
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
            DragSlot.instance.transform.position = eventData.position;
    }

    // 마우스 드래그 하는 것이 끝냈을 때 호출
    public void OnEndDrag(PointerEventData eventData)
    {
        // 인벤토리 영역을 벗어난 곳에서 드래그를 끝냈다면
        if (!(DragSlot.instance.transform.localPosition.x > baseRect.rect.xMin
            && DragSlot.instance.transform.localPosition.x < baseRect.rect.xMax
            && DragSlot.instance.transform.localPosition.y > baseRect.rect.yMin
            && DragSlot.instance.transform.localPosition.y < baseRect.rect.yMax))
        {
            if (DragSlot.instance.dragSlot != null)
            {
                Vector3 worldPos;

                RectTransformUtility.ScreenPointToWorldPointInRectangle(
                    baseRect,
                    eventData.position,
                    eventData.pressEventCamera,
                    out worldPos
                );

                Vector3 spawnPos = Camera.main.ScreenToWorldPoint(eventData.position);
                spawnPos.z = 0;

                inventory.DropItem(item, spawnPos);
                SetSlot(-1);
            }
        }
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();
        }
    }
}

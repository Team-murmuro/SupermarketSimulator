using UnityEngine;
using UnityEngine.UI;
using Utils.EnumType;

public class Slot : MonoBehaviour
{
    public ItemSO item;       // 획득한 아이템
    public int itemCount;   // 획득한 아이템 개수

    private Image itemImage; // 아이템 이미지
    private Text countText;  // 아이템 개수 텍스트
    private GameObject countObject;
    
    public void Init()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
        countObject = itemImage.transform.GetChild(0).gameObject;
        countText = countObject.GetComponentInChildren<Text>();
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
}

using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO item;
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.Find("MainCanvas").transform.GetChild(0).GetChild(0).GetComponent<Inventory>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.GetItem(item, 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    public int slotid;
    private Inventory inv;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if(inv.items[slotid].ID == -1)
        {
            inv.items[droppedItem.slot] = new Item();
            inv.items[slotid] = droppedItem.item;
            droppedItem.slot = slotid;
        }
        else if(droppedItem.slot != slotid)//swap
        {
            //moving the item to the old slot
            Transform itemWasThere = this.transform.GetChild(0);
            itemWasThere.GetComponent<ItemData>().slot = droppedItem.slot;
            itemWasThere.SetParent(inv.slots[droppedItem.slot].transform);
            itemWasThere.transform.position = inv.slots[droppedItem.slot].transform.position;

            //moving dropped item to new slot
            droppedItem.slot = slotid;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inv.items[droppedItem.slot] = itemWasThere.GetComponent<ItemData>().item;
            inv.items[slotid] = droppedItem.item;
        }
    }
}

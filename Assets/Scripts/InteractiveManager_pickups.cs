using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager_pickups : MonoBehaviour {
    private Inventory inv;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnTriggerEnter2D(Collider2D otherCol)
    {
        inv.AddItem(3);
        Destroy(this.gameObject);
    }
}

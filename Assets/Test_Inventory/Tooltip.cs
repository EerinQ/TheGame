using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    private Item item;
    private string data;
    private GameObject tooltip;
    string titleColorSet;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        if(item.Rarity == 2)
        {
            titleColorSet = "<color=#a52a2aff><b>";
        } else if(item.Rarity == 6)
        {
            titleColorSet = "<color=#ffa500ff><b>";
        }
        else
        {
            titleColorSet = "<color=#00ffffff><b>";
        }

        data = titleColorSet + item.Title + "</b></color>\n\n" + item.Description
            + "\nPower:" + item.Power;
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    private void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();

        Debug.Log(FetchItemByID(0).Description);
    }

    public Item FetchItemByID(int id)
    {
        for(int i = 0; i < database.Count; i++)
        {
            if(database[i].ID == id)
            {
                return database[i];
            }        
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for(int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item(
                (int)itemData[i]["id"], itemData[i]["title"].ToString(), 
                (int)itemData[i]["value"], (int)itemData[i]["stats"]["power"], 
                (int)itemData[i]["stats"]["defence"], (int)itemData[i]["stats"]["vitality"], 
                itemData[i]["description"].ToString(),(bool)itemData[i]["stackable"], 
                (int)itemData[i]["rarity"], itemData[i]["slug"].ToString(),
                itemData[i]["type"].ToString(), itemData[i]["rank"].ToString(),
                (bool)itemData[i]["isForProduction"], (bool)itemData[i]["isFuel"],
                (bool)itemData[i]["isForWeapon"], (bool)itemData[i]["isForBuilding"], 
                (bool)itemData[i]["canConvertToEnergy"], (bool)itemData[i]["isFood"]
                ));
        }
    }
}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int Defence { get; set; }
    public int Vitality { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public string Type { get; set; }
    public string Rank { get; set; }
    public bool IsForProduction { get; set; }
    public bool IsFuel { get; set; }
    public bool IsForWeapon { get; set; }
    public bool IsForBuilding { get; set; }
    public bool CanConvertToEnergy { get; set; }
    public bool IsFood { get; set; }

    public Item(
        int id, string title, int value, int power, int defence, 
        int vitality, string description, bool stackable, int rarity, string slug,
        string type, string rank, bool isForProduction, bool isFuel, bool isForWeapon, bool isForBuilding, 
        bool canConvertToEnergy, bool isFood)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Power = power;
        this.Defence = defence;
        this.Vitality = vitality;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);

        this.Type = type;
        this.Rank = rank;
        this.IsForProduction = isForProduction;
        this.IsFuel = isFuel;
        this.IsForWeapon = isForWeapon;
        this.IsForBuilding = isForBuilding;
        this.CanConvertToEnergy = canConvertToEnergy;
        this.IsFood = isFood;
    }

    public Item()
    {
        this.ID = -1;
    }
}

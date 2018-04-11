using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager_gathering : MonoBehaviour {
    //change sprite
    private SpriteRenderer sprRenderer;
    public Sprite Spr_before;
    public Sprite Spr_after;

    public float timer = 20.0f;

    public bool isInteractive = false;
    public bool spawned = false;
    public bool startCountDown = false;

    //random drop
    float randomNum;
    float maxNum = 5;
    public Transform dropPrefab;

    //range of drop
    const float range = 2.0f;

    void Awake()
    {
        spawned = true;
    }

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(startCountDown == true)
        {
            CountDown();
        }
        
        if (Input.GetKeyDown(KeyCode.E) && isInteractive)
        {
            startCountDown = true;
            Debug.Log("Gathered");
            sprRenderer.sprite = Spr_after;

            SpawnDrops();

            isInteractive = false;
            spawned = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D otherCol)
    {
        if(otherCol.gameObject.name == "InteractiveCollider")
        {
            Debug.Log("triggered collision");
            if(spawned == true)
            {
                isInteractive = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D otherCol)
    {
        isInteractive = false;
    }

    public void CountDown()
    {
        timer -= Time.deltaTime;

        //reset
        if (timer <= 0)
        {
            sprRenderer.sprite = Spr_before;
            spawned = true;
            isInteractive = true;
            startCountDown = false;
            timer = 20.0f;
        }
    }

    void SpawnDrops()
    {
        randomNum = Random.Range(1, maxNum);
        for (int i = 0; i < randomNum; i++)
        {
            Vector3 randomPos = Random.insideUnitSphere * range;
            randomPos.z = -1;
            Instantiate(dropPrefab, transform.position + randomPos, Quaternion.identity);
        } 
    }
}

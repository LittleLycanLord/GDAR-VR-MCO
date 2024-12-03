using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> items;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Randomize()
    {
        int randNum = Random.Range(0, items.Count);
        int randItem;
        int randItem2 = 0;
        if (randNum > 1)
        {
            randItem = Random.Range(0, randNum);
            randItem2 = Random.Range(0, randNum);
        }
        else
        {
            randItem = Random.Range(0, randNum);
        }

        Spawn(randItem, randItem2);

    }

    public void Spawn(int randItem, int randItem2)
    {
        items[randItem].SetActive(true);
        items[randItem2].SetActive(true);
        Debug.Log(items[randItem]);
        Debug.Log(items[randItem2]);
    }

    public void Reset()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(false);
        }
    }
}

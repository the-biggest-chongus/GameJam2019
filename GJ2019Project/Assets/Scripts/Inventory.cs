using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> items;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(Item item)
    {
        items.Add(item);
    }

    public bool hasItem(Item item)
    {
        return items.Contains(item);
    }
}

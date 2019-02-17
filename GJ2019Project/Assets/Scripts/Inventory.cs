using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Item, int> items;

    // Start is called before the first frame update
    void Start()
    {
        items = new Dictionary<Item, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(Item item)
    {
        if (items.ContainsKey(item))
        {
            int currentNumberOfItem = items[item];
            items[item] = currentNumberOfItem + 1;
        } else
        {
            items.Add(item, 1);
        }
        print("You now have " + items[item] + " " + item);
    }

    public int getNumberOfItem(Item item)
    {
        int numberOfItem = 0;
        if (items.ContainsKey(item))
        {
            numberOfItem = items[item];
        }
        return numberOfItem;
    }
}

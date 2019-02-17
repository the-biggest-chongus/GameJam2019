using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcManager : MonoBehaviour
{
    public List<GameObject> npcs;
    public Image progress;

    public List<GameObject> doors;

    public List<bool> items;

    public List<bool> completed;
    private int completedCount = 0;

    void Start()
    {
        progress.fillAmount = 0;
        int i = 0;
        while (i < npcs.Count)
        {
            completed.Add(false);
            i++;
        }
    }

    public bool unlockdoor(GameObject door)
    {
        int i = 0;
        while (i < doors.Count)
        {
            if (doors[i] == door)
            {
                print("check door");
                print(door.name);
                if (items[i])
                {
                    print("has item->unlock");
                    return true;
                }
            }
            i++;
        }
        return false;
    }

    public void resolve(GameObject npc)
    {
        int i = 0;
        while (i < npcs.Count)
        {
            if (npcs[i] == npc)
            {
                print("npc resolved");
                print(npc.name);
                completed[i] = true;
                completedCount++;
            }
            i++;
        }
        progress.fillAmount = (float)completedCount / (float)npcs.Count;
    }


}

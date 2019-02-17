using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcManager : MonoBehaviour
{
    public List<GameObject> npcs;
    public Image progress;

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

        public void resolve(GameObject npc)
    {
        print("npc resolved");
        print(npc.name);
        int i = 0;
        while (i < npcs.Count)
        {
            if(npcs[i] == npc)
            {
                print("tru");
                completed[i] = true;
                completedCount++;
            }
            i++;
        }
        progress.fillAmount = (float)completedCount / (float)npcs.Count;
    }


}

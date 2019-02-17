using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcManager : MonoBehaviour
{
    public List<string> npcs;

    public List<bool> completed;

    void Start()
    {
        int i = 0;
        while (i < npcs.Count)
        {
            completed.Add(false);
            i++;
        }
    }

        public void resolve(string npc)
    {
        int i = 0;
        while (i < npcs.Count)
        {
            if(npcs[i] == npc)
            {
                completed[i] = true;
            }
            i++;
        }
    }


}

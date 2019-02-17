using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class developers : MonoBehaviour
{
    public List<GameObject> team;

    private List<bool> resolved;
    private int resolveCount = 0;
    private bool completeQuest;

    public bool iscompleted()
    {
        return completeQuest;
    }

    public void resolveDev(int dev)
    {
        resolved[dev] = true;
        resolveCount++;
        if(resolveCount == resolved.Count)
        {
            completeQuest = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouth : Mouth
{
    // Start is called before the first frame update
    public override void Start()
    {
        //base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void crazySpewing()
    {
        base.startSpeakingAngryWords(0.025f);
    }

    public void stopCrazySpewing()
    {
        base.stopSpeakingAngryWords();
    }
}

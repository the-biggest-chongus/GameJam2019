using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouth : Mouth
{
    private bool sweeping = false;

    // Start is called before the first frame update
    public override void Start()
    {
        //base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (sweeping)
        {
            transform.Rotate(Vector3.up * 50f * Time.deltaTime, Space.World);
        }
    }

    public void crazySpewing()
    {
        base.startSpeakingAngryWords(0.025f);
    }

    public void stopCrazySpewing()
    {
        base.stopSpeakingAngryWords();
    }

    public void calculatedBarrage()
    {
        sweeping = true;
        base.startSpeakingAngryWords(0.1f);
    }

    public void stopCalculatedBarrage()
    {
        sweeping = false;
        base.stopSpeakingAngryWords();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouth : Mouth
{
    private bool sweeping = false;
    private bool sweepLeft = true;

    // Start is called before the first frame update
    public override void Start()
    {
        //base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (sweeping && sweepLeft)
        {
            print("sweep");
            transform.Rotate(Vector3.up * 70f * Time.deltaTime, Space.World);
        } else if (sweeping && !sweepLeft)
        {
            print("sweep2");
            transform.Rotate(Vector3.up * -70f * Time.deltaTime, Space.World);
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
        // Reset rotation
        transform.rotation = Quaternion.identity;
        sweeping = true;
        sweepLeft = true;

        Invoke("switchSweepDirection", 2f);
        base.startSpeakingAngryWords(0.1f);
    }

    public void stopCalculatedBarrage()
    {
        sweeping = false;
        base.stopSpeakingAngryWords();
    }

    private void switchSweepDirection()
    {
        sweepLeft = false;
    }
}

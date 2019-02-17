using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouth : Mouth
{
    [SerializeField] // allows us to see private variables in Inspector
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
            transform.Rotate(Vector3.up * 90f * Time.deltaTime, Space.World);
        } else if (sweeping && !sweepLeft)
        {
            transform.Rotate(Vector3.up * -90f * Time.deltaTime, Space.World);
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
        //transform.eulerAngles = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        sweeping = true;
        sweepLeft = true;

        Invoke("switchSweepDirection", 2f);
        base.startSpeakingAngryWords(0.1f);
    }

    public void stopCalculatedBarrage()
    {
        sweeping = false;
        //transform.eulerAngles = Vector3.zero;
        base.stopSpeakingAngryWords();
    }

    private void switchSweepDirection()
    {
        sweepLeft = false;
    }
}

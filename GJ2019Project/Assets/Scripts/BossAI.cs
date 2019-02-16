using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private bool raging = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("rage", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (raging)
        {
            spinLikeCrazy();
        } else
        {

        }
    }

    private void rage()
    {
        raging = true;
    }

    private void spinLikeCrazy()
    {
        transform.Rotate(Vector3.up * 1000f * Time.deltaTime, Space.World);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterTime : MonoBehaviour
{

    public float kill = 3;
    public float currentTime = 0;
    // Start is called before the first frame update
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > kill)
        {
            Destroy(gameObject);
        }
    }
}

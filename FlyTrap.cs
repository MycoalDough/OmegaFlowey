using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTrap : MonoBehaviour
{
    public GameObject fly;

    private void OnEnable()
    {
        StartCoroutine(spawnFly());

    }

    IEnumerator spawnFly()
    {
        for(int i = 0; i <Random.Range(19,25); i++)
        {
            MoveTowards s = Instantiate(fly, new Vector3(-9.87f, Random.Range(-4.5f, 4.3f), 0), Quaternion.identity).GetComponent<MoveTowards>();
            s.target = transform;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    public AudioSource s;
    public AudioSource ss;
    public float neY;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            StartCoroutine(kill());
            bool i = OmegaFlowey.changeHP();

            if(i)
            {
                ss.Play();
            }
            else
            {
                s.Play();
            }
            gameObject.transform.position = new Vector3(0, neY, 0);
        }
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int hurtAmmt = 7;
    public bool destroy = true;
    public bool useTrigger = true;
    public bool isHeal = false;

    public AudioSource s;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && useTrigger)
        {
            hurtAmmt = (isHeal) ? -20 : 5;
            PlayerController.changeHP(hurtAmmt);
            if(s)
            {
                s.Play();
            }
            if(destroy)
            {
                Destroy(gameObject);
            }
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !useTrigger)
        {
            hurtAmmt = 5;
            PlayerController.changeHP(hurtAmmt);
            if (s)
            {
                s.Play();
            }

            if (destroy)
            {
                Destroy(gameObject);
            }
        }
    }
}

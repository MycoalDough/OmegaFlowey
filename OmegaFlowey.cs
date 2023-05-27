using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OmegaFlowey : MonoBehaviour
{
    public GameObject eye;
    public Transform mainEye;

    public GameObject ringOfDeath;
    public GameObject bomb;
    public GameObject HandGunsLeft, HandGunsRight;
    public GameObject ft;

    public GameObject flyTrap;
    public CameraShake cameraShakes;
    public GameObject player;

    public AudioSource gb;
    public GameObject whipHand;
    public GameObject biter;

    public int current;

    public float attack;
    public float attackSpeed = 4;

    public bool at;

    public float hp = 10000;
    public GameObject healthBar;
    public Image img;
    public Text t;

    public int currentAttack;


    private void Start()
    {
        cameraShakes = Camera.main.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!at)
        {
            attack += Time.deltaTime;
            if(attack > attackSpeed)
            {
                attack = 0;
                attacking();
            }

        }

        img.fillAmount = hp / 10000f;
    }

    public static bool changeHP()
    {
        OmegaFlowey p = GameObject.FindObjectOfType<OmegaFlowey>().GetComponent<OmegaFlowey>();
        p.cameraShakes.StartCoroutine(p.cameraShakes.Shake(0.5f, 0.2f));

        if (p.hp < 4000)
        {
            int des = Random.Range(600, 800);
            p.StartCoroutine(p.hit(des));
            return true;

        }
        else
        {
            int des = Random.Range(400, 600);
            p.StartCoroutine(p.hit(des));
            return false;
        }


    }

    public IEnumerator hit(int dmg)
    {
        healthBar.SetActive(true);
        t.gameObject.SetActive(true);
        t.text = dmg.ToString();

        float showDMG = dmg / 10f;
        Debug.Log(showDMG);

        for (int i = 0; i < 10; i++)
        {
            hp -= showDMG;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);
        healthBar.SetActive(false);
        t.gameObject.SetActive(false);

    }

    void attacking()
    {
        at = true;
        int rn = 8;

        int rng = Random.Range(0, rn);

        while(rng == current)
        {
            rng = Random.Range(0, rn);
        }

        currentAttack = rng;
        current = rng;

        if (rng == 0)
        {
            StartCoroutine(eyesSwarm());
        }
        else if (rng == 1)
        {
            StartCoroutine(bulletHands());
        }
        else if (rng == 2)
        {
            StartCoroutine(ringOfDeathS());
        }
        else if (rng == 3)
        {
            StartCoroutine(bombSpawn());
        }
        else if (rng == 4)
        {
            StartCoroutine(flyTrapSpawn());
        }
        else if (rng == 5)
        {
            StartCoroutine(whipHands());
        }
        else if(rng == 6)
        {
            StartCoroutine(BiterSpawn());
        }
        else if(rng == 7)
        {
            StartCoroutine(Flamethrower());
        }
    }

    IEnumerator eyesSwarm()
    {
        gb.Play();
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < Random.Range(12, 15); i++)
            {
                Instantiate(eye, mainEye.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(0.75f, 1.25f));
        }

        at = false;

    }

    IEnumerator Flamethrower()
    {
        ft.SetActive(true);
        yield return new WaitForSeconds(2f); 
        at = false;
        yield return new WaitForSeconds(1.2f);
        ft.SetActive(false);

    }

    IEnumerator BiterSpawn()
    {
        for (int j = 0; j < 3; j++)
        {
            Instantiate(biter, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(1.77f ,4.17f), 0), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(Random.Range(0.2f, 0.4f));

        at = false;

    }


    IEnumerator whipHands()
    {
        for (int j = 0; j < 3; j++)
        {
            float xAxis = Random.Range(-7.3f, 7.3f);
            for (int i = 0; i < Random.Range(12, 15); i++)
            {
                HandVine s = Instantiate(whipHand, new Vector3(xAxis + Random.Range(-2f, 2f), whipHand.transform.position.y, whipHand.transform.position.z), Quaternion.identity).GetComponent<HandVine>();
                s.player = player.transform;
                yield return new WaitForSeconds(Random.Range(0.001f, 0.005f));

            }
            yield return new WaitForSeconds(Random.Range(1.2f, 1.5f));
        }

        at = false;

    }

    IEnumerator ringOfDeathS()
    {
        for (int j = 0; j < 4; j++)
        {
            Instantiate(ringOfDeath, player.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }

        at = false;

    }

    IEnumerator flyTrapSpawn()
    {
        flyTrap.SetActive(true);
        yield return new WaitForSeconds(1f);

        at = false;
        yield return new WaitForSeconds(3f);
        flyTrap.SetActive(false);

    }

    IEnumerator bombSpawn()
    {
        for (int j = 0; j < 10; j++)
        {
            Instantiate(bomb, bomb.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        }

        at = false;

        for (int j = 0; j < 10; j++)
        {
            Instantiate(bomb, bomb.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        }

    }


    IEnumerator bulletHands()
    {
        for (int i = 0; i < Random.Range(10, 20); i++)
        {
            int rng = Random.Range(0, 2);
            if (rng == 0)
            {
                Instantiate(HandGunsLeft, mainEye.position, HandGunsLeft.transform.rotation);
            }
            else
            {
                Instantiate(HandGunsRight, mainEye.position, HandGunsRight.transform.rotation);
            }

            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        }
        
        at = false;

        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            int rng = Random.Range(0, 2);
            if (rng == 0)
            {
                Instantiate(HandGunsLeft, mainEye.position, HandGunsLeft.transform.rotation);
            }
            else
            {
                Instantiate(HandGunsRight, mainEye.position, HandGunsRight.transform.rotation);
            }

            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        }
    }
}
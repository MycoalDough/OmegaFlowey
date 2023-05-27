using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeStarScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, Random.Range(-160, -20));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
}

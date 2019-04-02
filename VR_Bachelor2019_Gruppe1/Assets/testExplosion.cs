using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddExplosionForce(100f, gameObject.transform.position, 1f, 1f);
    }
}

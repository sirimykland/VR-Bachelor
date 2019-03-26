using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomShelfReplacer : MonoBehaviour
{
    public GameObject atomobject;

    // Update is called once per frame

    void Start()
    {
        // Call TimedUpdate immediately, repeat every 3 seconds
        InvokeRepeating("IsObjectGone", 0f, 3);
        InvokeRepeating("IsOnFloor", 0f, 10);
    }
    void IsObjectGone()
    {
        if(gameObject.transform.childCount == 0)
        {
            GameObject newatom = Instantiate(atomobject, transform.position, transform.rotation);
            newatom.transform.parent = gameObject.transform;
        }
    }

    void IsOnFloor()
    {
        foreach(Transform g in gameObject.GetComponentsInChildren<Transform>())
        {
            float dist = Vector3.Distance(g.transform.position, gameObject.transform.position);
            if (dist >2) Destroy(g.gameObject);
        }
    }

    public void CleanUpShelf()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject newatom = Instantiate(atomobject, transform.position, transform.rotation);
        newatom.transform.parent = gameObject.transform;
    }
}

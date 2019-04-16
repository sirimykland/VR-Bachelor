using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{

    void OnTriggerEnter(Collider cube)
    {
        if (cube.gameObject.CompareTag("Cube"))
        {
            Destroy(cube.gameObject);
        }
    }

}

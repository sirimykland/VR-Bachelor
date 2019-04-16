/* FloorCollider.cs - 02.04.2019
 * Destroys the cube GameObjects when they collide with the floor in the game.
 */ 


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

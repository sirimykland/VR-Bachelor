/* Card.cs - 02.04.2019
 * Card class that contains all variables and functions of a Card.
 */
using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour {

    // Getters and Setters
    public int state { get; set; }
    public int cardValue { get; set; }
    public int cardType { get; set; }
    public bool init { get; set; }
    public int timesFlipped { get; set; }


    public static bool DO_NOT_TURN;

    void Start(){
        state = 0;
        init = false;
        timesFlipped = 0;
        DO_NOT_TURN = false;
    }

    // Rotates the Card over time.
    IEnumerator RotateCard(int angle)
    {
        float t = 0;
        float root = transform.eulerAngles.y;

        float target = transform.eulerAngles.y+ angle;

        if (root > target){
            root= target;
            target = 0;
        }

        while (root < target)
        {
            t += Time.deltaTime;
            root = Mathf.Lerp(root, target, t * 0.5f);
            transform.rotation = Quaternion.Euler(0, root, 0);
            yield return null;
        }
    }

    // Adding backside material to the Card.
    public void SetupGraphics(Material backside) {
        StartCoroutine(RotateCard(360));
        this.gameObject.GetComponentInChildren<Renderer>().material = new Material(backside);
    }

    // Changes the state of the card and starts rotating it
    public void FlipCard() {
        if (state == 0 && !DO_NOT_TURN){
            state = 1;
            StartCoroutine(RotateCard(180));
        }
    }


    public IEnumerator RotateBack()
    {
        yield return new WaitForSeconds(1);
        if (state == 0)
        {
            StartCoroutine(RotateCard(180));
        }
        DO_NOT_TURN = false;
    }

}

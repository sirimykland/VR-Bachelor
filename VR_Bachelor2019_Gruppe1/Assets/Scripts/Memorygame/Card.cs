/* Card.cs - 02.04.2019
 * Card class that contains all variables and functions of a Card.
 */
using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour {

    // Getters and Setters
    public int state        { get; set; }  = 0 ;
    public int cardValue    { get; set; }
    public int cardType     { get; set; }
    public bool init        { get; set; }  = false;
    public int timesFlipped { get; set; }  = 0;

    // Locks all objects of class Card
    public static bool DO_NOT_TURN = false;


    /* A Coroutine that rotates the GameObjcet a specified amount degrees over time.
     *      - i is the interpolation
     *      - root is the cards rotation in the y-direction 
     *      - target is the target rotation in the y-direction.
     * While root is less than the target
     *      The Mathf.Lerp returns (to root) the linearly interpolated result 
     *      between current root and target by steps of i
     *      The GameObject's transform component is set to the new angle.
     */
    IEnumerator RotateCard(int angle)
    {
        float i = 0;
        float root = transform.eulerAngles.y;
        float target = root + angle;

        while (root < target)
        {
            i += 0.5f * Time.deltaTime;
            root = Mathf.Lerp(root, target, i);
            transform.rotation = Quaternion.Euler(0, root, 0);
            yield return null;
        }
    }

    // Adding backside material to the Card and animates a 360 rotation.
    public void SetupGraphics(Material backside) {
        StartCoroutine(RotateCard(360));
        this.gameObject.GetComponentInChildren<Renderer>().material = new Material(backside);
    }

    // Changes the state of the card and starts rotating it
    public void FlipCard() {
        if (state == 0 && !DO_NOT_TURN){
            state = 1;
            timesFlipped++;
            StartCoroutine(RotateCard(180));
        }
    }

    // Pauses for 1 sec, and rotates card if state = 0,
    // All cards are unlocked
    public IEnumerator IsFailedCheck()
    {
        yield return new WaitForSeconds(1);
        if (state == 0)
        {
            StartCoroutine(RotateCard(180));
        }
        DO_NOT_TURN = false;
    }

}

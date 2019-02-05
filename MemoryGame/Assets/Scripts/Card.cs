using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public static bool DO_NOT_TURN = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private int _cardType;
    [SerializeField]
    private bool _initialized = false;


    //private GameObject manager;
    //private GameObject m_instance; // reference to card when created

    void Start(){
        _state = 1;
        //manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void SetupGraphics(Material backside) {
        gameObject.GetComponentInChildren<Renderer>().material = new Material(backside);
        FlipCard();
    }

    public void FlipCard() {

        if (_state == 0)
            _state = 1;
        else if (_state == 1)
            _state = 0;
               
        if (_state == 0 && !DO_NOT_TURN)
            gameObject.transform.Rotate(0,0,0);
        else if (_state == 1 && !DO_NOT_TURN)
            gameObject.transform.Rotate(Vector3.up, 180);
    }

    public int CardValue{
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int CardType{
        get { return _cardType; }
        set { _cardType = value; }
    }

    public int State {
        get { return _state; }
        set { _state = value; }
    }

    public bool Initialized{
        get { return _initialized; }
        set { _initialized = value; }
    }

    public void falseCheck() {
        StartCoroutine(pause());
    }

    IEnumerator pause() {
        yield return new WaitForSeconds(1);
        if (_state == 0){
            gameObject.transform.Rotate(0, 180, 0);
            Debug.Log("Pressed button.");
        } else if (_state == 1) {
            gameObject.transform.Rotate(0, 0, 0);
        }
        DO_NOT_TURN = false;
    }

}

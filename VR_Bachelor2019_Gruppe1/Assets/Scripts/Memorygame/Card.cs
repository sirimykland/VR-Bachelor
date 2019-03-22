﻿using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour {
    
    public static bool DO_NOT_TURN = false;

    
    private int _state; //has a state, being {0=not open, 1= open, 2= locked open }
    private int _cardValue;
    private int _cardType;

    private bool _initialized = false;

    private int _timesFlipped;

    void Start(){
        _state = 0;
        _timesFlipped = 0;
    }

    //rotates the position of the GameObject over time
    IEnumerator RotateStuff(int angle)
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
    
    // rotatong animation, and adding backside material to Card object
    public void SetupGraphics(Material backside) {
        StartCoroutine(RotateStuff(360));
        this.gameObject.GetComponentInChildren<Renderer>().material = new Material(backside);
    }

    public void FlipCard() {

        if (_state == 0){
            _state = 1;
        }else if (_state == 1){
            _state = 0;
        }
        _timesFlipped++; // counter used to calculate points.
        
        if (_state == 0 && !DO_NOT_TURN){
            StartCoroutine(RotateStuff(180));     
        }
        else if (_state == 1 && !DO_NOT_TURN){
            StartCoroutine(RotateStuff(180));
        }  
    }

    public void FailedAttempt(){
        StartCoroutine(RotateBack());
    }

    IEnumerator RotateBack()
    {
        yield return new WaitForSeconds(2);
        if (_state == 0 || _state==1)
        {
            StartCoroutine(RotateStuff(180));
        }
    }

    // Getters and Setters
    public int CardValue{
        get { return _cardValue; }
        set { _cardValue = value; }
    }
    public int CardType{
        get { return _cardType; }
        set { _cardType = value; }
    }
    public int TimesFlipped
    {
        get { return _timesFlipped; }
        set { _timesFlipped = value; }
    }
    public int State {
        get { return _state; }
        set { _state = value; }
    }
    public bool Initialized{
        get { return _initialized; }
        set { _initialized = value; }
    }
}

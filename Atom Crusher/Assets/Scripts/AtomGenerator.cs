using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomGenerator : MonoBehaviour {

    //Connects script with the script AtomCollider to get its public variables
    public GameBehaviour gameBehaviour;
    private int score;

    public GameObject[] nonMetal;
    public GameObject[] metal;
    public Text timeText;

    private Rigidbody rB;
    private SphereCollider sC;
    private ConstantForce cF;

    private float fireRate;
    private float nextFire;
    private System.Random random = new System.Random();

    private int seconds;
    private int minutes;

    // Initialization
    void Start () {
        fireRate = 3.5f;
        nextFire = 0.0f;
        seconds = 0;
        minutes = 0;
        timeText.text = "0";
        score = gameBehaviour.score;
    }
	
	// Update is called once per frame
	void Update () {
        score = gameBehaviour.score;

        if (!gameBehaviour.gameOver)
        {
            UpdateTimer();

            if (Time.time >= 15f && score < 10)
            {
                fireRate = 2f;
            }
          

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GenerateAtom();
            }
        }
    }

    private void GenerateAtom()
    {
        int typeOfAtom = random.Next(1,5);
        int atomPath = random.Next(1, 5);
        int atomNumber;
        Vector3 position = new Vector3(0f,0f,21f);
        float velocity = -0.5f;

        if (score >= 8 && score < 12)
        {
            velocity = -1f;
        }
        else if (score >= 12 && score < 20)
        {
            velocity = -1.5f;
            fireRate = 1.5f;
        }
        else if (score >= 20 && score < 27)
        {
            velocity = -2f;
            fireRate = 1.2f;
        }
        else if (score >= 27 && score < 32)
        {
            velocity = -2.5f;
            fireRate = 1f;
        }
        else if (score >= 32 && score < 40)
        {
            velocity = -3f;
            fireRate = 0.8f;
        }
        else if (score >= 40)
        {
            velocity = -4f;
            fireRate = 0.5f;
        }

        switch (atomPath)
        {
            case 1:
                //position = new Vector3(-4f, 3.5f, 21f);
                position = new Vector3(-4f, 6.2f, 21f);
                break;
            case 2:
                position = new Vector3(-1.5f, 6.2f, 21f);
                break;
            case 3:
                position = new Vector3(1.5f, 6.2f, 21f);
                break;
            case 4:
                //position = new Vector3(4f, 3.5f, 21f);
                position = new Vector3(4f, 6.2f, 21f);
                break;
        }
        //if metal atom
        if (typeOfAtom == 4)
        {
            atomNumber = random.Next(0,3);
            GameObject atom = Instantiate(metal[atomNumber]);
            AddComponents(atom, velocity, position);
            atom.tag = "Metal";
        }
        //if nonmetal
        else if (typeOfAtom < 4)
        {
            atomNumber = random.Next(0, 6);
            GameObject atom = Instantiate(nonMetal[atomNumber]);
            AddComponents(atom, velocity, position);
            atom.tag = "NonMetal";
        }
    }

    //Adding components to the atom gameobjects
    private void AddComponents(GameObject gO, float velocity, Vector3 position)
    {
        sC = gO.AddComponent<SphereCollider>();
        rB = gO.AddComponent<Rigidbody>();
        cF = gO.AddComponent<ConstantForce>();
        sC.isTrigger = true;
        sC.center = new Vector3(0f, 0.35f, 0f);
        rB.useGravity = false;
        cF.force = new Vector3(0f, 0f, velocity);
        gO.transform.position = position;
        gO.transform.rotation = new Quaternion(0f, 90f, 0f, 0f);
    }


    private void UpdateTimer()
    {
        seconds = (int)Time.time % 60;
        minutes = (int)Time.time / 60;
        if (seconds < 10)
        {
            timeText.text = minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            timeText.text = minutes.ToString() + ":" + seconds.ToString();
        }

    }
}

/* Explotion.cs - 04.04.2019
 * behavior of explotion, starts animation sound
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    private ParticleSystem animation;
    private AudioSource source;

    // Set in Inspector
    public AudioClip explodeSound;

    // Awake is called  when the gameobject is  first Instantiated
    void Awake()
    {
        animation = GetComponent<ParticleSystem>();
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update, and sets of the explotion
    void Start()
    {
        animation.Play();
        source.PlayOneShot(explodeSound, 0.4f);
    }

}

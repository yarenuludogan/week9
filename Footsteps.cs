using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepclips;
    public AudioSource audiosource;

    public CharacterController controller;
    public float fshold;
    public float fsrate;
    private float lasttime;

     void FixedUpdate()
    {
        if(controller.velocity.magnitude> fshold)
        {
            if(Time.time - lasttime > fsrate)
            {
                lasttime = Time.time;
                audiosource.PlayOneShot(footstepclips[Random.Range(0, footstepclips.Length)]);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {

    ParticleSystem flameParticle;
	void Start ()
    {
        flameParticle = GetComponent<ParticleSystem>();
        flameParticle.Simulate(10f);
        flameParticle.Play();
    }
	
	
	void Update ()
    {
        
    }
}

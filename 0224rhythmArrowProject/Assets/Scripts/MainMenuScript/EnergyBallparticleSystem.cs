using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallparticleSystem : MonoBehaviour {

    ParticleSystem energyBallParticle;

	void Start ()
    {
        energyBallParticle = GetComponent<ParticleSystem>();
        energyBallParticle.Simulate(10f);
        energyBallParticle.Play();
	}
	
	
	void Update ()
    {
		
	}
}

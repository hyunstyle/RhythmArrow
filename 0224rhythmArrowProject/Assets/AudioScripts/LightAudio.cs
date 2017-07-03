﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAudio : MonoBehaviour {

    public int _band;
    public float _minIntensity, _maxIntensity;
    Light _light;

	void Start ()
    {
        _light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        _light.intensity = (AudioPeer._audioBandBuffer[_band] * (_maxIntensity - _minIntensity)) + _minIntensity;
	}
}

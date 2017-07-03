using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    private static AudioPeer instance;
    public static AudioPeer Instance
    {
        get
        {
            if (instance == null)
            {
                return GameObject.FindObjectOfType<AudioPeer>();
            }
            return AudioPeer.instance;
        }
    }

   public  AudioSource _audioSource;
    public bool isPlaying = false;

    public static float[] _sample = new float[512];
    public static float[] _freqBand = new float[8];
    public static float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    float[] _freqBandHighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

	
	// Update is called once per frame
	void Update ()
    {
        if(isPlaying)
        {
            GetSpectrumAudioSource();
            MakeFrequencyBands();
            BandBuffer();
            createAudioBands();
        }

    }

    

    void createAudioBands()
    {
        for(int i = 0; i<8; i++)
        {
            if(_freqBand[i] > _freqBandHighest[i])
            {
                _freqBandHighest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);
        }
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_sample, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {

        int cnt = 0;

        for(int i=0; i<8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i + 1); // 512개의 샘플을 만들기위해. 2의8승까지 더하면 510. 최종에 2 추가로 더해줌

            if (i == 7)
                sampleCount += 2;

            for(int j=0; j<sampleCount; j++)
            {
                average += _sample[cnt] * (cnt + 1);
                cnt++;
            }

            average /= cnt;
            _freqBand[i] = average * 10; 
        }
    }

    void BandBuffer()
    {
        for (int k = 0; k < 8; ++k)
        {
            if (_freqBand[k] > _bandBuffer[k])
            {
                _bandBuffer[k] = _freqBand[k];
                _bufferDecrease[k] = 0.005f;
            }
            if (_freqBand[k] < _bandBuffer[k])
            {
                _bandBuffer[k] -= _bufferDecrease[k];
                _bufferDecrease[k] *= 1.2f;
            }
        }
    }
}

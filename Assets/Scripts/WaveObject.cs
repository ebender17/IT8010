using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveObject : MonoBehaviour
{
    private Vector3 _startingPosition;
    private Vector3 _newPosition;
    private float _rawSineWave;

    [SerializeField] private int _frequency = 1;
    [SerializeField] private int _amplitude = 1;
    [HideInInspector] public int Frequency { 
        get { return _frequency; } 
        private set { _frequency = value; } 
    }

    [HideInInspector] public int Amplitude
    {
        get { return _amplitude; }
        private set { _amplitude = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _rawSineWave = Mathf.Sin(Time.time * _frequency) * _amplitude;
        _newPosition.y = (_rawSineWave + 1f) / 2f; //transform to 0 and 2 then divide by 2 to get value between 0 and 1
        
        _newPosition.x = 0.0f;
        _newPosition.z = 0.0f;

        transform.position = _startingPosition + _newPosition;

    }

    public void UpdateValues(int amp, int freq)
    {
        _amplitude = amp;
        _frequency = freq;
    }
}

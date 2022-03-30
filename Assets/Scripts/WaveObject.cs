using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AxisMovement
{
    xAxis, 
    yAxis, 
    zAxis
}

public class WaveObject : MonoBehaviour
{
    private Vector3 _startingPosition;
    private Vector3 _newPosition;
    private float _rawSineWave;

    [SerializeField] private int _frequency = 1;
    [SerializeField] private int _amplitude = 1;
    [SerializeField] private int _verticalShift = 0;
    [SerializeField] AxisMovement _axisToMoveOn = AxisMovement.yAxis;
    [HideInInspector] public int Frequency { 
        get { return _frequency; } 
        private set { _frequency = value; } 
    }

    [HideInInspector] public int Amplitude
    {
        get { return _amplitude; }
        private set { _amplitude = value; }
    }

    [HideInInspector] public int VerticalShift
    {
        get { return _verticalShift; }
        private set { _verticalShift = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        _rawSineWave = (Mathf.Sin(Time.time * _frequency) * _amplitude) + _verticalShift;

        if(_axisToMoveOn == AxisMovement.xAxis)
        {
            _newPosition.x = (_rawSineWave + 1f) / 2f;

            _newPosition.y = 0.0f;
            _newPosition.z = 0.0f;

        }
        else if(_axisToMoveOn == AxisMovement.yAxis)
        {
            _newPosition.y = (_rawSineWave + 1f) / 2f; //transform to 0 and 2 then divide by 2 to get value between 0 and 1

            _newPosition.x = 0.0f;
            _newPosition.z = 0.0f;

        }
        else if(_axisToMoveOn == AxisMovement.zAxis)
        {
            _newPosition.z = (_rawSineWave + 1f) / 2f;

            _newPosition.x = 0.0f;
            _newPosition.y = 0.0f;
        }
        

        transform.position = _startingPosition + _newPosition;

    }

    private void FixedUpdate()
    {
        
    }

    public void UpdateValues(int amp, int freq, int vertical)
    {
        _amplitude = amp;
        _frequency = freq;
        _verticalShift = vertical;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SineWaveUIManager : MonoBehaviour
{
    private int amplitude;
    private int frequency;

    [SerializeField] private TMP_Text amplitudeValue;
    [SerializeField] private TMP_Text frequencyValue;

    [Header("Broadcasting Events")]
    [SerializeField] private IntEventChannelSO _updateValues = default;

    [Header("Listening Events")]
    [SerializeField] private IntEventChannelSO _retrieveValues = default;


    private void OnEnable()
    {
        if(_retrieveValues != null)
        {
            _retrieveValues.OnEventRaised += RetrieveValues;
        }
    }

    private void OnDisable()
    {
        if(_retrieveValues != null)
        {
            _retrieveValues.OnEventRaised -= RetrieveValues; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseAmplitude()
    {
        if(amplitude < 9)
        {
            amplitude++;
            amplitudeValue.text = amplitude.ToString();
        } 
    }

    public void DecreaseAmplitude()
    {
        if(amplitude > 0)
        {
            amplitude--;
            amplitudeValue.text = amplitude.ToString();
        }
    }

    public void IncreaseFrequency()
    {
        if(frequency < 9)
        {
            frequency++;
            frequencyValue.text = frequency.ToString();
        }
    }

    public void DecreaseFrequency()
    {
        if(frequency > 0)
        {
            frequency--;
            frequencyValue.text = frequency.ToString();
        }
    }

    public void UpdateValues()
    {
        _updateValues.OnEventRaised(amplitude, frequency);
    }

    private void RetrieveValues(int amp, int freq)
    {
        amplitude = amp;
        frequency = freq;
        amplitudeValue.text = amplitude.ToString();
        frequencyValue.text = frequency.ToString();
    }
}

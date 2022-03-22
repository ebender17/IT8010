using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SineWaveUIManager : MonoBehaviour
{
    private float amplitude;
    private float frequency;

    [SerializeField] private TMP_Text amplitudeValue;
    [SerializeField] private TMP_Text frequencyValue;

    // Start is called before the first frame update
    void Start()
    {
        
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

    }
}

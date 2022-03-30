using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveGraph : MonoBehaviour
{
    public LineRenderer myLineRenderer;
    public int points;
    private float amplitude = 1;
    private float frequency = 1;
    private float verticalShift = 0;
    public Vector2 xLimits = new Vector2(0, 1);
    public float movementSpeed = 1;

    [Header("Listening Events")]
    [SerializeField] private IntEventChannelSO _updateValues = default;
    [SerializeField] private IntEventChannelSO _retrieveValues = default;

    private void OnEnable()
    {
        if(_updateValues != null)
        {
            _updateValues.OnEventRaised += UpdateGraph;
        }
        if(_retrieveValues != null)
        {
            _retrieveValues.OnEventRaised += UpdateGraph;
        }

    }

    private void OnDisable()
    {
        if (_updateValues != null)
        {
            _updateValues.OnEventRaised -= UpdateGraph;
        }
        if(_retrieveValues != null)
        {
            _retrieveValues.OnEventRaised -= UpdateGraph;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //myLineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawSineWave();
    }

    private void DrawSineWave()
    {
        float xStart = xLimits.x; //0;
        const float Tau = 2 * Mathf.PI;
        float xFinish = xLimits.y; //Tau;

        myLineRenderer.positionCount = points;
        for(int currentPoint = 0; currentPoint < points; currentPoint++)
        {
            float progress = (float)currentPoint / (points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = amplitude * Mathf.Sin((x * Tau * frequency) + (movementSpeed * Time.timeSinceLevelLoad)) + verticalShift;
            myLineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }
    }

    private void UpdateGraph(int amp, int freq, int vertical)
    {
        amplitude = amp;
        frequency = freq;
        verticalShift = vertical;
    }

}

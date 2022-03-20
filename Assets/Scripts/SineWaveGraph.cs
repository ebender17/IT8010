using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveGraph : MonoBehaviour
{
    public LineRenderer myLineRenderer;
    public int points;
    public float amplitude = 1;
    public float frequency = 1;
    public Vector2 xLimits = new Vector2(0, 1);
    public float movementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //myLineRenderer = GetComponent<LineRenderer>();
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
            float y = amplitude * Mathf.Sin((x * Tau * frequency) + (movementSpeed * Time.timeSinceLevelLoad));
            myLineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }
    }
    // Update is called once per frame
    void Update()
    {
        DrawSineWave();
    }
}

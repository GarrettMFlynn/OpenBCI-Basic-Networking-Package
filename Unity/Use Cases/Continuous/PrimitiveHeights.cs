using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Generate & control the height of primitives when attached to a null object
/// Written by Garrett Flynn (12/12/19)
/// </summary>


public class PrimitiveScale : MonoBehaviour
{
    public static BandsInlet inlet3; // current inlet type
    public GameObject _sampleCubePrefab;
    public double _maxScale = 1;
    GameObject[] _sampleCube = new GameObject[125];
    double[] fullSample;
    double currentSample;
    int numFFTs = 5; // number of signals
    Color[] colors = new Color[5];

    // Start is called before the first frame update
    void Start()
    {

        colors[0] = new Color(146 / 288f, 155 / 288f, 180 / 288f, 1);
        colors[1] = new Color(172 / 288f, 148 / 288f, 188 / 288f, 1);
        colors[2] = new Color(132 / 288f, 164 / 288f, 156 / 288f, 1);
        colors[3] = new Color(228 / 288f, 204 / 288f, 108 / 288f, 1);
        colors[4] = new Color(236 / 288f, 133 / 288f, 124 / 288f, 1);

        inlet3 = FindObjectOfType<BandsInlet>();

        for (int i = 0; i < numFFTs; i++)
        {
            GameObject _instanceSampleCube = GameObject.CreatePrimitive(PrimitiveType.Cube); // type of primitive
            _instanceSampleCube.transform.position = this.transform.position;
            var cubeRenderer = _instanceSampleCube.GetComponent<Renderer>();
            cubeRenderer.material.color = colors[i % 5];
            cubeRenderer.material.SetColor("_EmissionColor", colors[i % 5]);
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            _instanceSampleCube.transform.position = new Vector3(-25+(10 * i), 0, (25 - (10 * i)));
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inlet3.Bands != null)
        {
            fullSample = inlet3.Bands;
        }

        for (int i = 0; i < _sampleCube.Length; i++)
        {
            if (_sampleCube[i] != null)
            {
                if (i < fullSample.Length)
                {
                    currentSample = fullSample[i];
                }
                else
                {
                    currentSample = 0;
                }
                var height = currentSample * _maxScale + 2;
                _sampleCube[i].transform.localScale = new Vector3(10, (float)height, 10); // control y-scale
            }
        }
    }
}

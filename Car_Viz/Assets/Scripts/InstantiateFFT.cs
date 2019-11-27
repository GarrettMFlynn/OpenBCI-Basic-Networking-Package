using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InstantiateFFT : MonoBehaviour
{
    public static FFTInlet inlet1;
    public GameObject _sampleCubePrefab;
    public float _maxScale = 1000;
    GameObject[] _sampleCube = new GameObject[125];
    float[] fullSample;
    float currentSample;
    int numFFTs = 125;
    Color[] colors = new Color[5];

    // Start is called before the first frame update
    void Start()
    { 

        colors[0] = new Color(146 / 288f, 155 / 288f, 180 / 288f, 1);
        colors[1] = new Color(172 / 288f, 148 / 288f, 188 / 288f, 1);
        colors[2] = new Color(132 / 288f, 164 / 288f, 156 / 288f, 1);
        colors[3] = new Color(228 / 288f, 204 / 288f, 108 / 288f, 1);
        colors[4] = new Color(236 / 288f, 133 / 288f, 124 / 288f, 1);

        inlet1 = FindObjectOfType<FFTInlet>();

        for (int i = 0; i < numFFTs; i++)
        {
            GameObject _instanceSampleCube = GameObject.CreatePrimitive(PrimitiveType.Sphere);//(GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            var cubeRenderer = _instanceSampleCube.GetComponent<Renderer>();
            cubeRenderer.material.color = colors[i%5];
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -(360 / numFFTs) * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inlet1.FFT != null)
        {
            fullSample = inlet1.FFT;
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
                    _sampleCube[i].transform.localScale = new Vector3(10, currentSample*_maxScale + 2, 10);
            }
        }
    }
}

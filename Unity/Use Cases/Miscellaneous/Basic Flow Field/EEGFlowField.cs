using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NoiseFlowField))]

public class EEGFlowField : MonoBehaviour
{
    NoiseFlowField _noiseFlowField;
    public BandsInlet inletB;
    public FocusInlet inletF;
    public FFTInlet inletFFT;
    [Header("Speed")]
    public bool _useSpeed;
    public Vector2 _moveSpeedMinMax, _rotateSpeedMinMax;
    [Header("Scale")]
    public bool _useScale;
    public Vector2 _scaleMinMax;
    [Header("Material")]
    public Material _material;
    private Material[] _eegMaterial;
    private Color[] _color1;
    public bool _useColor1;
    [Range(0f,1f)]
    public float _colorThreshold1;
    public float _colorMultiplier1;
    public string _colorName1;
    public Gradient _gradient1;
    private Color[] _color2;
    public bool _useColor2;
    [Range(0f, 1f)]
    public float _colorThreshold2;
    public float _colorMultiplier2;
    public string _colorName2;
    public Gradient _gradient2;



    // Start is called before the first frame update
    void Start()
    {
        _noiseFlowField = GetComponent<NoiseFlowField>();

        inletF = FindObjectOfType<FocusInlet>();
        inletFFT = FindObjectOfType<FFTInlet>();
        inletB = FindObjectOfType<BandsInlet>();
         
        _eegMaterial = new Material[5];
        _color1 = new Color[5];
        _color2 = new Color[5];
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i);
            _color1[i] = _gradient1.Evaluate((1f / 5f) * (float)i);
            _color2[i] = _gradient2.Evaluate((1f / 5f) * (float)i);
            _eegMaterial[i] = new Material(_material);
            Debug.Log(_color1[i]);
            Debug.Log(_eegMaterial[i]);
        }

        int countBands = 0;
        for (int i = 0; i < _noiseFlowField._amountOfParticles; i++)
        {
            int band = countBands%5;
            _noiseFlowField._particleMeshRenderer[i].material = _eegMaterial[band];
            _noiseFlowField._particles[i]._eegBand = band;
            countBands++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_useSpeed)
        {
            int num = inletF.Focus[0];

            _noiseFlowField._particleMoveSpeed = Mathf.Lerp(_moveSpeedMinMax.x, _moveSpeedMinMax.y, num);
            _noiseFlowField._particleRotateSpeed = Mathf.Lerp(_rotateSpeedMinMax.x, _rotateSpeedMinMax.y, num);
        }

        for (int i = 0; i < _noiseFlowField._amountOfParticles; i++)
        {
            if (_useScale)
            {
                
                float scale = Mathf.Lerp(_scaleMinMax.x, _scaleMinMax.y, (float)inletB.Bands[_noiseFlowField._particles[i]._eegBand]);
                _noiseFlowField._particles[i].transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        for (int i = 0; i < 5; i++)
        {
            float value = (float)inletB.Bands[i];
            if (_useColor1)
            {
                if (value > _colorThreshold1)
                {
                    Debug.Log("adding color");
                    _eegMaterial[i].SetColor(_colorName1, _color1[i] * value * _colorMultiplier1);
                }
                else
                {
                    _eegMaterial[i].SetColor(_colorName1, _color1[i] * 0f);
                }
            }
            if (_useColor2)
            { 
                if (value > _colorThreshold1)
                {
                    _eegMaterial[i].SetColor(_colorName2, _color2[i] * value * _colorMultiplier2);
                }
                else
                {
                    _eegMaterial[i].SetColor(_colorName2, _color2[i] * 0f);
                }
            }
        }
    }
}

using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts.AbstractInlets;

/// <summary>
/// An inlet to send Fast Fourier Transform data as a float
/// Written by Garrett Flynn (12/12/19)
/// Adapted from and dependent on LSL4Unity
/// </summary>

/// <remarks>
/// HOW TO ADD THIS LSL STREAM TO UNITY
/// 1. Make sure LSL4Unity is in your assets folder
/// 2. Make sure an LSL stream on the OpenBCI GUI is set to FFT
/// 3. Set '# Chan' to 125
/// 4. Drag this script onto the desired Unity object
/// 5. Set the correct stream name (e.g. obci_eeg1) in the Inspector
/// 6. Use FFTInlet in other scripts applied to this object!
/// 
/// USAGE
/// public static FFTInlet inlet;
///void Start(){ 
///   inlet = FindObjectOfType<FFTInlet>();
///}
/// </remarks>

public class FFTInlet : AFloatInlet
{
    public float[] FFT;

    protected override void Process(float[] newSample, double timeStamp)
    {
        FFT = newSample;

        Debug.Log(
            string.Format("Got {0} samples at {1}", FFT.Length, timeStamp)
            );
    }
}
using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts.AbstractInlets;

/// <summary>
/// Just an example implementation for a Inlet recieving float values
/// </summary>
public class FFTInlet : AFloatInlet
{
    public float[] FFT;

    protected override void Process(float[] newSample, double timeStamp)
    {
        // just as an example, make a string out of all channel values of this sample
        FFT = newSample;

        Debug.Log(
            string.Format("Got {0} samples at {1}", FFT.Length, timeStamp)
            );
    }
}
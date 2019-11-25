using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts.AbstractInlets;

    /// <summary>
    /// Just an example implementation for a Inlet recieving float values
    /// </summary>
    public class BandsInlet : ADoubleInlet
    {
        public double[] Bands;

        protected override void Process(double[] newSample, double timeStamp)
        {
            // just as an example, make a string out of all channel values of this sample
            Bands = newSample;

            Debug.Log(
                string.Format("Got {0} samples at {1}", Bands.Length, timeStamp)
                );
        }
    }
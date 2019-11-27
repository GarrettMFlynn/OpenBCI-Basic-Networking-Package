using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts.AbstractInlets;

    /// <summary>
    /// Just an example implementation for a Inlet recieving float values
    /// </summary>
    public class FocusInlet : AIntInlet
    {
        public int[] Focus;

        protected override void Process(int[] newSample, double timeStamp)
        {
            // just as an example, make a string out of all channel values of this sample
            Focus = newSample;

            Debug.Log(
                string.Format("Got 1 samples at {0}", timeStamp)
                );
        }
    }
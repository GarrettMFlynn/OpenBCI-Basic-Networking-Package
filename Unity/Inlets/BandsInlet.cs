using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts.AbstractInlets;

/// <summary>
/// An inlet to send band data as a double
/// Written by Garrett Flynn (12/12/19)
/// Adapted from and dependent on LSL4Unity
/// </summary>

/// <remarks>
/// HOW TO ADD THIS LSL STREAM TO UNITY
/// 1. Make sure LSL4Unity is in your assets folder
/// 2. Make sure an LSL stream on the OpenBCI GUI is set to BandPower
/// 3. Set '# Chan' to 5
/// 4. Drag this script onto the desired Unity object
/// 5. Set the correct stream name (e.g. obci_eeg1) in the Inspector
/// 6. Use BandInlet in other scripts applied to this object!
/// 
/// USAGE
/// public static BandsInlet inlet;
///void Start(){ 
///   inlet = FindObjectOfType<BandsInlet>();
///}
/// </remarks>


public class BandsInlet : ADoubleInlet
    {
        public double[] Bands;

        protected override void Process(double[] newSample, double timeStamp)
        {
            Bands = newSample;

            Debug.Log(
                string.Format("Got {0} samples at {1}", Bands.Length, timeStamp)
                );
        }
    }
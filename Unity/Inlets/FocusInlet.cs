using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts.AbstractInlets;

/// <summary>
/// An inlet to send Focus data as an integer
/// Written by Garrett Flynn (12/12/19)
/// Adapted from and dependent on LSL4Unity
/// </summary>

/// <remarks>
/// HOW TO ADD THIS LSL STREAM TO UNITY
/// 1. Make sure LSL4Unity is in your assets folder
/// 2. Make sure an LSL stream on the OpenBCI GUI is set to Focus
/// 3. Set '# Chan' to 1
/// 4. Drag this script onto the desired Unity object
/// 5. Set the correct stream name (e.g. obci_eeg1) in the Inspector
/// 6. Use FocusInlet in other scripts applied to this object!
/// 
/// USAGE
/// public static FocusInlet inlet;
///void Start(){ 
///   inlet = FindObjectOfType<FocusInlet>();
///}
/// </remarks>
public class FocusInlet : AIntInlet
    {
        public int[] Focus;

        protected override void Process(int[] newSample, double timeStamp)
        {
            Focus = newSample;

            Debug.Log(
                string.Format("Got 1 samples at {0}", timeStamp)
                );
        }
    }
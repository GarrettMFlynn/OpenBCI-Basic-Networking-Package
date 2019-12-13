using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusForward : MonoBehaviour{
    public static FocusInlet inlet2;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        inlet2 = FindObjectOfType<FocusInlet>();   
    }

    // Update is called once per frame
    void Update()
    {
        float MoveForward = 0;

        // Move the vehicle forward
        if (inlet2.Focus.Length > 0)
            MoveForward = inlet2.Focus[0];

        Vector3 movement = new Vector3 (0.0f, 0.0f, MoveForward);
        transform.Translate(movement * Time.deltaTime * speed);
        
    }
}

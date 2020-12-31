using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewind : MonoBehaviour
{
    public bool isRewinding = false;

    public Text text;

    List<Vector3> positions;

    // can add visible UI that it is rewinding

    void Start()
    {
        positions = new List<Vector3>(); // different positions in point of time
        text.enabled = false;
    }

    void FixedUpdate()
    {
        if(isRewinding)
            ActionRewind();
        else
            Record();
    }

    void ActionRewind()
    {
        if(positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }

        
    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            StartRewind();
        if(Input.GetKeyUp(KeyCode.Return))
            StopRewind();
    }

    public void StartRewind()
    {
        isRewinding = true;
        text.enabled = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        text.enabled = false;
    }
}

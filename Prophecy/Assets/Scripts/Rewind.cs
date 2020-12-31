using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewind : MonoBehaviour
{
    public bool isRewinding = false;

    private AudioSource slowmo;

    // private int coolDownTime;
    // private int tracker;

    public Text text;

    public Text coolDownText;

    List<Vector3> positions;

    // can add visible UI that it is rewinding

    void Start()
    {
        positions = new List<Vector3>(); // different positions in point of time
        // coolDownTime = 5;
        // tracker = 5;
        // coolDownText.text = "Cooldown Time: " + tracker;
        text.enabled = false;

        slowmo = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            ActionRewind();
        else
            Record();
    }

    void ActionRewind()
    {
        if (positions.Count > 0)
        {
            // tracker -= (int)Time.deltaTime;
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


        if (Input.GetKeyDown(KeyCode.Return))
        {
            // coolDownTime -= (int)Time.deltaTime;

            
            StartRewind();
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
            // if(coolDownTime < 5)
            // {
            //     coolDownTime += (int)Time.deltaTime;
            //     tracker++;
            // }
        }

        //  coolDownText.text = "Cooldown Time: " + tracker;
    }

    public void StartRewind()
    {
        slowmo.Play();
        isRewinding = true;
        text.enabled = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        text.enabled = false;
    }
}

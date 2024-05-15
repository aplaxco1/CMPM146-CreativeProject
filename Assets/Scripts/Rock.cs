using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    public enum rockStates {
        happy,
        sad
    }

    public rockStates currState = rockStates.sad;

    private float sadTimer = 3f;
    private float movement = 0.5f;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        switch(currState) {
            case rockStates.happy:
                Debug.Log("Rock is Happy!");
                sadTimer -= Time.deltaTime;
                if (sadTimer <= 0) {
                    currState = rockStates.sad;
                }
                happyAnim();
                break;
            case rockStates.sad:
                Debug.Log("Rock is Sad!");
                sadTimer = 3f;
                break;
            default:
                Debug.Log("No State!");
                break;
        }
        
    }

    void OnMouseDown() {
        currState = rockStates.happy;
    }

    void happyAnim() {
        if (transform.position.x >= 4f) {
            movement = -0.05f;
        }
        else if (transform.position.x <= -4f) {
            movement = 0.05f;
        }
        transform.position = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
    }
}

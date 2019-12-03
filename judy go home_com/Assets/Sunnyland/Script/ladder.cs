using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ladder : MonoBehaviour {
    public float speed = 0.5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "player" && Input.GetKey(KeyCode.UpArrow))

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        else if (other.tag == "player" && Input.GetKey(KeyCode.DownArrow))
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        else
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}

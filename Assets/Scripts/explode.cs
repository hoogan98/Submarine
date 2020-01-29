using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {

    public float hangTime;

	void Start () {
		
	}
	
	void Update () {
        hangTime -= Time.deltaTime;

        if (hangTime <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Obstacle"))
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}

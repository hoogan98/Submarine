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
        if (collision.CompareTag("Player"))
        {
            s1 P1 = collision.GetComponent<s1>();
            s2 P2 = collision.GetComponent<s2>();

            if (P1 != null)
            {
                P1.Die();
            }
            else
            {
                P2.Die();
            }

        }
        else if (!collision.CompareTag("Obstacle"))
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}

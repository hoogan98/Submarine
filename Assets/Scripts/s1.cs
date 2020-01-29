using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1 : MonoBehaviour {

    private float engSpeed;
    private float cool;
    private float sonCool;

    public float vel;
    public float speed;
    public float maxSpeed;
    public float maxVel;
    public float drag;
    public float turnSpeed;
    public float fireCooldown;
    public float sonarCooldown;

    public Transform torpedo;
    public Transform sonar;

	// Use this for initialization
	void Start () {
        vel = 0;
        cool = fireCooldown;
        sonCool = sonarCooldown;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W) && engSpeed + speed <= maxSpeed)
        {
            engSpeed += speed;
        } else if (Input.GetKeyDown(KeyCode.S) && engSpeed - speed >= -maxSpeed)
        {
            engSpeed -= speed;
        } else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            engSpeed = 0;
        }

        vel += engSpeed;
        if (engSpeed == 0)
        {
            vel -= drag;
        }

        if (vel < 0)
        {
            vel = 0;
        }
        if (vel > maxVel)
        {
            vel = maxVel;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.forward, -turnSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.forward, turnSpeed);
        }

        if (cool > 0)
        {
            cool -= Time.deltaTime;
        } else
        {
            cool = 0;
        }
        if (sonCool > 0)
        {
            sonCool -= Time.deltaTime;
        }
        else
        {
            sonCool = 0;
        }

        if (Input.GetKeyDown(KeyCode.Q) && cool == 0)
        {
            Object.Instantiate(torpedo, this.transform.position, this.transform.rotation);
            cool = fireCooldown;
        }
        if (Input.GetKeyDown(KeyCode.E) && sonCool == 0)
        {
            Object.Instantiate(sonar, this.transform.position, this.transform.rotation);
            sonCool = sonarCooldown;
        }
        
        this.transform.Translate(new Vector3(0, vel, 0));
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            collision.GetComponent<torpFly>().isLethal = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Debris"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Die()
    {

    }

}

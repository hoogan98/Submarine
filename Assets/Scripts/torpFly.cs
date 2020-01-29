using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpFly : MonoBehaviour {

    private float vel;

    public float speedScale;
    public float maxSpeed;
    public float subMaxSpeed;
    public bool isLethal;
    public int fireDistance;
    public Transform explosion;

	void Start () {
        vel = subMaxSpeed;
        transform.Translate(new Vector3(0, fireDistance, 0));
	}
	
	// Update is called once per frame
	void Update () {
        if (vel < maxSpeed)
        {
            vel += speedScale;
        }

        this.transform.Translate(new Vector3(0, vel, 0));
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isLethal && !other.CompareTag("Wave"))
        {
            GameObject.Instantiate(explosion, this.transform.position, this.transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }

}

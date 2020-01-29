using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonarScan : MonoBehaviour {

    private float currentTime;

    public float hangTime;
    public float incScale;
    public int iterations;

	// Use this for initialization
	void Start () {
        currentTime = hangTime;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            if (iterations != 0)
            {
                this.transform.localScale = this.transform.localScale * incScale;
                iterations--;
                currentTime = hangTime;
            } else
            {
                GameObject.Destroy(this.gameObject);
            }

        }
	}
}

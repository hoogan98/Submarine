using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScan : MonoBehaviour {

    public float visibleTime;
    private float vTime;

	// Use this for initialization
	void Start () {
        vTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (vTime > 0)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            vTime -= Time.deltaTime;
        } else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
	}

    public void Scanned()
    {
        vTime = visibleTime;
    }
}

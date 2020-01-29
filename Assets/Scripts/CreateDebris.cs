using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDebris : MonoBehaviour {

    private float debNum;
    private float debCount;
    private float lmax;
    private float rmax;
    private float tmax;
    private float bmax;
    private Vector3 siz;
    private int clumpCount;
    private Vector3 debSize;

    public Transform debris;
    public int debMax;
    public int clumpScaleMax;
    public int clumpSpacing;
    public float cubeScaleMin;
    public float cubeScaleMax;

	// Use this for initialization
	void Start () {
        debNum = Random.Range(0, debMax);
        Debug.Log(debNum);
        debCount = debNum;
        clumpCount = (int) Random.Range(0, debNum / Random.Range(1, clumpScaleMax));
        Debug.Log(clumpCount);
        siz = this.gameObject.GetComponent<SpriteRenderer>().bounds.size;
        debSize = debris.gameObject.GetComponent<SpriteRenderer>().bounds.size;
        lmax = -siz.x / 2;
        rmax = -lmax;
        tmax = siz.y / 2;
        bmax = -tmax;

        while (clumpCount > 0)
        {
            float x = Random.Range(lmax, rmax);
            float y = Random.Range(tmax, bmax);

            Transform center = GameObject.Instantiate(debris, new Vector3(x, y, 0), this.transform.rotation, this.transform);
            float scale = Random.Range(cubeScaleMin, cubeScaleMax);
            center.localScale = new Vector3(scale, scale * (siz.x / siz.y), 0);
            debCount--;

            float clumpSize = debCount / Random.Range(1, clumpCount);
            float xSpace = Random.Range(0.5f, clumpSpacing);
            float ySpace = Random.Range(0.5f, clumpSpacing);
            for (int j = 0; j < clumpSize; j++)
            {

                x = Random.Range(-debSize.x * xSpace, debSize.x * xSpace);
                y = Random.Range(-debSize.y * ySpace, debSize.y * ySpace);
                Transform clumpBoi = GameObject.Instantiate(debris, new Vector3(center.position.x + x, center.position.y + y, 0), this.transform.rotation, center.transform);
                float newScale = (clumpBoi.transform.localScale.x) / (Mathf.Abs(x/2) + Mathf.Abs(y/2) + 1);
                if (newScale < (clumpBoi.transform.localScale.x / 10))
                {
                    newScale = clumpBoi.transform.localScale.x / 10;
                }

                clumpBoi.localScale = new Vector3(newScale, newScale, 0);
                debCount--;
            }

            clumpCount--;
        }

        for (int i = 0; i < debCount; i++)
        {
            float x = Random.Range(lmax, rmax);
            float y = Random.Range(tmax, bmax);

            GameObject.Instantiate(debris, new Vector3(x, y, 0), this.transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

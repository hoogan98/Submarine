using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupZones : MonoBehaviour {
    public GameObject player;
    public GameObject text;

    private void OnMouseDown()
    {
        Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 start = new Vector3(ray.x, ray.y, 0);
        GameObject.Instantiate(player, start, new Quaternion(0,0,0,0));
        Destroy(text);
        Destroy(this.gameObject);
    }
}

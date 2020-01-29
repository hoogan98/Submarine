using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlipScan : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Projectile"))
        {
            collision.GetComponent<OnScan>().Scanned();
        }
        if (collision.CompareTag("Debris"))
        {
            Destroy(this.gameObject);
        }
    }
}

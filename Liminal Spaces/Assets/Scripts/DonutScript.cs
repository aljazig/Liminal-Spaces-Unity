using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutScript : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider other) {
        if (other == player.GetComponent<Collider>()) {
            Destroy(this.gameObject);
        }
    }
}

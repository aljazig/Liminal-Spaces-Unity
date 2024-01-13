using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DonutScript : MonoBehaviour
{
    public GameObject player;
    public int points = 0;

    void OnTriggerEnter(Collider other) {
        if (other == player.GetComponent<Collider>()) {
            points += 1;
            Destroy(this.gameObject);
        }
    }
}

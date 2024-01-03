using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HallwayExit : MonoBehaviour
{
    public int trigger;
    public GameObject player;
    public Vector3 startPoint;
    public Vector3 endPoint;

    private void OnTriggerEnter(Collider other) {
        if (other = player.GetComponent<Collider>()) {
            if (trigger == 0) {
                GameObject exit = this.transform.parent.GetChild(1).gameObject;
                exit.GetComponent<Collider>().isTrigger = false;
                exit.GetComponent<Collider>().enabled = false;
            }
            if (trigger == 2) {
                player.transform.position = new Vector3(player.transform.position.x - endPoint.x, player.transform.position.y - endPoint.y, 0) + startPoint;
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("hallway")) {
                    Destroy(obj);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other = player.GetComponent<Collider>()) {
            if (trigger == 1) {
                GameObject exit = this.transform.parent.GetChild(1).gameObject;
                exit.GetComponent<Collider>().isTrigger = true;
                exit.GetComponent<Collider>().enabled = true;
            }
        }
    }
}

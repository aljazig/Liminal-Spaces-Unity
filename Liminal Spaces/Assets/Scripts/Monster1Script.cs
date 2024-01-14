using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Monster1Script : MonoBehaviour
{
    public GameObject player;
    private Boolean chase = false;
    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        float dist = Vector3.Distance(transform.position, target);
        Debug.DrawLine(transform.position, target);
        RaycastHit hit;
        if (Physics.Linecast(transform.position, target, out hit, LayerMask.GetMask("Default"))) {
            if (hit.transform.name == "Player") {
                Debug.Log(dist);
                if (dist <= 10) {
                    chase = true;
                }
            }
        }

        if (chase) {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            Debug.Log("Death");
        }
    }
}

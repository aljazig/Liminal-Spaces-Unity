using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore;

public class Pathfinding : MonoBehaviour
{
    public GameObject player;
    public Transform[] points;

    private NavMeshAgent nav;
    private int destPoint;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.updatePosition = false;
        nav.updateRotation = false;
    }

    void Update() {
        //Vector3 targetVel = (nav.nextPosition = transform.position) / Time.deltaTime;
        Quaternion lookDirection = Quaternion.LookRotation(transform.position - nav.nextPosition);
        transform.position = nav.nextPosition;
        transform.rotation = Quaternion.Euler(-15, lookDirection.eulerAngles.y, lookDirection.eulerAngles.z);

        Vector3 target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        float angle = Vector3.Angle(target - transform.position, -transform.forward);
        RaycastHit hit;
        if (Physics.Linecast(transform.position, target, out hit, LayerMask.GetMask("Default"))) {
            if (hit.transform.name == "Player") {
                if (angle <= 45) {
                    nav.destination = target;
                    nav.speed = 10;
                }
            }
        }
    }

    void FixedUpdate() {
        if (!nav.pathPending && nav.remainingDistance < 0.2f) {
            GoToNextPoint();
        }
    }

    void GoToNextPoint() {
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}

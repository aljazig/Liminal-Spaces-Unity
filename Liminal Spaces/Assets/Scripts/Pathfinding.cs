using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore;

public class Pathfinding : MonoBehaviour
{
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
    }

    void FixedUpdate() {
        if (!nav.pathPending && nav.remainingDistance < 0.5f) {
            GoToNextPoint();
        }
    }

    void GoToNextPoint() {
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}

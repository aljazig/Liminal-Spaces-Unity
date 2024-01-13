using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 5.0f;
    private Vector2 turn;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate() {
        var x = Input.GetAxis("Horizontal");
        turn.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        var z = Input.GetAxis("Vertical");
        turn.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

        turn.y = Mathf.Clamp(turn.y, -80, 80);

        Rigidbody rg = gameObject.GetComponent<Rigidbody>();
        GameObject cam = gameObject.transform.GetChild(0).gameObject;

        Vector3 vel = (speed * z * -transform.forward) + (speed * x * -transform.right);
        rg.velocity = vel;

        Vector3 rot = new(0, turn.x, 0);
        Vector3 rotCam = new(-turn.y, -180, 0);
        //rotCam.x = Mathf.Clamp(rotCam.x, -80, 80);
        transform.localRotation = Quaternion.Euler(rot);
        cam.transform.localRotation = Quaternion.Euler(rotCam);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "donut") {
            Destroy(other.transform.root.gameObject);
        }
    }
}

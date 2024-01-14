using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.PlasticSCM.Editor.WebApi;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float runSpeed = 10.0f;
    public float mouseSensitivity = 5.0f;
    public GameObject donutText;
    public GameObject[] teleportPoints;

    private Vector2 turn;
    private float currentSpeed = 5.0f;
    TextMeshProUGUI txt;
    GameObject donutCheck;
    int points = 0;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        txt = donutText.GetComponent<TextMeshProUGUI>();
        txt.text = "Donut count: 0";
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            currentSpeed = runSpeed;
        } else {
            currentSpeed = speed;
        }

        var x = Input.GetAxis("Horizontal");
        turn.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        var z = Input.GetAxis("Vertical");
        turn.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

        turn.y = Mathf.Clamp(turn.y, -80, 80);

        Rigidbody rg = gameObject.GetComponent<Rigidbody>();
        GameObject cam = gameObject.transform.GetChild(0).gameObject;

        Vector3 vel = (currentSpeed * z * -transform.forward) + (currentSpeed * x * -transform.right);
        rg.velocity = vel;

        Vector3 rot = new(0, turn.x, 0);
        Vector3 rotCam = new(-turn.y, -180, 0);
        transform.localRotation = Quaternion.Euler(rot);
        cam.transform.localRotation = Quaternion.Euler(rotCam);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "donut") {
            if (donutCheck != other.transform.root.gameObject) {
                points += 1;
                txt.text = "Donut count: " + points;
                PickedUpADonut();
                donutCheck = other.transform.root.gameObject;
            }
            Destroy(other.transform.root.gameObject);
        }
        if (other.gameObject.name == "WinTrigger") {
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.tag == "Enemy") {
            SceneManager.LoadScene(3);
        }
    }

    void PickedUpADonut() {
        int rn = UnityEngine.Random.Range(0, 2);
        Debug.Log(teleportPoints.Length);
        if (rn >= 0.5) {
            RandomTeleport();
        } else {
            speed += 1;
        }
    }

    void RandomTeleport() {
        int randPoint = UnityEngine.Random.Range(0, teleportPoints.Length);
        transform.position = teleportPoints[randPoint].transform.position;
    }
}

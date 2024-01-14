using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DrawGraphity : MonoBehaviour
{
    public GameObject[] graphity = new GameObject[3];
    public Canvas canvas;
    int currentGrp;
    UnityEngine.UI.Image[] canvasImgs;

    // Start is called before the first frame update
    void Start()
    {
        currentGrp = 0;
        canvasImgs = canvas.GetComponentsInChildren<UnityEngine.UI.Image>();
    }

    float mod(float a, float b)
    {
        return a - (b * (float)Math.Floor(a / b));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < canvasImgs.Length; i++) {
            if (i == currentGrp) {
                canvasImgs[i].color = new Color32(220, 220, 220, 255);
            } else {
                canvasImgs[i].color = new Color32(115, 115, 115, 255);
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward));
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2.0f)) {
                if (hit.transform.gameObject.name != "Player") {
                    Quaternion gRot = Quaternion.Euler(new Vector3(0, 0, 0));
                    GameObject gObj = Instantiate(graphity[currentGrp], hit.point + (hit.normal * 0.01f), gRot);
                    gObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                }
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            currentGrp = (int)mod(currentGrp + 1, 3f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            currentGrp = (int)mod(currentGrp - 1, 3f);
        }
    }
}

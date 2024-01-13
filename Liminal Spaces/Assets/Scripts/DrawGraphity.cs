using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGraphity : MonoBehaviour
{
    public GameObject[] graphity = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward));
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.gameObject.name != "Player") {
                    Quaternion gRot = Quaternion.Euler(new Vector3(0, 0, 0));
                    GameObject gObj = Instantiate(graphity[0], hit.point + (hit.normal * 0.01f), gRot);
                    gObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                }
            }
        }
    }
}

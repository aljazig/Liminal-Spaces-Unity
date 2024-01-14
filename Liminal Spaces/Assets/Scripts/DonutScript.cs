using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DonutScript : MonoBehaviour
{
    public GameObject player;
    public GameObject donutText;
    
    TextMeshProUGUI txt;
    int points = 0;


    void Start() {
        txt = donutText.GetComponent<TextMeshProUGUI>();
        txt.text = "Donut count: 0";
        Debug.Log(this.gameObject.name);
    }

    void OnTriggerEnter(Collider other) {
        if (other == player.GetComponent<Collider>()) {
            points += 1;
            txt.SetText("Donut count: " + points);
            Destroy(this.gameObject);
        }
    }
}

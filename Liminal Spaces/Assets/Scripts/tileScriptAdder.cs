using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScriptAdder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject lab = GameObject.Find("LAbirintMain");
        foreach (Renderer rnd in lab.GetComponentsInChildren<Renderer>()) {
            GameObject obj = rnd.gameObject;
            obj.AddComponent<TileMaterials>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileMaterials : MonoBehaviour
{
    [SerializeField] private float tileX = 1;
    [SerializeField] private float tileY = 1;
    [SerializeField] private Vector3 meshSize = new Vector3(0, 0, 0);
    Mesh mesh;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mesh = GetComponent<MeshFilter>().mesh;
        meshSize = GetComponent<Renderer>().localBounds.size;
        if (meshSize.x >= 1.1) {
            if (meshSize.x < meshSize.y) {
                tileX = meshSize.x / meshSize.y;
                tileY = 1;
            } else if (meshSize.x > meshSize.y) {
                tileY = meshSize.y / meshSize.x;
                tileX = 1;
            } else {
                tileY = 1;
                tileX = 1;
            }
        } else if (meshSize.z >= 1.1) {
            if (meshSize.z < meshSize.y) {
                tileX = meshSize.z / meshSize.y;
                tileY = 1;
            } else if (meshSize.z > meshSize.y) {
                tileY = meshSize.y / meshSize.z;
                tileX = 1;
            } else {
                tileY = 1;
                tileX = 1;
            }
        }
    }

    void Update()
    {
        mat.mainTextureScale = new Vector2(tileX, tileY);
        //mat.mainTextureScale = new Vector2(mesh.bounds.size.x * transform.localScale.x / 100 * tileX, mesh.bounds.size.y * transform.localScale.y / 100 * tileY);
    }
}

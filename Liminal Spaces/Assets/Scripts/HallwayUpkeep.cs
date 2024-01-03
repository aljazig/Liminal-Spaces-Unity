using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayUpkeep : MonoBehaviour
{
    public GameObject hallControl;
    public GameObject player;
    public Vector3 offset;
    public Vector3 oscilation;

    private void OnTriggerEnter(Collider other) {
        if (other = player.GetComponent<Collider>()) {
            Vector3 betterOffset = offset + oscilation;
            GameObject newControl = Instantiate(hallControl, hallControl.transform.position + betterOffset, hallControl.transform.rotation);
            newControl.GetComponentInChildren<HallwayUpkeep>().oscilation = new Vector3(-oscilation.x, -oscilation.y, -oscilation.z);
            Destroy(this.gameObject);
        }
    }
}

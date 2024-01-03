using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndlessHallwayTP : MonoBehaviour
{
    public GameObject player;
    public GameObject[] walls = new GameObject[4];
    public Vector3 hallwayPosition;

    private Collider playerCol;

    void Start() {
        playerCol = player.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other) {
        if (other == playerCol) {
            Vector3 tempPos = player.transform.position;
            player.transform.position = hallwayPosition;
            GameObject hallControl = new("hallControl");
            hallControl.transform.position = tempPos;
            for (int i = 0; i < walls.Length; i++) {
                GameObject tempWall = Instantiate(walls[i], walls[i].transform.position, walls[i].transform.rotation);
                tempWall.transform.parent = hallControl.transform;
            }
            GameObject hallExit = MakeExit(tempPos + new Vector3(0, 0, -2), hallwayPosition);
            GameObject hallUpkeep = MakeUpkeep(new Vector3(0, 0, 25), new Vector3(0.0001f, 0.0001f, 0), hallControl, tempPos + new Vector3(0, 0, 6));

            hallUpkeep.transform.parent = hallControl.transform;
            hallExit.transform.parent = hallControl.transform;

            hallControl.transform.position = hallwayPosition;
            hallControl.tag = "hallway";
        }
    }


    GameObject MakeExit(Vector3 pos, Vector3 endPos) {
        GameObject hallExit = new("exit");
        hallExit.transform.position = this.transform.position;

        GameObject exitDisable = Instantiate(this.gameObject);
        exitDisable.transform.localScale = exitDisable.transform.localScale + new Vector3(0, 0, -0.6f);
        exitDisable.transform.position = exitDisable.transform.position + new Vector3(0, 0, -0.3f);
        Destroy(exitDisable.GetComponent<EndlessHallwayTP>());
        exitDisable.AddComponent<HallwayExit>().trigger = 0;
        exitDisable.GetComponent<HallwayExit>().player = player;
        exitDisable.transform.parent = hallExit.transform;

        GameObject exit = Instantiate(this.gameObject);
        exit.transform.localScale = exit.transform.localScale + new Vector3(0, 0, -0.6f);
        Destroy(exit.GetComponent<EndlessHallwayTP>());
        exit.AddComponent<HallwayExit>().trigger = 2;
        exit.GetComponent<HallwayExit>().startPoint = pos;
        exit.GetComponent<HallwayExit>().endPoint = endPos;
        exit.GetComponent<HallwayExit>().player = player;
        exit.transform.parent = hallExit.transform;

        GameObject exitEnable = Instantiate(this.gameObject);
        exitEnable.transform.localScale = exitEnable.transform.localScale + new Vector3(0, 0, -0.6f);
        exitEnable.transform.position = exitEnable.transform.position + new Vector3(0, 0, 0.3f);
        Destroy(exitEnable.GetComponent<EndlessHallwayTP>());
        exitEnable.AddComponent<HallwayExit>().trigger = 1;
        exitEnable.GetComponent<HallwayExit>().player = player;
        exitEnable.transform.parent = hallExit.transform;

        hallExit.transform.position = pos;

        return hallExit;
    }

    GameObject MakeUpkeep(Vector3 offset, Vector3 oscilation, GameObject hallControl, Vector3 pos) {
        GameObject hallUpkeep = new("upkeep");
        hallUpkeep.transform.position = this.transform.position;

        GameObject upkeep = Instantiate(this.gameObject);
        Destroy(upkeep.GetComponent<EndlessHallwayTP>());
        upkeep.AddComponent<HallwayUpkeep>().hallControl = hallControl;
        upkeep.GetComponent<HallwayUpkeep>().player = player;
        upkeep.GetComponent<HallwayUpkeep>().offset = offset;
        upkeep.GetComponent<HallwayUpkeep>().oscilation = oscilation;
        upkeep.transform.parent = hallUpkeep.transform;

        hallUpkeep.transform.position = pos;
        return hallUpkeep;
    }
}

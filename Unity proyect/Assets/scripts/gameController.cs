using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
    public playerController player;
    public GameObject Roof;
    public GameObject Ground;
    bool invGravity;

    private void Start()
    {
        invGravity = false;
    }

    public void ChangeGravity()
    {
        invGravity = !invGravity;
        player.ChangeGravity();
        if (invGravity)
        {
            Roof.tag = "Ground";
            Ground.tag = "Bouncer";
        }
        else
        {
            Roof.tag = "Bouncer";
            Ground.tag = "Ground";
        }
    }
}

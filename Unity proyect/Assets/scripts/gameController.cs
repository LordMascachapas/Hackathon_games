using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
    public playerController player;
    public bool invGravity;

    public void ChangeGravity()
    {
        player.ChangeGravity();
    }

    private void Update()
    {
        if (invGravity)
        {
            ChangeGravity();
            invGravity = false;
        }
    }
}

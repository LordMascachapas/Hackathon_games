using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityRing : MonoBehaviour {
    public float speedTranslateX;
    public float maxTranslateX;
    int wayX;
    float marginX;

    private void Awake()
    {
        wayX = 1;
        marginX = transform.position.x;
    }

    private void FixedUpdate()
    {
        if (transform.position.x > maxTranslateX + marginX)
        {
            wayX = -1;
        }
        else if(transform.position.x < marginX)
            wayX = 1;
        transform.position = new Vector3(transform.position.x + (speedTranslateX * Time.deltaTime) * wayX, 0, 0);
    }
}

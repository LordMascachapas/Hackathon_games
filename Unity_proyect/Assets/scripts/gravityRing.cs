using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityRing : MonoBehaviour {
    public gameController gc;
    public Vector3 speedTranslate;
    public Vector3 maxTranslate;
    Vector3 way;
    Vector3 margin;
    bool upReached;
    bool downReached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UpReach();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DownReach();
    }

    public void ChangePolarity()
    {
        transform.Rotate(new Vector3(0, 0, 180));
    }

    private void Awake()
    {
        gc = GameObject.Find("GameController").gameObject.GetComponent<gameController>();
        way = new Vector3(1, 1, 0);
        margin = transform.position;
        upReached = false;
        downReached = false;
    }

    public void UpReach()
    {
        if (!downReached)
            upReached = true;
        else
        {
            upReached = false;
            downReached = false;
        }
    }

    public void DownReach()
    {
        downReached = true;
        if (downReached && upReached)
            AddPoints(1);
    }

    public void AddPoints(int value)
    {
        upReached = false;
        downReached = false;
        gc.SetPoints(gc.GetPoints() + value);
        ChangePolarity();
    }

    private void FixedUpdate()
    {
        if (transform.position.x > maxTranslate.x + margin.x)
        {
            way.x = -1;
        }
        else if(transform.position.x < margin.x)
            way.x = 1;
        if (transform.position.y > maxTranslate.y + margin.y)
        {
            way.y = -1;
        }
        else if (transform.position.y < margin.y)
            way.y = 1;
        transform.position = new Vector3(transform.position.x + (way.x * speedTranslate.x * Time.deltaTime),
                                            transform.position.y + (way.y * speedTranslate.y * Time.deltaTime),
                                            transform.position.z);
    }
}

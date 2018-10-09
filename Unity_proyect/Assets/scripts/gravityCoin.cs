using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityCoin : MonoBehaviour {
    public gameController gc;

    private void Start()
    {
        gc = GameObject.Find("GameController").gameObject.GetComponent<gameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gc.ChangeGravity();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
    public playerController Player;
    public menuController Menu;
    public GameObject Roof;
    public GameObject Ground;
    public GameObject Platforms;
    public GameObject CoinPrefab;
    public float XMaxCoinSpawn;
    public float XMinCoinSpawn;
    public float YMaxCoinSpawn;
    public float YMinCoinSpawn;
    public float timeSpawnForCoin;
    bool invGravity;
    float timeBetweenSpawn;
    bool onPause;
    float timeOnPause;

    public void ChangeGravity()
    {
        invGravity = !invGravity;
        Player.ChangeGravity();
        if (invGravity)
        {
            Roof.tag = "Ground";
            Ground.tag = "Bouncer";
            for (int i = 0; i < Platforms.transform.childCount; i++)
            {
                Platforms.transform.GetChild(i).SetPositionAndRotation(Platforms.transform.GetChild(i).position, Quaternion.Euler(0, 0, 180));
                    Platforms.transform.GetChild(i).Find("Sprites").SetPositionAndRotation(Platforms.transform.GetChild(i).Find("Sprites").position, Quaternion.Euler(0, 0, 0));
            }
        }
        else
        {
            Roof.tag = "Bouncer";
            Ground.tag = "Ground";
            for (int i = 0; i < Platforms.transform.childCount - 1; i++)
            {
                Platforms.transform.GetChild(i).SetPositionAndRotation(Platforms.transform.GetChild(i).position, Quaternion.Euler(0, 0, 0));
                Platforms.transform.GetChild(i).Find("Sprites").SetPositionAndRotation(Platforms.transform.GetChild(i).Find("Sprites").position, Quaternion.Euler(0, 0, 0));
            }
        }
    }

    public void SpawnCoin()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(XMinCoinSpawn, XMaxCoinSpawn), Random.Range(YMinCoinSpawn, YMaxCoinSpawn));
        Instantiate(CoinPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
        timeBetweenSpawn = Time.time;
    }

    public void PauseGame(bool value)
    {
        if (value != onPause)
        {
            Menu.EnableMenu(value);
            if (onPause)
                Time.timeScale = 1;
            else
            {
                Time.timeScale = 0;
            }
            onPause = value;
        }
    }

    private void Awake()
    {
        onPause = false;
        invGravity = false;
        timeBetweenSpawn = -timeSpawnForCoin;
    }

    private void Update()
    {
        if (!onPause)
        {
            if (GameObject.Find("GravityCoin(Clone)") == null && timeBetweenSpawn + timeSpawnForCoin < Time.time)
            {
                SpawnCoin();
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            PauseGame(!onPause);
        }
    }
}

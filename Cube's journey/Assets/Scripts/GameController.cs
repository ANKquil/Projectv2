using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Main
    int cristals = 0;
    public bool active = false;
    public GameObject cristalText;
    public GameObject mainCamera;
    public GameObject player;
    public GameObject level;
    public GameObject back;
    public GameObject canvas;

    Transform transLevel;
    Transform transBack;
    Transform transPlayer;
    PlayerController playerController;
    UIController controllerUI;

    // Prefabs
    public GameObject triggerPrefab;
    public GameObject cristalPrefab;
    public GameObject badCristalPrefab;
    public GameObject treesPrefab;
    public GameObject[] groundsTest;

    // Settings lvl
    public int idBlockNow = 0;
    int lastIdGround = 0;
    int lastId = 0;
    int id;
    int countLastId = 0;
    GameObject block;
    List<GameObject> listAllowGrounds = new List<GameObject>();
    GameObject[] arrGrounds = new GameObject[10];
    Vector3 nextGroundPos = new Vector3(0, 0, 20);

    private void Awake()
    {
        transLevel = level.GetComponent<Transform>();
        transBack = back.GetComponent<Transform>();
        transPlayer = player.GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();
        controllerUI = canvas.GetComponent<UIController>();

        listAllowGrounds.Add(groundsTest[0]);
        listAllowGrounds.Add(groundsTest[1]);
    }

    void Start()
    {
        StartGame();
    }

    
    void Update()
    {
        if (active)
            transBack.position = Vector3.Lerp(transBack.position, new Vector3(0, 0, transPlayer.position.z + 32.5f), Time.fixedDeltaTime * 1);
    }

    public void GameStarted()
    {
        controllerUI.CloseLose();
        controllerUI.CloseMenu();
        controllerUI.OpenGame();
        playerController.active = true;
        active = true;
    }

    public void MenuActive()
    {
        controllerUI.CloseGame();
        controllerUI.CloseLose();
        controllerUI.OpenMenu();
        playerController.active = false;
        transPlayer.position = new Vector3(0, 1, 2.43f);
        Camera.main.GetComponent<CamController>().active = false;
        Camera.main.GetComponent<CamController>().corutine = true;
        Camera.main.GetComponent<Transform>().position = new Vector3(5, 3, 0.75f);
        Camera.main.GetComponent<Transform>().rotation = Quaternion.Euler(15, -75, 0f);
        active = false;
        transBack.position = new Vector3(0, 0, 35);
    }

    public void AddCristal(int num)
    {
        cristals += num;
    }

    public void Dead()
    {
        controllerUI.CloseGame();
        controllerUI.CloseMenu();
        controllerUI.OpenLose();
        playerController.active = false;
        active = false;
    }

    public void TriggerActive()
    {
        int id;

        if (countLastId < 1)
        {
            id = Random.Range(0, listAllowGrounds.ToArray().Length);
            block = Instantiate(listAllowGrounds.ToArray()[id]);
            countLastId++;
        }
        else
        {
            listAllowGrounds.Remove(groundsTest[lastId]);
            id = Random.Range(0, listAllowGrounds.ToArray().Length);
            block = Instantiate(listAllowGrounds.ToArray()[id]);
            countLastId = 0;
        }

        Transform transBlock = block.GetComponent<Transform>();
        transBlock.position = nextGroundPos;

        GameObject trigger = Instantiate(triggerPrefab);
        Transform transTrigger = trigger.GetComponent<Transform>();
        transTrigger.position = new Vector3(transBlock.position.x, 10, transBlock.position.z);

        GameObject trees = Instantiate(treesPrefab);
        Transform transTrees = trees.GetComponent<Transform>();
        transTrees.position = new Vector3(transBlock.position.x - 5f, 0, transBlock.position.z);

        transBlock.SetParent(transLevel);

        idBlockNow++;
        lastId = id;
        listAllowGrounds = CheckNextGrounds(id);

        if (lastIdGround == 9)
            lastIdGround = 0;
        else
            lastIdGround++;

        switch (id)
        {
            case 0:
                nextGroundPos.z += 10f;
                break;
            case 1:
                nextGroundPos.z += 10f;
                break;
            case 2:
                nextGroundPos.z += 10f;
                break;
        }
    }

    public static int RandomInt (int a, int b)
    {
        int num = Random.Range(a, b);
        return num; 
    }

    List<GameObject> CheckNextGrounds(int idGround)
    {
        List<GameObject> newList = new List<GameObject>();
        switch (idGround)
        {
            case 0:
                newList.Add(groundsTest[0]);
                newList.Add(groundsTest[1]);
                break;
            case 1:
                newList.Add(groundsTest[0]);
                newList.Add(groundsTest[1]);
                newList.Add(groundsTest[2]);
                break;
            case 2:
                newList.Add(groundsTest[0]);
                newList.Add(groundsTest[1]);
                newList.Add(groundsTest[2]);
                break;
        }
        return newList;
    }

    void StartGame()
    {
        for (int i = 0; i < 10; i++)
        {
            int id;

            if (countLastId < 1)
            {
                id = Random.Range(0, listAllowGrounds.ToArray().Length);
                block = Instantiate(listAllowGrounds.ToArray()[id]);
                countLastId++;
            }
            else
            {
                listAllowGrounds.Remove(groundsTest[lastId]);
                id = Random.Range(0, listAllowGrounds.ToArray().Length);
                block = Instantiate(listAllowGrounds.ToArray()[id]);
                countLastId = 0;
            }

            Transform transBlock = block.GetComponent<Transform>();
            transBlock.position = nextGroundPos;

            GameObject trigger = Instantiate(triggerPrefab);
            Transform transTrigger = trigger.GetComponent<Transform>();
            transTrigger.position = new Vector3(transBlock.position.x, 10, transBlock.position.z);

            GameObject trees = Instantiate(treesPrefab);
            Transform transTrees = trees.GetComponent<Transform>();
            transTrees.position = new Vector3(transBlock.position.x - 5f, 0, transBlock.position.z);

            transBlock.SetParent(transLevel);

            idBlockNow++;
            lastId = id;
            listAllowGrounds = CheckNextGrounds(id);
            arrGrounds[i] = block;

            switch (id)
            {
                case 0:
                    int a = Random.Range(0, 2);
                    if (a == 1)
                    {
                        GameObject cristal = Instantiate(cristalPrefab);
                        Transform transCristal = cristal.GetComponent<Transform>();
                        transCristal.position = new Vector3(0, 1, Random.Range(-2.5f, 2.5f));
                    }
                    else
                    {
                        GameObject badCristal = Instantiate(badCristalPrefab);
                        Transform transCristal = badCristal.GetComponent<Transform>();
                        transCristal.position = new Vector3(0, 1, nextGroundPos.z);
                    }
                    nextGroundPos.z += 10f;
                    break;
                case 1:
                    nextGroundPos.z += 10f;
                    break;
                case 2:
                    nextGroundPos.z += 10f;
                    break;
            }
        }
    }
}
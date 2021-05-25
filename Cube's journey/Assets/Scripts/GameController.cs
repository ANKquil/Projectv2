using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Main
    public GameObject mainCamera;
    public GameObject player;
    public GameObject level;

    Transform transLevel;

    // Prefabs
    public GameObject triggerPrefab;
    public GameObject[] groundsTest;

    // Settings
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

        listAllowGrounds.Add(groundsTest[0]);
        listAllowGrounds.Add(groundsTest[1]);
    }

    void Start()
    {
        StartGame();
    }

    
    void Update()
    {
        
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

            transBlock.SetParent(transLevel);

            idBlockNow++;
            lastId = id;
            listAllowGrounds = CheckNextGrounds(id);
            arrGrounds[i] = block;

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
    }
}
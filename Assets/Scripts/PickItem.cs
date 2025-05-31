using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PickItem : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPickPoint;
    Action playerLogic;

    Vector3 forceDirection;
    public bool isPlayerEnter;

    void Awake()
    {
        //
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPickPoint = GameObject.FindGameObjectWithTag("PickUpPoint");
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlayerEnter)
            {
                transform.SetParent(playerPickPoint.transform);
                transform.localPosition = Vector3.zero;
                //transform.rotation = new quaternion(-89.98f, 0, 0, 0);

                isPlayerEnter = false;
            }
            else
            {
                Debug.Log("플레이어 진입이 인식되지 않음");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerEnter = true;
            Debug.Log("플레이어 진입");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerEnter = false;
            Debug.Log("플레이어 아웃");
        }
    }
}

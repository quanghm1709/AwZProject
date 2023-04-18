using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [SerializeField] private GameObject sprite;
    [SerializeField] private float size;
    [SerializeField] private float duration;
    [SerializeField] private float countToGetReward;
    [SerializeField] private CircleCollider2D circle;
    private float countToGetRewardCD = 0;
    private float durationCD;
    private bool wait = false;
    private float originSize;
    private bool isPlayerIn = false;

    private void Start()
    {
        wait = true;
        originSize = size;
    }

    private void Update()
    {
        if (wait)
        {
            if (durationCD < duration)
            {
                durationCD += Time.deltaTime;
                if (isPlayerIn)
                {
                    ContinueCount();
                }
                circle.radius -= Time.deltaTime / 5;
                //if (size > 1)
                //{
                //    size -= Time.deltaTime / 5;
                //    sprite.transform.localScale = new Vector3(size-3, size-3, transform.localScale.z);
                //}
                
                
            }
            else
            {
                durationCD = 0;
                wait = false;
                Destroy(gameObject);
            }
        }

        //float distance = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        ////Debug.Log(distance + " " + size);
        //if (distance <= size / 2)
        //{
        //    ContinueCount();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isPlayerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerIn = false;
        }
    }

    private void ContinueCount()
    {
        Debug.Log("Count: " + countToGetRewardCD);
        countToGetRewardCD += Time.deltaTime;
        if(countToGetRewardCD >= countToGetReward)
        {
            Debug.Log("Grant reward");
            Destroy(gameObject);
        }
    }

    public void Setup(float duration)
    {
        //size = originSize;
        wait = true;
        this.duration = duration;
    }
}

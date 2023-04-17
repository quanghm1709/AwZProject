using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    private float lifeTimeCD;

    private void Start()
    {
        lifeTimeCD = lifeTime;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            lifeTime = lifeTimeCD;
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}

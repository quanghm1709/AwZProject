using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Resource")]
    [SerializeField] public int coin;

    [Header("Map")]
    [SerializeField] public bool[] isUnlockMap;
    [SerializeField] public int mapToInstatiate;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if(this == null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

}

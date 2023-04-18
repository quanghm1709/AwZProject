using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Resource")]
    [SerializeField] public int coin;
    [SerializeField] public int playerGold;
    public List<Dictionary_magazine>  player_magazine;
    [Header("Map")]
    [SerializeField] public bool[] isUnlockMap;
    [SerializeField] public int mapToInstatiate;
    public Dictionary<string, int> magazine_stored = new Dictionary<string, int>();
    public WeaponController weapon;

    [Serializable]
    public struct Dictionary_magazine
    {
        public string gun_name;
        public int gun_magazine;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        
        foreach (var i in player_magazine)
        {
            magazine_stored.Add(i.gun_name,i.gun_magazine);
        }
        
        if (this == null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Application.targetFrameRate != 60)
            Application.targetFrameRate = 60;
    }
}

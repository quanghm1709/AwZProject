using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public MeleeEnemy enemy;
        public int count;
        public float rate;
    }

    public static WaveSpawner instance;

    [SerializeField] private Wave[] waves;
    private int nextWave = 0;
    [SerializeField] private float timeBtwWave = 5f;
    [SerializeField] private float waveCountdonw;
    [SerializeField] private float searchCountDown = 1f;
    [SerializeField] private Transform[] spawnPoint;

    [SerializeField] private SpawnState state = SpawnState.COUNTING;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        waveCountdonw = timeBtwWave;
    }
    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveComplete();
            }
            else
            {
                return;
            }
        }

        if (waveCountdonw <= 0)
        {
            UIController.instance.updateScreen.SetActive(false);
            if (nextWave >= waves.Length)
            {
                UIController.instance.nextWaveCd.gameObject.SetActive(true);
                UIController.instance.nextWaveCd.text = "ALL WAVE COMPLETE!!";
                return;
            }

            UIController.instance.nextWaveCd.gameObject.SetActive(false);
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            //UIController.instance.notification.text = "Enemy Remaining: " + totalEnemy;
        }
        else
        {
            if (nextWave >= waves.Length)
            {
                UIController.instance.nextWaveCd.gameObject.SetActive(true);
                UIController.instance.nextWaveCd.text = "ALL WAVE COMPLETE!!";
                return;
            }
            UIController.instance.nextWaveSlider.value = waveCountdonw;
            UIController.instance.nextWaveSlider.maxValue = timeBtwWave;
            waveCountdonw -= Time.deltaTime;
            UIController.instance.nextWaveCd.gameObject.SetActive(true);
            UIController.instance.nextWaveCd.text = "TRÒ CHƠI BẮT ĐẦU SAU: " + ((int)waveCountdonw) + "s";
        }
    }

    public void WaveComplete()
    {
        state = SpawnState.COUNTING;
        waveCountdonw = timeBtwWave;
        UIController.instance.updateScreen.SetActive(true);
        UIController.instance.GenerateUpdateCard(3);

        if (nextWave < waves.Length)
        {
            nextWave++;
        }
        else
        {
            UIController.instance.nextWaveCd.gameObject.SetActive(true);
            UIController.instance.nextWaveCd.text = "ALL WAVE COMPLETE!!";          
        }
        
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        UIController.instance.currentWave.text = "Wave: " + _wave.name;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy.transform);
            yield return new WaitForSeconds(1f / _wave.rate);
            
            //UIController.instance.notification.text = "Remaining Enemy: " + (_wave.count - i);
        }
        state = SpawnState.WAITING;

        yield break;
    }

    public void SpawnEnemy(Transform _enemy)
    {
        Transform spawnpoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
        Instantiate(_enemy, spawnpoint.position, spawnpoint.rotation);

        //Debug.Log("Spawning Enemy: " + _enemy.name);
    }
}

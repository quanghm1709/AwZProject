using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [Header("Bar")]
    [SerializeField] public Slider hpBar;
    [SerializeField] public Button fire;
    [SerializeField] public Text gold;

    [Header("Wave Notification")]
    [SerializeField] public Text nextWaveCd;
    [SerializeField] private Text remainingEnemy;
    [SerializeField] public Text currentWave;
    [SerializeField] public Slider nextWaveSlider;
    private GameObject[] multiEnemy;

    [Header("Weapon")]
    [SerializeField] public Image weapUI;
    [SerializeField] public Slider ammo;
    [SerializeField] public Text weapName;
    [SerializeField] public Slider reload;
    [SerializeField] public Text ammoText;

    [Header("Upadte Screen")]
    [SerializeField] public GameObject cardDisplay;
    [SerializeField] public GameObject updateScreen;
    [SerializeField] public UpdateCard[] cardList;
    [SerializeField] public Text currentGold;

    [Header("Pause Group")]
    [SerializeField] public GameObject pauseScreen;
    [SerializeField] public GameObject deathScreen;
    [SerializeField] public GameObject quitScreen;

    [Header("Dash")]
    [SerializeField] public Slider dashCD;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        multiEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        remainingEnemy.text = "Địch còn lại: " + multiEnemy.Length;

        //Weap

        weapUI.sprite = PlayerController.instance.currentWeap.weapUI;
        weapName.text = PlayerController.instance.currentWeap.weaponName;
        ammoText.text = PlayerController.instance.currentWeap.currentBullet + "/" + PlayerController.instance.currentWeap.maxBullet;
        ammo.value = PlayerController.instance.currentWeap.currentBullet;
        ammo.maxValue = PlayerController.instance.currentWeap.maxBullet;
        reload.value = PlayerController.instance.currentWeap.reloadtime;
        reload.maxValue = PlayerController.instance.currentWeap.reloadTime;

        currentGold.text = "Current Gold: " + GameManager.instance.coin;
        gold.text = "Gold: " + GameManager.instance.coin;

        if (!updateScreen.activeInHierarchy)
        {
            foreach (Transform child in UIController.instance.cardDisplay.transform)
            {
                Destroy(child.gameObject);
            }
        }
        
    }

    public void GenerateUpdateCard(int k)
    {
        for(int i = 0; i < k; i++)
        {
            UpdateCard card = Instantiate(cardList[Random.Range(0, cardList.Length)]);
            foreach(Transform child in UIController.instance.cardDisplay.transform)
            {
                UpdateCard c = child.gameObject.GetComponent<UpdateCard>();
                if (card.name == c.name)
                {
                    Destroy(card.gameObject);
                    GenerateUpdateCard(k-i);
                    break;
                }
            }
            card.transform.parent = cardDisplay.transform;
            card.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Pause()
    {
        if (pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void QuitScreen()
    {
        if (quitScreen.activeInHierarchy)
        {
            quitScreen.SetActive(false);
            Time.timeScale = 1.0f;
        } else
        {
            quitScreen.SetActive(true);
            pauseScreen.SetActive(false);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

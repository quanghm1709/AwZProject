using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using YG;
using TMPro;
using DG.Tweening;

public class StartScreenUI : MonoBehaviour
{
    public static StartScreenUI instance;

    [Header("Button Group")]
    [SerializeField] private GameObject startGroup;
    [SerializeField] private GameObject mapBtnGroup;
    [SerializeField] private GameObject settingGroup;
    [SerializeField] private GameObject quitPanel;

    [Header("Image Group")]
    [SerializeField] private Image image;
    [SerializeField] private GameObject gameTitle;

    [Header("Loading Screen")]
    [SerializeField] public GameObject loadScreen;
    [SerializeField] public Slider loadingBar;

    [Header("Select Map")]
    [SerializeField] private GameObject mapCondition;

    [Header("Shop")]
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject watchAdsQ;
    [SerializeField] Text goldTxt;

    [SerializeField] GameObject guntab;
    [SerializeField] GameObject gunGoldtab;
    [SerializeField] Image gunBtn;
    [SerializeField] Image gungoldBtn;

    [Header("Noti")]
    [SerializeField] Text notiTxt;
    [SerializeField] CanvasGroup notiObj;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
#if UNITY_EDITOR
        YG2.ForceInit();
#endif
        UpdateGoldUI();
    }

    public void UpdateGoldUI()
    {
        goldTxt.text = DataManager.Instance.Gold.ToString();
    }

    public void MapBtnGroup()
    {
        if (mapBtnGroup.activeInHierarchy)
        {
            mapBtnGroup.SetActive(false);
            startGroup.SetActive(true);
            gameTitle.SetActive(true);
        }
        else
        {
            mapBtnGroup.SetActive(true);
            startGroup.SetActive(false);
            gameTitle.SetActive(false);
        }
    }

    public void Setting()
    {
        if (settingGroup.activeInHierarchy)
        {
            settingGroup.SetActive(false);
            startGroup.SetActive(true);
            gameTitle.SetActive(true);
        }
        else
        {
            settingGroup.SetActive(true);
            startGroup.SetActive(false);
            gameTitle.SetActive(false);
            shopPanel.SetActive(false);
        }
    }

    public void ShopPanel()
    {
        if (shopPanel.activeInHierarchy)
        {
            shopPanel.SetActive(false);
            startGroup.SetActive(true);
        }
        else
        {
            shopPanel.SetActive(true);
            settingGroup.SetActive(false);
            startGroup.SetActive(false);
            gameTitle.SetActive(false);
        }
    }
    
    public void SwitchTab(int index)
    {
        if (index == 0)
        {
            gunBtn.color = new Color(1, 1, 1, 1);
            gungoldBtn.color = new Color(1, 1, 1, .5f);
            guntab.SetActive(true);
            gunGoldtab.SetActive(false);
        }
        else
        {
            gunBtn.color = new Color(1, 1, 1, .5f);
            gungoldBtn.color = new Color(1, 1, 1, 1);
            guntab.SetActive(false);
            gunGoldtab.SetActive(true);
        }
    }

    public void fWatchAds()
    {
        if (watchAdsQ.activeInHierarchy)
        {
            watchAdsQ.SetActive(false);
        }
        else
        {
            watchAdsQ.SetActive(true);
        }
    }
    public void PopupMessage(string message)
    {
        notiTxt.text = message;
        notiObj.alpha = 1;
        StartCoroutine(IMess());
    }
    IEnumerator IMess()
    {
        yield return new WaitForSeconds(2f);
        notiObj.DOFade(0, .5f);
    }

    public void QuitPanel()
    {
        if (quitPanel.activeInHierarchy)
        {
            quitPanel.SetActive(false);
        }
        else
        {
            quitPanel.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private void Awake()
    {
        instance = this;
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
        }
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

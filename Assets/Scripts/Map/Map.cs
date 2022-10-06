using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    [SerializeField] private string mapName;
    [SerializeField] private int id;
    [SerializeField] private GameObject mapCondition;
    private bool canLoad = false;
    public void Update()
    {
        if (GameManager.instance.isUnlockMap[id])
        {
            canLoad = true;
            mapCondition.SetActive(false);
        }
    }


    public void LoadScene()
    {
        if (canLoad)
        {
            GameManager.instance.mapToInstatiate = id;
            StartCoroutine(LoadAsynchronously("Game Screen"));
        }
    }

    IEnumerator LoadAsynchronously(string loadScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadScene);

        StartScreenUI.instance.loadScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            StartScreenUI.instance.loadingBar.value = progress;
            yield return null;
        }
    }
}

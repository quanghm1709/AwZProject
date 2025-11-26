using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using DG.Tweening;

public class LoadingManager : MonoBehaviour
{
    public GameObject StartGame;
    public GameObject buttonTapContinute;
    public GameObject imgContinute;
    public GameObject imgload;

    AsyncOperation Loader;
    public GameObject loaderObj;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        StartCoroutine(LoadMainMenuStart());
    }

    IEnumerator LoadMainMenuStart()
    {
        StartGame.SetActive(true);
        imgload.transform.DORotate(new Vector3(0, 0, 180), 3, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Incremental);
        Loader = SceneManager.LoadSceneAsync(5);

        while (!Loader.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        loaderObj.SetActive(false);
        buttonTapContinute.SetActive(true);
        imgContinute.transform.DOScale(Vector3.one * 1.2f, 0.6f).SetLoops(-1, LoopType.Yoyo);
        YG2.GameReadyAPI();
    }

    public void TapToContinue()
    {
        StartGame.SetActive(false);
        buttonTapContinute.SetActive(false);
    }

}

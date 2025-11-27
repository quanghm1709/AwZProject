using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using DG.Tweening;
using UnityEngine.UI;

public class LoadingManager : Singleton<LoadingManager> 
{
    //public GameObject StartGame;
    //public GameObject buttonTapContinute;
   // public GameObject imgContinute;
    public GameObject imgload;
    public Slider loadingSlider;
    AsyncOperation Loader;
    public GameObject loaderObj;

    private void Start()
    {
        StartCoroutine(LoadMainMenuStart());
    }

    IEnumerator LoadMainMenuStart()
    {
        //StartGame.SetActive(true);
        //imgload.transform.DORotate(new Vector3(0, 0, 180), 3, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Incremental);
        Loader = SceneManager.LoadSceneAsync(1);

        while (!Loader.isDone)
        {
            loadingSlider.value += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
        //buttonTapContinute.SetActive(true);
        //imgContinute.transform.DOScale(Vector3.one * 1.2f, 0.6f).SetLoops(-1, LoopType.Yoyo);
        YG2.GameReadyAPI();
        loadingSlider.value = loadingSlider.maxValue;
    }

    public void TapToContinue()
    {
        //StartGame.SetActive(false);
        //buttonTapContinute.SetActive(false);
    }

}

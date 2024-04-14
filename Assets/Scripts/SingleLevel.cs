using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingleLevel : MonoBehaviour
{
    //public bool isFinished;
    //private int currentFinishedFlag = 0; //0未完成，1已完成
    public int levelIndex = 0;

    [Header("场景淡入淡出")]
    public float fadeSpeed = 1.5f; //速度
    private bool isFade = true; //是否开启效果
    public RawImage rawImage;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Start()
    {
        rawImage.uvRect = new Rect(0, 0, Screen.width, Screen.height);
    }
    private void Update()
    {
        if (isFade)
        {
            StartScene();
        }
    }
    public void BackButton()
    {
        StartCoroutine(TransitionToLevel());
    }
    public void Finished(int flag)
    {
        PlayerPrefs.SetInt("lv"+levelIndex, flag);
        Debug.Log(PlayerPrefs.GetInt("lv" + levelIndex, flag));
    }
    private void FadeIn()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    //屏幕渐显
    public void FadeOut()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }
    //游戏开始时
    private void StartScene()
    {
        FadeIn();
        if (rawImage.color.a <= 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            isFade = false;
        }
    }
    //游戏退出时
    private IEnumerator TransitionToLevel()
    {
        rawImage.enabled = true;
        while (rawImage.color.a <= 0.96f)
        {
            FadeOut();
            yield return null;
        }
        SceneManager.LoadScene("Main Scene");
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
    }
}

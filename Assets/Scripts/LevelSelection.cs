using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public bool unlocked; //default value is false
    public Image lockImage;

    [Header("淡入淡出效果")]
    public RawImage rawImage;
    public float fadeSpeed = 1.5f; //速度
    private bool isFade = true; //是否开启效果
    private void Start()
    {
        //rawImage = GetComponent<RawImage>();
        //将图片设置为屏幕大小
        rawImage.uvRect = new Rect(0, 0, Screen.width, Screen.height);

        //PlayerPrefs.DeleteAll(); //清空数据
    }
    private void Update()
    {
        if (isFade)
        {
            StartScene();
        }
        UpdateLevelImage();
        UpdateLevelStatus();
    }
    private void UpdateLevelImage()
    {
        if (!unlocked)
        {
            lockImage.gameObject.SetActive(true);
        }
        else
        {
            lockImage.gameObject.SetActive(false);
        }
    }
    private void UpdateLevelStatus()
    {
        int preLevelIndex = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("lv" + preLevelIndex) > 0) //如果第四关通了，解锁第五关
        {
            unlocked = true;
        }
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
    //游戏退出FadeOut
    public void PressSelection(string _levelNum)
    {
        if (unlocked)
        {
            StartCoroutine(FadeOutCoroutine(_levelNum));
        }
    }
    private void StartScene()
    {
        FadeIn();
        if(rawImage.color.a <= 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            isFade = false;
        }
    }
    private IEnumerator FadeOutCoroutine(string _levelNum)
    {
        rawImage.enabled = true;
        while (rawImage.color.a <= 0.96f)
        {
            FadeOut();
            yield return null;
        }
        SceneManager.LoadScene(_levelNum);
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
    }
    //游戏开始FadeIn
    //private IEnumerator FadeInCoroutine()
    //{
    //    rawImage.enabled = true;
    //    while (rawImage.color.a > 0.05f)
    //    {
    //        FadeIn();
    //        yield return null;
    //    }
    //    rawImage.color = Color.clear;
    //    rawImage.enabled = false;
    //    isFade = false;
    //}
}

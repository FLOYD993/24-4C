using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f; //速度
    private bool isFade = true; //是否开启效果
    public RawImage rawImage;

    public bool unlocked_;
    //private void Awake()
    //{
    //    instance = this;
    //}
    private void Start()
    {
        rawImage = GetComponent<RawImage>();
        //将图片设置为屏幕大小
        rawImage.uvRect = new Rect(0, 0, Screen.width, Screen.height);
        unlocked_ = GetComponent<LevelSelection>().unlocked;
    }
    private void Update()
    {
        if(isFade)
        {
            StartScene();
        }
    }
    //屏幕渐隐
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
        if(rawImage.color.a < 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            isFade = false;
        }
    }
    //游戏退出时
    public void EndScene()
    {
        rawImage.enabled = true;
        FadeOut();
        //切换场景
    }
    public void PressSelection(string _levelNum)
    {
        if (unlocked_)
        {
            EndScene();
            if (rawImage.color.a > 0.95f)
            {
                SceneManager.LoadScene(_levelNum);
            }
        }
    }
}

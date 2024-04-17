using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Linq;

public class VideoManager : MonoBehaviour
{
    public GameObject skipButton;
    public GameObject videoRawImage;
    public GameObject playVideoButton;
    public Button playButton;
    public VideoPlayer videoPlayer;
    private Scene gameScene;

    public int hasPlayedInMain = 1; //1 = false
    //private GameObject cameraMain;

    private void Awake()
    {
        gameScene = SceneManager.GetSceneByName("Persistent");
        //skipButton.SetActive(true);
        videoPlayer.loopPointReached += ToEndVideo;
        //if(SceneManager.GetActiveScene().name == "Main Scene")
        //{
        //    playButton.onClick.AddListener(PlayVideo);
        //    playButton.onClick.Invoke();
        //}
        //cameraMain = GameObject.Find("Camera_Main");

    }
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("l" + hasPlayedInMain));
        if (SceneManager.GetActiveScene().name == "Main Scene" && PlayerPrefs.GetInt("l" + hasPlayedInMain) > 0)
        {
            //PlayVideo();
            playButton.onClick.AddListener(PlayVideo);
            playButton.onClick.Invoke();
        }
    }
    public void PlayVideo()
    {
        ToggleAudioListener(false); // 关闭 AudioListener
        //if(SceneManager.GetActiveScene().name == "Main Scene")
        //{
            
        //    //hasPlayedInMain = 1;
        //}
        PlayerPrefs.SetInt("" + hasPlayedInMain, 0);
        Debug.Log(PlayerPrefs.GetInt("l" + hasPlayedInMain));
        playVideoButton.SetActive(false);
        videoPlayer.transform.SetAsLastSibling();
        videoRawImage.SetActive(true);
        skipButton.SetActive(true);
        skipButton.transform.SetAsLastSibling();
        Time.timeScale = 0f;
        videoPlayer.Play();
    }
    private void ToEndVideo(VideoPlayer source)
    {
        playVideoButton.SetActive(true);
        videoRawImage.SetActive(false);
        skipButton.SetActive(false);
        Time.timeScale = 1f;
        ToggleAudioListener(true); // 打开 AudioListener

    }
    public void CloseVideo()
    {
        playVideoButton.SetActive(true);
        videoRawImage.SetActive(false);
        skipButton.SetActive(false);
        Time.timeScale = 1f;
        ToggleAudioListener(true); // 打开 AudioListener
    }
    private void ToggleAudioListener(bool enable)
    {
        GameObject managerCameraRendering = GameObject.Find("Manager_CameraRendering");
        if (managerCameraRendering != null)
        {
            GameObject cameraMain = managerCameraRendering.transform.Find("Camera_Main").gameObject;
            if (cameraMain != null)
            {
                AudioListener audioListener = cameraMain.GetComponent<AudioListener>();
                if (audioListener != null)
                {
                    audioListener.enabled = enable;
                }
                else
                {
                    Debug.LogWarning("AudioListener component not found on Camera_Main.");
                }
            }
            else
            {
                Debug.LogWarning("Camera_Main not found under Manager_CameraRendering.");
            }
        }
        else
        {
            Debug.LogWarning("Manager_CameraRendering not found.");
        }
    }
}

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
    public VideoPlayer videoPlayer;
    private Scene gameScene;

    //private GameObject cameraMain;

    private void Awake()
    {
        gameScene = SceneManager.GetSceneByName("Persistent");
        //skipButton.SetActive(true);
        videoPlayer.loopPointReached += ToEndVideo;

        //cameraMain = GameObject.Find("Camera_Main");

    }
    public void PlayVideo()
    {
        ToggleAudioListener(false); // 关闭 AudioListener
        playVideoButton.SetActive(false);
        videoRawImage.SetActive(true);
        skipButton.SetActive(true);
        videoPlayer.Play();
    }
    private void ToEndVideo(VideoPlayer source)
    {
        playVideoButton.SetActive(true);
        videoRawImage.SetActive(false);
        skipButton.SetActive(false);
        ToggleAudioListener(true); // 打开 AudioListener

    }
    public void CloseVideo()
    {
        playVideoButton.SetActive(true);
        videoRawImage.SetActive(false);
        skipButton.SetActive(false);
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

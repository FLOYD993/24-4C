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
    public VideoPlayer videoPlayer;
    private Scene gameScene;

    private GameObject managerCameraRendering;

    private void Awake()
    {
        gameScene = SceneManager.GetSceneByName("Persistent");
        skipButton.SetActive(true);
        videoPlayer.loopPointReached += ToEndVideo;

        // �� Awake �в��� Persistent �����е� Camera ����
        managerCameraRendering = FindObjectOfType<Manager_CameraRendering>().gameObject;
    }

    private void ToEndVideo(VideoPlayer source)
    {
        videoRawImage.SetActive(false);
        skipButton.SetActive(false);
        ToggleAudioListener(false); // �ر� AudioListener
    }
    public void VideoClose()
    {
        this.gameObject.SetActive(false);
        skipButton.SetActive(false);
    }
    private void ToggleAudioListener(bool enable)
    {
        if (managerCameraRendering != null)
        {
            // �� Manager_CameraRendering ������������в��� Camera_Main
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

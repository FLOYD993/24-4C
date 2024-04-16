using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public GameObject skipButton;
    //public GameObject videoRawImage;
    //public VideoPlayer videoPlayer;  
    public void VideoClose()
    {
        //videoRawImage.SetActive(false);
        this.gameObject.SetActive(false);
        skipButton.SetActive(false);
    }
}

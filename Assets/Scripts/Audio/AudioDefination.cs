using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioDefination : MonoBehaviour
{
    public PlayAudioEventSO playAudioEvent;
    public AudioClip[] audioClipList;
    public bool playOnEnable;
    private Scene tmpScene;
    private void OnEnable()
    {
        if (playOnEnable)
            PlayAudioClip();
    }
    public void PlayAudioClip()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Menu":
                playAudioEvent.RaiseEvent(audioClipList[0]);
                break;
            case "Main Scene": 
                playAudioEvent.RaiseEvent(audioClipList[1]);
                break;
            case "Level1":
                playAudioEvent.RaiseEvent(audioClipList[2]);
                break;
            case "Level2":
                playAudioEvent.RaiseEvent(audioClipList[3]);
                break;
            case "Level3":
                playAudioEvent.RaiseEvent(audioClipList[4]);
                break;
        }
        //if(SceneManager.GetActiveScene().name == "Main Scene")
        //{
        //    playAudioEvent.RaiseEvent(audioClipList[1]);
        //}
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("广播")]
    public VoidEventSO pauseEvent;
    [Header("事件监听")]
    public FloatEventSO syncVolumeEvent;
    [Header("组件")]
    public Button settingsBtn;
    public GameObject pausePanel;
    public Slider volumeSlider;

    private void Awake()
    {
        settingsBtn.onClick.AddListener(TogglePausePanel);
    }
    private void Update()
    {
        //if(SceneManager.GetActiveScene().name == "Menu")
        //{
        //    settingsBtn.SetActive(false);
        //}
        //else
        //{
        //    settingsBtn.SetActive(true);
        //}
    }
    public void TogglePausePanel()
    {
        if(pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseEvent.RaisedEvent();
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnEnable()
    {
        syncVolumeEvent.OnEventRaised += OnSyncEvent;
    }
    private void OnDisable()
    {
        syncVolumeEvent.OnEventRaised -= OnSyncEvent;
    }

    private void OnSyncEvent(float amount)
    {
        volumeSlider.value = (amount+80) / 100;
    }
}

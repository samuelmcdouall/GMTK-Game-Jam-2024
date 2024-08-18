using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GJ24PauseMenuManager : MonoBehaviour
{
    [SerializeField]
    Slider _sfxSlider;
    [SerializeField]
    Slider _musicSlider;
    [SerializeField]
    GJ24SFXManager _sfxManager;
    [SerializeField]
    GameObject _pausedMenu;
    void Start()
    {
        _sfxManager.SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        _sfxSlider.value = _sfxManager.SFXVolume;
        _sfxManager.MusicAS.volume = PlayerPrefs.GetFloat("MusicVolume", 0.25f);
        _musicSlider.value = _sfxManager.MusicAS.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_pausedMenu.activeSelf)
            {
                _pausedMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                _pausedMenu.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

    public void OnChangeSFXValue()
    {
        PlayerPrefs.SetFloat("SFXVolume", _sfxSlider.value);
        PlayerPrefs.Save();
        _sfxManager.SFXVolume = _sfxSlider.value;


    }
    public void OnChangeMusicValue()
    {
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
        PlayerPrefs.Save();
        _sfxManager.MusicAS.volume = _musicSlider.value;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}

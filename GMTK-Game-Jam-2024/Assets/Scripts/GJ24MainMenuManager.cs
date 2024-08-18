using UnityEngine;
using UnityEngine.SceneManagement;

public class GJ24MainMenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject _startMenu;
    [SerializeField]
    GameObject _instructions;
    [SerializeField]
    GameObject _controls;

    public void StartButton()
    {
        _startMenu.SetActive(false);
        _instructions.SetActive(true);
        _controls.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void ContinueButton()
    {
        _startMenu.SetActive(false);
        _instructions.SetActive(false);
        _controls.SetActive(true);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
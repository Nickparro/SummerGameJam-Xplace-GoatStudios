using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //Intro
    public GameObject mainCamera;
    public CanvasGroup startMenuText, pressAnyButtonText, mainMenuText, optionPanel, blackFade;
    bool MainMenuScene(string sceneLoaded)
    {
        return SceneManager.GetActiveScene().name == sceneLoaded;
    }
    void Start()
    {
        if (MainMenuScene("MainMenu"))
        {
            MainMenuIntro_Cinematic();
            startMenuText.alpha = 0;
            pressAnyButtonText.alpha = 0;
            mainMenuText.alpha = 0;
            blackFade.alpha = 0;
            optionPanel.alpha = 0;
            StartCoroutine(PressAnyButtonCorroutine());
        }
            
    }

    private void Update() {
       
    }
    public void MainMenuIntro_Cinematic()
    {
        var sequence = DOTween.Sequence();
        
        sequence.Insert(0f, mainCamera.transform.DORotate(new Vector3(-61.651f,38.783f,61.103f), 0f, RotateMode.Fast));
        sequence.Insert(2f, mainCamera.transform.DORotate(new Vector3(-3.299f,64.132f,-1.045f), 7f, RotateMode.Fast).SetEase(Ease.InOutBack));
        sequence.Insert(6f, startMenuText.DOFade(1f, 3f));
        sequence.Insert(9f, pressAnyButtonText.DOFade(1f, 0.7f).SetLoops(-1, LoopType.Yoyo));
    }

     public void LoadNewScene()
    {
        var sequence = DOTween.Sequence();
        sequence.Insert(0f, blackFade.DOFade(1f, 1.5f));
        sequence.InsertCallback(1.5f, () => SceneManager.LoadScene("MainLevel"));
    }

    public void OptionsPanel()
    {
        var sequence = DOTween.Sequence();
        sequence.Insert(0f, mainMenuText.DOFade(0f, 1f));
        sequence.Insert(0.5f, optionPanel.DOFade(1f, 1f));

    }

    public void BackToMenu()
    {
        var sequence = DOTween.Sequence();
        sequence.Insert(0f, mainMenuText.DOFade(1f, 1f));
        sequence.Insert(0.5f, optionPanel.DOFade(0f, 1f));
    }

     public void QuitGame()
    {
        Application.Quit();
    }
    public void AnyButtonToStartPressed()
    {
        var sequence = DOTween.Sequence();
        sequence.Insert(0f, startMenuText.DOFade(0f, 1f));
        sequence.Insert(1f, mainMenuText.DOFade(1f, 1f));
        sequence.InsertCallback(1f, () => startMenuText.gameObject.SetActive(false));

    }

    IEnumerator PressAnyButtonCorroutine()
    {
        yield return new WaitForSeconds(7);
         if(Input.anyKeyDown)
        {
            AnyButtonToStartPressed();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private UICanvasGroupHandler _startMenu;
    [SerializeField] private UICanvasGroupHandler _mainMenu;

    private bool _hasStarted;

    private void Start()
    {
        _startMenu.SetCanvasGroup(true);
        _mainMenu.SetCanvasGroup(false);
    }

    private void Update()
    {
        if(Input.anyKeyDown == true && _hasStarted == false)
        {
            _hasStarted = true;
            _mainMenu.SetCanvasGroup(true);
            _startMenu.SetCanvasGroup(false);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

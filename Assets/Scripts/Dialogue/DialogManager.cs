using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [Header("Dialog UI")]
    [SerializeField] private GameObject _dialogPanel;
    [SerializeField] private TMP_Text _dialogText;

    private Story _currentStory;
    private bool _dialogIsPlaying;

    public static DialogManager Instance;
    public bool DialogIsPlaying => _dialogIsPlaying;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _dialogIsPlaying = false;
        _dialogPanel.SetActive(false);
    }

    private void Update()
    {
        if (_dialogIsPlaying == false) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void EnterDialogMode(TextAsset inkJson)
    {
        _currentStory = new(inkJson.text);
        _dialogIsPlaying = true;
        _dialogPanel.SetActive(true);

        ContinueStory();
    }
    private void ExitDialogMode()
    {
        _dialogIsPlaying = false;
        _dialogPanel.SetActive(false);
        _dialogText.text = "";
    }

    private void ContinueStory()
    {
        if (_currentStory.canContinue == true)
        {
            _dialogText.text = _currentStory.Continue();
        }
        else
        {
            ExitDialogMode();
        }
    }
}

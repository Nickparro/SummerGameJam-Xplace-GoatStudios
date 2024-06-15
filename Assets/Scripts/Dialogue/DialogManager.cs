using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour
{
    [Header("Dialog UI")]
    [SerializeField] private GameObject _dialogPanel;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private TMP_Text _displayNameText;
    [SerializeField] private Animator _portraitAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] _choices;
    private TMP_Text[] _choicesText;

    private Story _currentStory;
    private bool _dialogIsPlaying;

    public static DialogManager Instance;
    public bool DialogIsPlaying => _dialogIsPlaying;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string STATE_TAG = "changeState";

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

        _choicesText = new TMP_Text[_choices.Length];
        int index = 0;
        foreach (GameObject choice in _choices)
        {
            _choicesText[index] = choice.GetComponentInChildren<TMP_Text>();
            index++;
        }
    }

    private void Update()
    {
        if (_dialogIsPlaying == false) return;
        if (_currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.Space))
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
            //Set dialog text
            _dialogText.text = _currentStory.Continue();
            //Display any choices if any
            DisplayChoices();
            //Handle Tags
            HandleTags(_currentStory.currentTags);
        }
        else
        {
            ExitDialogMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            //Parse tag to value pair
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2 ) Debug.LogError("Tag could not be parsed: " + tag);

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    _displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    _portraitAnimator.Play(tagValue);
                    break;
                case STATE_TAG:
                    //StateManager.SetState(tagValue);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;

        if(currentChoices.Count > _choices.Length)
        {
            Debug.LogError("More Choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            _choices[index].SetActive(true);
            _choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < _choices.Length; i++)
        {
            _choices[i].SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        //Clear event system (needed)
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(_choices[0]);
    }

    public void MakeChoice(int choiceIndex)
    {
        _currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}

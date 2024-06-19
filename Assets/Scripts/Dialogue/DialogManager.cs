using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private TextAsset _defaultDialog;
    [SerializeField] private float _typingSpeed = 0.05f;
    [SerializeField] private StringEvent _onObjectiveChanged;

    [Header("Dialog UI")]
    [SerializeField] private GameObject _dialogPanel;
    [SerializeField] private GameObject _continueIcon;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private TMP_Text _displayNameText;
    [SerializeField] private Animator _portraitAnimator;
    
    [Header("Choices UI")]
    [SerializeField] private GameObject[] _choices;
    private TMP_Text[] _choicesText;

    //Input
    private PlayerInputs _playerInputs;
    private InputAction _submitAction;
    private bool _pressedInput;

    //Dialog flow
    private Story _currentStory;
    private bool _dialogIsPlaying;
    private bool _canContinueToNextLine;
    
    private Coroutine _displayLineCoroutine;

    //Instance
    public static DialogManager Instance;
    public bool DialogIsPlaying => _dialogIsPlaying;

    //Tag management
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string OBJECTIVE_TAG = "objective";

    //External functions
    private InkExternalFunctions _externalFunctions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        _externalFunctions = new();
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

        _playerInputs = new();
        _submitAction = _playerInputs.UI.Submit;
        _submitAction.performed += (x => _pressedInput = true);
        _playerInputs.Enable();
    }

    private void OnEnable() => _playerInputs?.Enable();
    private void OnDisable() => _playerInputs?.Disable();

    private void Update()
    {
        if (_dialogIsPlaying == false) return;
        if (_canContinueToNextLine == true 
            && _currentStory.currentChoices.Count == 0 
            && _pressedInput == true)
        {
            _pressedInput = false;
            ContinueStory();
        }
    }

    public void EnterDialogMode(TextAsset inkJson)
    {
        if(inkJson == null)
            _currentStory = new(_defaultDialog.text);
        else
            _currentStory = new(inkJson.text);
        _dialogIsPlaying = true;
        _dialogPanel.SetActive(true);

        _externalFunctions.Bind(_currentStory);

        ContinueStory();
    }

    private void ContinueStory()
    {
        if (_currentStory.canContinue == true)
        {
            //Set dialog text
            if (_displayLineCoroutine != null) StopCoroutine(_displayLineCoroutine);
            _displayLineCoroutine = StartCoroutine(DisplayLine(_currentStory.Continue()));
            
            //Handle Tags
            HandleTags(_currentStory.currentTags);
        }
        else
        {
            ExitDialogMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        //Empty current dialog text
        _dialogText.text = "";

        //Hide continue icon and choice buttons if shown
        _continueIcon.SetActive(false);
        foreach (GameObject choiceButton in _choices) choiceButton.SetActive(false);

        _canContinueToNextLine = false;

        //Loop through each character
        foreach (char letter in line.ToCharArray())
        {
            //If player presses submit, finish typing full text
            if(_pressedInput == true)
            {
                _pressedInput = false;
                _dialogText.text = line;
                break;
            }
            _dialogText.text += letter;
            yield return new WaitForSeconds(_typingSpeed);
        }

        _continueIcon.SetActive(true);
        //Display choices if any
        DisplayChoices();

        _canContinueToNextLine = true;
    }

    private void ExitDialogMode()
    {
        _externalFunctions.Unbind(_currentStory);

        _dialogIsPlaying = false;
        _dialogPanel.SetActive(false);
        _dialogText.text = "";
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
                case OBJECTIVE_TAG:
                    _onObjectiveChanged.Invoke(tagValue);
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
        if(_canContinueToNextLine == true)
        {
            _pressedInput = false;
            _currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }
}

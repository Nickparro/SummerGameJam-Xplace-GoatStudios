using System.Linq;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private State _initialState;
    [SerializeField] private StateEvent _onStateChanged;
    public static StateManager Instance;

    private State _currentState;
    public State CurrentState => _currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        _currentState = _initialState;
    }

    public void ChangeState(string newState)
    {
        State endState = _currentState.PossibleStates.Where(t => t.Name == newState).First();
        if (endState != null)
        {
            _currentState = endState;
            _onStateChanged.Invoke(_currentState);
        }
        else Debug.LogError("State " + newState + " not found!");
    }
}

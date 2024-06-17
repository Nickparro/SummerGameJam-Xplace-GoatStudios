using System.Linq;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private State _initialState;
    public static StateManager Instance;

    private State _currentState;

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
        _currentState = _currentState.PossibleStates.Where(t => t.Name == newState).First();
    }
}

public class State : ScriptableObject
{
    public string Name;
    public State[] PossibleStates;

}

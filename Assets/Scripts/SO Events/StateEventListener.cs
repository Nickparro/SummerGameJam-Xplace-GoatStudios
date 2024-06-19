using UnityEngine;

public class StateEventListener : GameEventListener<State>
{
    [SerializeField] private State[] _requiredStates;

    public override void Rise(State value)
    {
        foreach (State state in _requiredStates)
        {
            if (value == state)
            {
                base.Rise(value);
                break;
            }
        }
            
    }
}

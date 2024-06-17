using UnityEngine;

public class StateEventListener : GameEventListener<State>
{
    [SerializeField] private State _requiredState;

    public override void Rise(State value)
    {
        if(value == _requiredState)
            base.Rise(value);
    }
}

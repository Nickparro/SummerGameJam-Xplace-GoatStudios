using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventListener<T> : MonoBehaviour
{
    [SerializeField] private GameEvent<T> _gameEvent;
    [SerializeField] private UnityEvent<T> _valueEvent;
    [SerializeField] private UnityEvent _triggerEvent;

    private void OnEnable() => _gameEvent.Register(this);
    private void OnDisable() => _gameEvent.Deregister(this);

    public virtual void Rise(T value)
    {
        if(value != null) _valueEvent?.Invoke(value);
        _triggerEvent?.Invoke();
    }

}

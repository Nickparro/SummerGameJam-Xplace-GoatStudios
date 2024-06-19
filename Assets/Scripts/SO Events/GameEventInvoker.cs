using UnityEngine;

public class GameEventInvoker<T> : MonoBehaviour
{
    [SerializeField] private GameEvent<T> _event;
    public void Invoke(T value) => _event.Invoke(value);
}

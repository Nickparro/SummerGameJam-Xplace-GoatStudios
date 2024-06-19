using UnityEngine;

[CreateAssetMenu(fileName = "String Event", menuName = "Scriptable Objects/Events/String")]
public class StringEvent : GameEvent<string>
{
    [ContextMenu("Invoke")]
    private void Invoke() => Invoke(_testValue);
}

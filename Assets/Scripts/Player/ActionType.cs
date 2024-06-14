using UnityEngine;

[CreateAssetMenu(fileName = "Action Type", menuName = "Scriptable Objects/Action Type")]
public class ActionType : ScriptableObject
{
    public bool DisplacesPlayer;
    public AnimationClip Clip;
}
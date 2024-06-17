using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "Scriptable Objects/State")]
public class State : ScriptableObject
{
    public string Name;
    public State[] PossibleStates;

    public TextAsset[] Dialogues;

    public TextAsset GetDialog(Entity entity)
    {
        TextAsset dialog = Dialogues.Where(t => t.name == entity.name).FirstOrDefault();
        return dialog;
    }
}



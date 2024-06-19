using TMPro;
using UnityEngine;

public class UIObjective : MonoBehaviour
{
    [SerializeField] private TMP_Text _objectiveText;

    public void ChangeObjective(string newObjective) => _objectiveText.SetText("Objective: "+ newObjective);
}

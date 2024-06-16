using UnityEngine;

public interface IInteractable
{
    public GameObject VisualCue { get; }
    public void VisualCueVisibility(bool visible) => VisualCue.SetActive(visible);
    public void Interact();
}
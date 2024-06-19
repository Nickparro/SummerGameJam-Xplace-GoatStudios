using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("ChangeState", (string stateName) => ChangeState(stateName));
        story.BindExternalFunction("PlaySound", (string soundName) => PlaySound(soundName));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("ChangeState");
    }

    private void ChangeState(string stateName)
    {
        if(StateManager.Instance != null) StateManager.Instance.ChangeState(stateName);
    }

    private void PlaySound(string soundName)
    {
        if (AudioManager.Instance != null) AudioManager.Instance.Play(soundName);
    }
}

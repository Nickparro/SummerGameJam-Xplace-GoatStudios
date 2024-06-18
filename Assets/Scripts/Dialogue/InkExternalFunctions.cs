using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("ChangeState", (string stateName) => ChangeState(stateName));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("ChangeState");
    }

    private void ChangeState(string stateName)
    {
        if(StateManager.Instance != null) StateManager.Instance.ChangeState(stateName);
    }
}

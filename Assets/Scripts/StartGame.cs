using UnityEngine;
using UnityEngine.Events;

public class StartGame : Screen
{
    public event UnityAction PlayButtonClick;

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}

using UnityEngine;
using UnityEngine.Events;

public class EndGame : Screen
{
    public event UnityAction RestartClick;

    public override void Open()
    {   
        gameObject.SetActive(true);
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
        RestartClick?.Invoke();
    }
}
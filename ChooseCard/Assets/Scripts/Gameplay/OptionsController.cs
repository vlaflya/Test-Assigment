using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OptionsController : MonoBehaviour, IPointerDownHandler
{
    private bool isRightOptions;
    private bool canClick = true;
    [SerializeField] OptionsView view;
    [SerializeField] private UnityEvent wrongOptionEvent;
    [SerializeField] private UnityEvent firstSpawnEvent;
    [SerializeField] private UnityEvent rightOptionEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isRightOptions)
        {
            if(canClick)
                ChooseRight();
        }
        else {
            ChooseWrong();
        }
    }
    private void ChooseRight() {
        canClick = false;
        rightOptionEvent.Invoke();
    }
    private void ChooseWrong() {
        wrongOptionEvent.Invoke();
    }

    public OptionsController SetOption(Option option, SessionController controller, bool firstSpawn) {
        view.SetSprite(option, controller);
        if (firstSpawn)
            firstSpawnEvent.Invoke();
        return this;
    }
    public void SetRight() {
        isRightOptions = true;
    }

}

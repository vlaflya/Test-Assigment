using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SessionController : MonoBehaviour
{
    [SerializeField] private int totalLevels;
    private int curentLevel = 1;
    //[SerializeField] private int dificultyIncriment;
    [SerializeField] private OptionsCreator optionsCreator;
    [SerializeField] private UnityEvent LoadNextLevelEvent;
    [SerializeField] private UnityEvent StartFirstLevelEvent;
    [SerializeField] private CanvasGroup restartInterface;
    [SerializeField] private Image loadingScreen;

    public void Start()
    {
        StartFirstLevelEvent.Invoke();
    }
    public void EndLevel() {
        if (totalLevels > curentLevel)
        {
            curentLevel++;
            LoadNextLevelEvent.Invoke();
        }
        else {
            EndGame();
        }
    }
    private void EndGame() {
        restartInterface.DOFade(1, 2);
        restartInterface.blocksRaycasts = true;
    }
    public void Restart() {
        restartInterface.blocksRaycasts = false;
        loadingScreen.raycastTarget = true;
        loadingScreen.DOColor(Color.black, 1).OnComplete(() => {
            DOTween.CompleteAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        });
    }
}

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
[RequireComponent(typeof(Image))]
public class OptionsView : MonoBehaviour
{
    [SerializeField]private Image image;
    [SerializeField]private Image optionVisuals;
    [SerializeField] private GameObject particles;
    private SessionController sessionController;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void BounceRight() {
        optionVisuals.DORewind();
        optionVisuals.transform.DOPunchScale(optionVisuals.transform.transform.localScale * 1.1f, 0.5f, 6, 0.7f).OnComplete(sessionController.EndLevel);
        Instantiate(particles, transform.position, Quaternion.identity);
    }
    public void BounceSpawn() {
        transform.DOPunchScale(transform.transform.localScale * 1.1f, 0.5f, 6, 0.7f);
    }

    public void EaseBounce() {
        optionVisuals.transform.DORewind();
        optionVisuals.transform.DOShakeRotation(1, 50);
    }

    public void SetSprite(Option option, SessionController controller) {
        image.color = option.backgroundColor;
        optionVisuals.sprite = option.sprite;
        sessionController = controller;
    }
}

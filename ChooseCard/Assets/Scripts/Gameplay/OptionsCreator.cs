using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class OptionsCreator : MonoBehaviour
{
    [SerializeField] SessionController sessionController;
    [SerializeField] private List<OptionsAtlas> optionsAtlas = new List<OptionsAtlas>();
    private List<string> excludeOptions = new List<string>();
    private OptionsAtlas curentAtlas;
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private OptionsController optionPrefab;
    [SerializeField] private int gridColomns;
    private int optionsNumber;
    [SerializeField] private UnityEvent createdOptionsEvent;
    [SerializeField] private Text text;

    public void FirstSet(int dificulty) {
        optionsNumber = dificulty;
        text.color = Color.clear;
        text.DOColor(Color.black, 2);
        ChooseAtlas();
        SetOptions(true);
    }
    public void NextLevel(int dificultyIncriment) {
        optionsNumber += dificultyIncriment;
        ClearOptions();
        SetOptions(false);
    }

    private void SetOptions(bool firstSpawn) {
        grid.constraintCount = gridColomns;
        foreach (Option option in curentAtlas.GetRandomOption(optionsNumber, excludeOptions)) {
            OptionsController tmp = Instantiate(optionPrefab, grid.transform).SetOption(option, sessionController, firstSpawn);
            tmp.gameObject.name = option.sprite.name;
        }
        ChooseRightOption();
        createdOptionsEvent.Invoke();
    }
    private void ChooseRightOption() {
        int random = Random.Range(0, grid.transform.childCount);
        OptionsController optionController = grid.transform.GetChild(random).GetComponent<OptionsController>();
        excludeOptions.Add(optionController.gameObject.name);
        optionController.SetRight();
        text.text = "Find " + optionController.gameObject.name;
    }
    private void ClearOptions() {
        for (int i = 0; i < grid.transform.childCount;) {
            grid.transform.GetChild(i).gameObject.SetActive(false);
            grid.transform.DetachChildren();
        }
    }
    private void ChooseAtlas() {
        curentAtlas = optionsAtlas[Random.Range(0, optionsAtlas.Count)];
    }
}

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Options Atlas", menuName = "Options Atlas")]
public class OptionsAtlas : ScriptableObject
{
    public List<Option> options = new List<Option>();
    public List<Option> GetRandomOption(int count, List<string> exclude) {
        List<Option> returnList = new List<Option>();
        List<Option> copyList = new List<Option>(options);
        if (count <= options.Count - exclude.Count)
        {
            for (int i = 0; i < count;)
            {
                Option option = copyList[Random.Range(0, copyList.Count)];
                if (!exclude.Contains(option.sprite.name))
                {
                    copyList.Remove(option);
                    returnList.Add(option);
                    i++;
                }
            }
            return returnList;
        }
        else
            throw new System.Exception("Not enough sprites in atlas");
        
    }
}
[System.Serializable]
public class Option {
    public Sprite sprite;
    public Color backgroundColor;
}
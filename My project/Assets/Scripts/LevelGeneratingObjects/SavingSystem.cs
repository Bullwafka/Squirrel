using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavingSystem
{
    private readonly string _filePath;
    private SavingItems _savingItemsData;
    private LevelGeneratingSystem _generator;
    public SavingSystem()
    {
        _filePath = Application.persistentDataPath + "Save.json";
        _generator = GameObject.Find("Pool").GetComponent<LevelGeneratingSystem>();
    }
    public void SaveItemsData()
    {
        SavingItems data = new SavingItems(_generator._interactableItemsList);
        var json = JsonUtility.ToJson(data, true);
        using (var writer = new StreamWriter(_filePath))
        {
            writer.WriteLine(json);
        }
    }

    public void LoadItemsData()
    {
        SavingItems data = new SavingItems(_generator._interactableItemsList);
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            _savingItemsData = JsonUtility.FromJson<SavingItems>(json);
        }
        else
        {
            _savingItemsData = new SavingItems(_generator._interactableItemsList);
        }
    }
}


[Serializable]
public class SavingItems : ISerializationCallbackReceiver
{
    public List<InteractableItem> _itemsList;
    public SavingItems(List<InteractableItem> itemsList)
    {
        _itemsList = itemsList;
    }

    public List<string> _serializingItems;
    public List<string> _types;

    public void OnBeforeSerialize()
    {
        _serializingItems = new List<string>();
        _types = new List<string>();

        for (int i = 0; i < _itemsList.Count; i++)
        {
            _serializingItems.Add(JsonUtility.ToJson(_itemsList[i]));
            _types.Add(_itemsList[i].GetType().ToString());
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < _serializingItems.Count; i++)
        {
            _itemsList[i].UpdateItemData(_serializingItems[i]);
        }
    }

}

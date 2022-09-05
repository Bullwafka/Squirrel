using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSavingScript : MonoBehaviour
{
    private SavingSystem _savingSystem;

    private void Awake()
    {
        _savingSystem = new SavingSystem();
        _savingSystem.LoadItemsData();
    }
    public void Save()
    {
        _savingSystem.SaveItemsData();
        Debug.Log(Application.persistentDataPath);
    }

    public void Load()
    {
        _savingSystem.LoadItemsData();
    }
}

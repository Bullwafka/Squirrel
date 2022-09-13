using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSavingScript : MonoBehaviour
{
    private SavingSystem _savingSystem;

    public void Awake()
    {
        _savingSystem = new SavingSystem();
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

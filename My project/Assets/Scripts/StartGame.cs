using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _fire;
    [SerializeField] private GameObject _startButton;

    private MoveScript _moveScript;
    private LevelGenerator _generator;
    private SavingSystem _savingSystem;

    private void Start()
    {
        _generator = GameObject.Find("Pool").GetComponent<LevelGenerator>();
        _moveScript = GetComponent<MoveScript>();
        _moveScript.enabled = false;
        _fire.SetActive(false);
        _startButton.SetActive(true);
       _savingSystem = new SavingSystem();
        _savingSystem.LoadItemsData();
    }
    public void OnStartButtonClick()
    {
        _savingSystem.SaveItemsData();
       StartRun();
    }

    private void StartRun()
    {
        _generator.enabled = true;
        _moveScript.enabled = true;
        _fire.SetActive(true);
        _startButton.SetActive(false);
    }
}

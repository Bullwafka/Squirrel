using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _fire;
    [SerializeField] private GameObject _startButton;

    private MoveScript _moveScript;

    private void Start()
    {
        _moveScript = GetComponent<MoveScript>();
        _moveScript.enabled = false;
        _fire.SetActive(false);
        _startButton.SetActive(true);
    }
    public void OnStartButtonClick()
    {
        StartRun();
    }

    private void StartRun()
    {
        _moveScript.enabled = true;
        _fire.SetActive(true);
        _startButton.SetActive(false);
    }
}

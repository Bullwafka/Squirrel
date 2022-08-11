using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SuddenDeathAlert : MonoBehaviour
{
    [SerializeField] private GameObject _suddenDeathAllert;
    [SerializeField] private FireMover _fireMover;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private TMP_Text _timerDisplay;
    [SerializeField] private float _timer;

    private bool _suddenDeathFlag;

    private Animator _animator;

    public event UnityAction SuddenDeath;
    private void Update()
    {
        Timer();
        if (_timer < 0 && _suddenDeathFlag == false)
        {
            SuddenDeath.Invoke();
        }
    }
    private void OnEnable()
    {
        _animator = _suddenDeathAllert.GetComponent<Animator>();
        _fireMover.GetComponent<FireMover>();
        SuddenDeath += SuddenDeathHandler;
    }
    private void OnDisable()
    {
        SuddenDeath -= SuddenDeathHandler;
    }
    private void Start()
    {
        _timerDisplay.text = _timer.ToString();
    }
    private void SuddenDeathHandler()
    {
        _suddenDeathFlag = true;
        _animator.SetTrigger("SuddenDeathAlarm");
    }
    private void Timer()
    {
        _timer -= Time.deltaTime;

        _timerDisplay.text = _timer.ToString();

        if (_timer < 0)
        {
            _timerDisplay.text = "Sudden Death!!!";
        }
    }
}

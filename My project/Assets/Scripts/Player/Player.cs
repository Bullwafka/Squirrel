using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxStaminaValue;
    [SerializeField] private float _staminaRecoveryCooldown;
    [SerializeField] private GameObject[] _staminaUI;

    private WaitForSeconds _staminaCoolDown = new WaitForSeconds(1.5f);
    private WaitForSeconds _staminaRegenerationDelay = new WaitForSeconds(0.7f);

    private bool _coroutineRunning;

    private int _currentStaminaValue;
    public int Stamina
    {
        get => _stamina;
        private set => _stamina = value;
    }
    private int _stamina;
    public bool JumpBlocked
    {
        get => _jumpBlocked;
        private set => _jumpBlocked = value;
    }
    private bool _jumpBlocked;

    private void Start()
    {
        Stamina = _maxStaminaValue;
        _currentStaminaValue = Stamina;
        ChangeStaminaUI();
    }

    public void ChangeStaminaValue(int value)
    {
        if (Stamina + value >= 0 & Stamina + value <= _maxStaminaValue)
        {
            Stamina += value;
        }
        else if (Stamina + value > _maxStaminaValue)
        {
            Stamina = _maxStaminaValue;
        }

        if (Stamina < _maxStaminaValue & _coroutineRunning == false)
        {
            StartCoroutine(StaminaRegeneration());
        }

        if (Stamina == 0)
        {
            JumpBlocked = true;
        }
        else
        {
            JumpBlocked = false;
        }
        ChangeStaminaUI();
    }

    private IEnumerator StaminaRegeneration()
    {
        Debug.Log("Start");
        _coroutineRunning = true;
        yield return _staminaRegenerationDelay;

        while (Stamina < _maxStaminaValue)
        {
            ChangeStaminaValue(1);
            yield return _staminaCoolDown;
        }
        Debug.Log("Stop");
        _coroutineRunning = false;
        yield break;
    }

    private void ChangeStaminaUI()
    {
        _staminaUI[_currentStaminaValue].SetActive(false);
        _staminaUI[Stamina].SetActive(true);
        _currentStaminaValue = Stamina;
    }
}

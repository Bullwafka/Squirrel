using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxStaminaValue;
    [SerializeField] private float _staminaRecoveryCooldown;
    [SerializeField] private TMP_Text _debugStamina;

    private WaitForSeconds _staminaCoolDown = new WaitForSeconds(1.5f);
    private WaitForSeconds _staminaRegenerationDelay = new WaitForSeconds(0.7f);
    
    private bool _coroutineRunning;
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
        _debugStamina.text = Stamina.ToString();
    }
    
    public void ChangeStamina(int value)
    {
        if (Stamina + value >= 0 & Stamina + value <= _maxStaminaValue)
        {
            Stamina += value;
        }
        else if(Stamina + value > _maxStaminaValue)
        {
            Stamina = _maxStaminaValue;
        }
        
        if(Stamina < _maxStaminaValue & _coroutineRunning == false)
        {
            StartCoroutine(StaminaRegeneration());
        }
        
        if(Stamina == 0)
        {
            JumpBlocked = true;
        }
        else
        {
            JumpBlocked = false;
        }

        _debugStamina.text = Stamina.ToString();
    }

    private IEnumerator StaminaRegeneration()
    {
        Debug.Log("Start");
        _coroutineRunning = true;
        yield return _staminaRegenerationDelay;

        while (Stamina < _maxStaminaValue)
        {
            ChangeStamina(1);
            yield return _staminaCoolDown;
        }
        Debug.Log("Stop");
        _coroutineRunning = false;
        yield break;
    }


}

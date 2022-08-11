using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Stamina : MonoBehaviour
{
    [SerializeField] private int _maxStaminaSerializer;
    [SerializeField] private float _staminaPointRecoveryTime;
    [SerializeField] private GameObject[] _image;

    private static int _maxStamina;
    private int _currentStamina;

    private float _staminaTimer;

    public int StaminaValue
    {
        get => _staminaValue;
        set 
        {
            if (_staminaValue - 1 >= 0)
            {
                _staminaValue -= 1;
            }
        }
    }
    private int _staminaValue;
    private void Start()
    {
        _maxStamina = _maxStaminaSerializer;
        StaminaValue = _maxStamina;
        _staminaTimer = 0;
        _currentStamina = StaminaValue;
    }
    private void Update()
    {
        PassiveStaminaRecover();
        StaminaView(StaminaValue);
    }
    public void PassiveStaminaRecover()
    {
        if ((_staminaTimer += Time.deltaTime) >= _staminaPointRecoveryTime & StaminaValue < _maxStamina)
        {
            StaminaValue += 1;
            _staminaTimer = 0;
        }
    }
    private void StaminaView(int stamina)
    {
        if (_currentStamina != stamina)
        {
            _image[_currentStamina].SetActive(false);
            _image[stamina].SetActive(true);
            _currentStamina = stamina;
        }
    }
    public void StaminaRecover(int value)
    {
        if (StaminaValue < _maxStamina)
        {
            StaminaValue += value;
        }
    }
    public void DecreasStamina()
    {
        if(StaminaValue - 1 >= 0)
        {
            StaminaValue -= 1;
        }
    }
}
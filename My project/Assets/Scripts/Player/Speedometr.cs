using TMPro;
using UnityEngine;

public class Speedometr : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private TMP_Text _text;

    private Rigidbody2D _rb;
    private float _playerSpeed;

    private void Update()
    {
        SpeedLimiter();
    }
    private void Start()
    {
        _rb = _playerObject.GetComponent<Rigidbody2D>();
    }

    private void SpeedLimiter()
    {
        _playerSpeed = _rb.velocity.y;
        _text.text = _playerSpeed.ToString();
        if((int)_playerSpeed > 35)
        {
            _rb.gravityScale = 15;
            Debug.Log("Previshaem");
        }
        else if ((int)_playerSpeed < 35)
        {
            _rb.gravityScale = 5;
            Debug.Log("Norm");
        }
    }
}

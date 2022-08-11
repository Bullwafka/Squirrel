using UnityEngine;
using UnityEngine.SceneManagement;

public class KillScript : MonoBehaviour
{
    [SerializeField] private GameObject _playerObj;
    private Animation _animation;
    private SpriteRenderer _spriteRenderer;
    private GameObject _gameObject;
    private Rigidbody2D _rb;
    private MoveScript _moveScript;
    private Score _score;

    private void Start()
    {
        _score = GetComponent<Score>();
        _spriteRenderer = _playerObj.GetComponent<SpriteRenderer>();
        _animation = GetComponent<Animation>();
        _rb = _playerObj.GetComponent<Rigidbody2D>();
        _moveScript = GameObject.Find("PlayerObject").GetComponent<MoveScript>();
    }
    public void Kill()
    {
        if (_playerObj.activeSelf)
        {
            _moveScript.BlockMove();
            _rb.velocity = new Vector2(0f, 0f);
            _rb.isKinematic = true;
            _spriteRenderer.color = new Color(255, 0, 0);
            _animation.Play("DeathAnim");
            _score.SaveRecord();
            Invoke("DisablePlayerObject", 1f);
            Invoke("RestartScene", 2f);
        }
    }
    public void DisableObject(GameObject gameObject)
    {
        _gameObject = gameObject;
        _gameObject.SetActive(false);
    }
    private void DisablePlayerObject()
    {
        _playerObj.SetActive(false);
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}

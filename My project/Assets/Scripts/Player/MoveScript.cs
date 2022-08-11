using UnityEngine;
[RequireComponent(typeof(Player))]
public class MoveScript : MonoBehaviour
{
    [SerializeField] private float _cheerfulVelocity;
    [SerializeField] private float _tiredVelocity;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _wallJumpForce;
    [SerializeField] private float _wallJumpVelocity;
    [SerializeField] private Rigidbody2D _playerObject;
    [SerializeField] private Vector2 _moveVector;
    [SerializeField] private float _positionX;
    [SerializeField] private float _positionY;
    [SerializeField] private static float _currentPositionX;

    private Player _player;
    private Transform _currentTransform;
    private bool _onTheLeftWall;
    private bool _onTheRightWall;
    private bool _onTheGround;
    private bool _blockMove;
    private float _wallJumpTimer;
    private float _velocity;


    private Touch _touch;


    private void Start()
    {
        _player = GetComponent<Player>();
        _velocity = _cheerfulVelocity;
        _currentPositionX = _playerObject.transform.localPosition.x;
    }
    private void Update()
    {
        Move();
        Jump(_jumpForce);
        WallJump(_jumpForce);
    }

    public void WallJump(float force)
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_onTheLeftWall && !_onTheGround && _touch.phase == TouchPhase.Began)
            {
                _blockMove = true;
                _playerObject.velocity = new Vector2(_wallJumpVelocity, _wallJumpForce);
            }
            else if (_onTheRightWall && !_onTheGround && _touch.phase == TouchPhase.Began)
            {
                _blockMove = true;
                _playerObject.velocity = new Vector2(-_wallJumpVelocity, _wallJumpForce);
            }
        }
        if (_blockMove && (_wallJumpTimer += Time.deltaTime) >= 0.4f)
        {
            if (_onTheGround || _onTheLeftWall || _onTheRightWall)
            {
                _blockMove = false;
                _wallJumpTimer = 0;
            }
        }

    }
    private void Jump(float force)
    {
        if (Input.touchCount > 0 && _player.JumpBlocked == false)
        {
            _touch = Input.GetTouch(0);

            if (_onTheGround == true && _touch.phase == TouchPhase.Began)
            {
                _player.ChangeStaminaValue(-1); 
                _playerObject.velocity = Vector2.zero;
                _playerObject.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
        }
    }

    public void Move()
    {
        if (_blockMove == false)
        {
            _moveVector.x = Input.acceleration.x;
            if(_moveVector.x > 0)
            {
                _playerObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if(_moveVector.x < 0)
            {
                _playerObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            _playerObject.velocity = new Vector2(_moveVector.x * _velocity, _playerObject.velocity.y);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "LeftBranch" || tag == "RightBranch")
        {
            _onTheGround = true;
        }
        else if (tag == "LeftWall")
        {
            _onTheLeftWall = true;
        }
        else if (tag == "RightWall")
        {
            _onTheRightWall = true;
        }
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        _onTheGround = false;
        _onTheLeftWall = false;
        _onTheRightWall = false;
    }

    public void BlockMove()
    {
        _blockMove = true;
    }
}

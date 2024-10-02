using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sideSpeedMultyplyer;
    [SerializeField] private ParticleSystem _bangEffect;
    [SerializeField] private ParticleSystem _bonusEffect;
    [SerializeField] private Animator _animator;
    private GameManager _gameManager;
    private float _sideSpeed;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    private bool _isSideMoving = false;
    private const string Left = "Left";
    private const string Right = "Right";
    private const string Obstacle = "Obstacle";
    private const string Bonus = "Bonus";
    private const string Wall = "Wall";

    public void DontMove()
    {
        _animator.SetBool(Left, false);
        _animator.SetBool(Right, false);
        _sideSpeed = 0;
        _isSideMoving = false;
    }

    public void MoveRight()
    {
        _animator.SetBool(Right, true);
        _sideSpeed = _sideSpeedMultyplyer;
        _isSideMoving = true;
    }

    public void MoveLeft()
    {
        _animator.SetBool(Left, true);
        _sideSpeed = -_sideSpeedMultyplyer;
        _isSideMoving = true;
    }
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Obstacle)
        {
            Instantiate(_bangEffect, transform.position, Quaternion.identity);
            _gameManager.GameOver();
            gameObject.SetActive(false);
        }
        if (other.tag == Bonus)
        {
            Instantiate(_bonusEffect, transform);
            _gameManager.AddScore();
            other.transform.parent.gameObject.SetActive(false);

        }
    }


    private void FixedUpdate()
    {
        _velocity = new Vector3(_sideSpeed, 0, _forwardSpeed);
        _rigidbody.velocity = _velocity;
    }
}

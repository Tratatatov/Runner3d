using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float ForwardSpeed;
    public float SideSpeedMultyplyer;
    public GameManager GameManager;
    public ParticleSystem Bang;
    public AudioSource BonusSound;
    public Animator Animator;
    private float sideSpeed;
    private Rigidbody rigidbody;
    private Vector3 velocity;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        velocity = new Vector3(sideSpeed, 0, ForwardSpeed);
        rigidbody.velocity = velocity;
    }
    public void DontMove()
    {
        Animator.SetBool("Left", false);
        Animator.SetBool("Right", false);
        sideSpeed = 0;
    }
    public void MoveRight()
    {
        Animator.SetBool("Right", true);
        sideSpeed = SideSpeedMultyplyer;
    }
    public void MoveLeft()
    {
        Animator.SetBool("Left", true);
        sideSpeed = -SideSpeedMultyplyer;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Instantiate(Bang, transform.position, Quaternion.identity);
        }
        if (other.tag == "Bonus")
        {
            BonusSound.Play();

        }
    }
}

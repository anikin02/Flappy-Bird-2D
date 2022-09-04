using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class BirdMover : MonoBehaviour
{   
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float speed;
    [SerializeField] private float tapForce = 10;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxRotationZ;
    [SerializeField] private float minRotationZ;

    private Rigidbody2D rigidbody;
    private Quaternion maxRotation;
    private Quaternion minRotation;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        maxRotation = Quaternion.Euler(0, 0, maxRotationZ);
        minRotation = Quaternion.Euler(0, 0, minRotationZ);

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {   
            GetComponent<Bird>().PlaySoundOfWing();
            rigidbody.velocity = new Vector2(speed, 0);
            transform.rotation = maxRotation;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, minRotation, rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rigidbody.velocity = Vector2.zero;
    }
}
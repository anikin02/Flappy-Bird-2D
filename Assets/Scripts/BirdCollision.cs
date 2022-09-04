using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollision : MonoBehaviour
{
    private Bird bird;

    private void Start()
    {
        bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.TryGetComponent(out ScoreZone scoreZone))
        {
            bird.AddScore();
        }
        else
        {
            bird.Die();
        }
    }
}

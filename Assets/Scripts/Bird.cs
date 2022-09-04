using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    [SerializeField] private AudioSource soundOfDeath;
    [SerializeField] private AudioSource soundOfGettingPoint;
    [SerializeField] private AudioSource soundOfWing;


    private BirdMover mover;
    private int score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        mover = GetComponent<BirdMover>();
    }

    public void AddScore()
    {
        score++;
        soundOfGettingPoint.Play();
        ScoreChanged(score);
    }

    public void ResetPlayer()
    {
        score = 0;
        ScoreChanged(score);
        mover.ResetBird();
    }

    public void PlaySoundOfWing()
    {
        soundOfWing.Play();
    }

    public void Die()
    {   
        soundOfDeath.Play();
        GameOver?.Invoke();
    }
}
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    [SerializeField] private AudioSource soundOfDeath;
    [SerializeField] private AudioSource soundOfGettingPoint;
    [SerializeField] private AudioSource soundOfWing;

    [SerializeField] private Sprite FirstBird;
    [SerializeField] private Sprite SecondBird;

    [SerializeField] private PipeSpawner spawner;

    private BirdMover mover;

    public int Record;
    private int score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> RecordChanged;

    private void Start()
    {
        mover = GetComponent<BirdMover>();
        RecordChanged(Record);
    }

    private void NewRecord()
    {
        if (score > Record)
        {
            Record = score;
            RecordChanged(Record);
        }
    }

    private void ChangeDificult()
    {   
        if (score == 0)
        {
            GetComponent<SpriteRenderer>().sprite = FirstBird;
        }
        if (score % 15 == 0)
        {
            mover.HardGame();
            spawner.HardGame();
            
            if (score / 30 == 1)
            {
                GetComponent<SpriteRenderer>().sprite = SecondBird;
            }
        }
    }

    public void AddScore()
    {
        score++;
        soundOfGettingPoint.Play();
        NewRecord();
        ScoreChanged(score);
        ChangeDificult();
        
    }

    public void ResetPlayer()
    {
        score = 0;
        ChangeDificult();
        ScoreChanged(score);
        spawner.ResetSpawner();
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
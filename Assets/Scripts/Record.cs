using UnityEngine.UI;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Text recordText;

    private void OnEnable()
    {
        bird.RecordChanged += OnRecordChanged;
    }

    private void OnDisable()
    {
        bird.RecordChanged -= OnRecordChanged;
    }

    private void OnRecordChanged(int record)
    {
        recordText.text = record.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float xOffset;

    private void Update()
    {
        transform.position = new Vector3(bird.transform.position.x - xOffset, transform.position.y, transform.position.z);
    }
}

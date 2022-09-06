using System;
using UnityEngine;

public class ChangeofDayAndNight : MonoBehaviour
{   
    [SerializeField] private Sprite day;
    [SerializeField] private Sprite night;

    private void Start()
    {
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        DateTime localDate = DateTime.Now;
        
        if ((localDate.Hour > 8) && (localDate.Hour < 18))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = day;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = night;
        }
    }
}

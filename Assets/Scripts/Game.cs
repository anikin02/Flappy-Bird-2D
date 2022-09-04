using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private PipeSpawner spawner;
    [SerializeField] private StartGame startGame;
    [SerializeField] private EndGame endGame;

    private void Start()
    {
        Time.timeScale = 0;
        startGame.Open();
    } 

    private void OnEnable()
    {
        startGame.PlayButtonClick += OnPlayButtonClick;
        endGame.RestartClick += OnRestartButtonClick;
        bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        startGame.PlayButtonClick -= OnPlayButtonClick;
        endGame.RestartClick -= OnRestartButtonClick;
        bird.GameOver -= OnGameOver;
    }

    private void OnPlayButtonClick()
    {
        startGame.Close();
        NewGame();
    }

    private void OnRestartButtonClick()
    {
        endGame.Close();
        spawner.ResetPool(); 
        NewGame(); 
    }

    private void NewGame()
    {
        Time.timeScale = 1;
        bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        endGame.Open();
    }
}

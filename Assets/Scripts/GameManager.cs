using EasyAudioSystem;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GPG212_04
{
    public class GameManager : MonoBehaviour
    {
        public static Action OnGameOver;

        [SerializeField] private GameObject timerPanel;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private GameObject postGamePanel;

        private bool _isGameTimed;
        private bool _isTimerRunning = true;
        private float _startingTime = 30f;
        private float _currentTime = 30f;

        private void Start()
        {
            _isGameTimed = TitleScreen.isGameTimed;

            if (!_isGameTimed)
            {
                timerPanel.GetComponent<Button>().enabled = true;
            }
            else
            {
                timerText.text = _startingTime.ToString("00.00");
                _startingTime = _currentTime;
            }
        }
        private void Update()
        {
            if (_isGameTimed && _isTimerRunning)
            {
                _currentTime -= Time.deltaTime;
                timerText.text = _currentTime.ToString("00.00");

                if (_currentTime <= 0)
                {
                    OnGameOver?.Invoke();
                }
            }
        }

        private void GameOver()
        {
            _isTimerRunning = false;
            timerText.text = "DONE";
            postGamePanel.SetActive(true);
            AudioManager.PlayAudio("Finish");
        }

        public void ToggleIsTimerRunning()
        {
            _isTimerRunning = !_isTimerRunning;
        }

        private void OnEnable()
        {
            OnGameOver += GameOver;
        }
        private void OnDisable()
        {
            OnGameOver -= GameOver;
        }
    }
}

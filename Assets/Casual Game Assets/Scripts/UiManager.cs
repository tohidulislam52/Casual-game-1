using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] public float _helth;
    [SerializeField] public int _lap;
    [Header("Components")]
    [SerializeField] private Slider _helthSlider;
    [SerializeField] private GameObject _gameoverPanel;
    [SerializeField] public GameObject _ingamePanel;
    [SerializeField] private ParticleSystem[] _partical;
    [SerializeField] private GameObject _GameFinishPanel;
    [SerializeField] private GameObject _levelFinishPanel; 


    [Header("Action")]
    public static Action<int> OnPlayerChange;
    

    void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    void Start()
    {
        ActivePanel();
    }
    

    void Update()
    {
        _helthSlider.value = _helth / 100;
        LapCount();
    }

    private void LapCount()
    {
        if(_lap == 0 && _helth >= 100)
        {
            _lap = 1;
            _helth = 0;
            OnPlayerChange?.Invoke(_lap);
            // OnPlayerChange?.Invoke();
        }
        else if(_lap == 1 && _helth>= 100)
        {   
            _lap = 2;
            _helth = 0;
            OnPlayerChange?.Invoke(_lap);
        }
    }

    private void ActivePanel()
    {
        _ingamePanel.SetActive(true);
        _GameFinishPanel.SetActive(false);
        _gameoverPanel.SetActive(false);
        _levelFinishPanel.SetActive(false);
    }
    public void GameOverUI()
    {
        _gameoverPanel.SetActive(true);
    }
    public void GameFinishUI()
    {
        _GameFinishPanel.SetActive(true);
    }
    public void Party()
    {
        _partical[UnityEngine.Random.Range(0,_partical.Length)].Play();
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void FinishGame()
    {
        _GameFinishPanel.SetActive(false);
        _levelFinishPanel.SetActive(true);
    }

    
    









}

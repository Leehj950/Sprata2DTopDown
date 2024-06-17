using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private string playerTag;
    public ObjectPool ObjectPool { get; private set; }
    public Transform Player { get; private set; }
    public ParticleSystem EffectParticle;

    private HealthSystem playerhealthSystem;

    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Slider hpgaugeSlider;
    [SerializeField] private GameObject gameoverUI;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        ObjectPool = GetComponent<ObjectPool>();
        EffectParticle = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();

        playerhealthSystem = Player.GetComponent<HealthSystem>();
        playerhealthSystem.OnDamage += UpdateHealthUI;
        playerhealthSystem.OnHeal += UpdateHealthUI;
        playerhealthSystem.OnDeath += Gameover;
    }

    private void UpdateHealthUI()
    {
        hpgaugeSlider.value = playerhealthSystem.CurrentHealth / playerhealthSystem.MaxHealth;
    }


    private void Gameover()
    {
        gameoverUI.SetActive(true);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

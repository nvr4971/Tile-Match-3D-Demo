using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] private Image comboFillImage;
    [SerializeField] private float comboTime;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text comboText;

    private int score;
    private int scoreMultiplier;

    private void Start()
    {
        score = 0;
        scoreMultiplier = 1;

        comboFillImage.fillAmount = 0f;
    }

    private void Update()
    {
        if (comboFillImage.fillAmount > 0)
        {
            comboFillImage.fillAmount -= 1.0f / comboTime * Time.deltaTime;
        }
        else
        {
            scoreMultiplier = 1;
        }
    }

    public void AddScore()
    {
        score += 10 * scoreMultiplier;

        UpdateScoreText();

        scoreMultiplier++;
        comboFillImage.fillAmount = 1f;

        UpdateComboText();
    }

    private void UpdateComboText()
    {
        if (scoreMultiplier > 1)
        {
            comboText.gameObject.SetActive(true);
            comboText.text = "Combo x" + scoreMultiplier.ToString();
        }
        else
        {
            comboText.gameObject.SetActive(false);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

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

    [SerializeField] private GameObject selectedPiecesUIParent;

    [SerializeField] private List<SelectedPiece> selectedPiecesUI;
    [SerializeField] private List<Sprite> selectedPiecesSprite;

    [SerializeField] private GameObject PlayUI;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LoseUI;

    private void Start()
    {
        foreach (SelectedPiece i in selectedPiecesUIParent.transform.GetComponentsInChildren<SelectedPiece>())
        {
            selectedPiecesUI.Add(i);
        }

        PlayUI.SetActive(true);
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
    }

    public void AddPiece(Sprite pieceImg)
    {
        int foundIdx = selectedPiecesSprite.IndexOf(pieceImg);

        if (foundIdx != -1 /*&& selectedPiecesSprite[foundIdx + 1] == pieceImg*/)
        {
            selectedPiecesSprite.Insert(foundIdx, pieceImg);
        }
        else
        {
            selectedPiecesSprite.Add(pieceImg);
        }

        UpdateSelectedPiecesUI();

        MatchCheck();

        // Check lose cond
        if (selectedPiecesSprite.Count == selectedPiecesUI.Count)
        {
            Lose();
            return;
        }

        if (PieceManager.Instance.IsAllPiecesClear())
        {
            Win();
            return;
        }
    }

    private void UpdateSelectedPiecesUI()
    {
        foreach (SelectedPiece i in selectedPiecesUI)
        {
            i.Disable();
        }

        for (int i = 0; i < selectedPiecesSprite.Count; i++)
        {
            selectedPiecesUI[i].Enable(selectedPiecesSprite[i]);
        }
    }

    private void MatchCheck()
    {
        for (int i = 0; i < selectedPiecesSprite.Count - 2; i++)
        {
            if (selectedPiecesSprite[i] == selectedPiecesSprite[i + 1] && selectedPiecesSprite[i] == selectedPiecesSprite[i + 2])
            {
                RemoveMatchedPieces(i);

                ScoreManager.Instance.AddScore();

                break;
            }
        }
    }

    private void RemoveMatchedPieces(int idx)
    {
        selectedPiecesSprite.RemoveRange(idx, 3);

        UpdateSelectedPiecesUI();
    }

    private void Win()
    {
        DisableGame();
        WinUI.SetActive(true);
        LoseUI.SetActive(false);
    }

    private void Lose()
    {
        DisableGame();
        WinUI.SetActive(false);
        LoseUI.SetActive(true);
    }

    private void DisableGame()
    {
        PlayUI.SetActive(false);
        Camera.main.GetComponent<FreeCam>().enabled = false;
    }
} 

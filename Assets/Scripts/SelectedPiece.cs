using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedPiece : MonoBehaviour
{
    [SerializeField] private Image pieceImage;

    public void Enable(Sprite img)
    {
        pieceImage.sprite = img;
        pieceImage.gameObject.SetActive(true);
    }

    public void Disable()
    {
        pieceImage.sprite = null;
        pieceImage.gameObject.SetActive(false);
    }

    public Sprite GetImage()
    {
        return pieceImage.sprite;
    }
}

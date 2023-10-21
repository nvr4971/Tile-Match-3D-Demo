using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Piece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRendererFront;
    [SerializeField] private SpriteRenderer _spriteRendererBack;

    private Sprite pieceImage;

    private void LoadImage()
    {
        if (pieceImage != null)
        {
            _spriteRendererFront.sprite = pieceImage;
            _spriteRendererBack.sprite = pieceImage;
        }
    }

    public void SetImage(Sprite img)
    {
        pieceImage = img;

        LoadImage();
    }

    public Sprite GetImage()
    {
        return pieceImage;
    }
}

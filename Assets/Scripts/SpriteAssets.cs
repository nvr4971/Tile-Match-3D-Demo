using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAssets : MonoBehaviour
{
    public static SpriteAssets Instance { get; private set; }

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

    [SerializeField] private List<Sprite> pieceSprites;

    public Sprite GetPieceSprite(int index)
    {
        return pieceSprites[index];
    }

    public int GetPieceSpriteCount()
    {
        return pieceSprites.Count;
    }
}

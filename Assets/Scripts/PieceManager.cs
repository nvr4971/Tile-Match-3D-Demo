using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public static PieceManager Instance { get; private set; }

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

    [SerializeField] private Piece piecePrefab;

    [SerializeField] private List<Piece> activePieces;

    private void Start()
    {
        Camera.main.GetComponent<FreeCam>().enabled = false;

        StartCoroutine(GeneratePieces());
    }

    private IEnumerator GeneratePieces()
    {
        List<int> spriteLst = GenerateIndexList();

        foreach (int i in spriteLst)
        {
            SpawnPiece(SpriteAssets.Instance.GetPieceSprite(i));
            yield return new WaitForSeconds(0.2f);
        }

        yield return Camera.main.GetComponent<FreeCam>().enabled = true;
    }

    private List<int> GenerateIndexList()
    {
        List<int> indexLst = new();

        for (int i = 0; i < SpriteAssets.Instance.GetPieceSpriteCount(); i++)
        {
            for (int j = 0; j < 3; j++)
            {
                indexLst.Add(i);
            }
        }

        System.Random rng = new();

        return indexLst.OrderBy(_ => rng.Next()).ToList();
    }

    private void SpawnPiece(Sprite img)
    {
        Piece piece = Instantiate(piecePrefab, Random.insideUnitSphere * 3.5f + transform.position, Random.rotation, transform);

        piece.SetImage(img);

        activePieces.Add(piece);
    }

    public void RemovePiece(Piece piece)
    {
        activePieces.Remove(piece);

        Destroy(piece.gameObject);
    }

    public bool IsAllPiecesClear()
    {
        return activePieces.Count == 0;
    }
}

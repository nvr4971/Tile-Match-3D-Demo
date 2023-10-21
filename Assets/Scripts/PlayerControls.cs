using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private void Update()
    {
        // Selecting pieces
        if (Input.GetMouseButtonDown(0) && Camera.main.GetComponent<FreeCam>().enabled == true)
        {
            RaycastHit hitInfo = new();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

			if (hit)
			{
                bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

                GameObject hitObject = hitInfo.transform.gameObject;

                if (hitObject.CompareTag("Piece") && !isOverUI)
                {
                    UIManager.Instance.AddPiece(hitObject.GetComponent<Piece>().GetImage());

                    PieceManager.Instance.RemovePiece(hitObject.GetComponent<Piece>());
                }
			}
		}
    }
}

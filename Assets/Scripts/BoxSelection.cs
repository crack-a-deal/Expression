using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelection : MonoBehaviour
{
    private LineRenderer lineRend;
    private Vector2 initialMousePosition, currentMousePosition;
    private BoxCollider2D boxColl;

    public List<PieceController> selectedPieces;

    public Color selectorColor { get; private set; }

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 0;
        selectorColor = Color.white;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !PieceController.mouseOver)
        {
            lineRend.positionCount = 4;
            initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(1, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(2, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(3, new Vector2(initialMousePosition.x, initialMousePosition.y));

            boxColl = gameObject.AddComponent<BoxCollider2D>();
            boxColl.isTrigger = true;
            boxColl.offset = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        if (Input.GetMouseButton(0) && !PieceController.mouseOver)
        {
            currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(1, new Vector2(initialMousePosition.x, currentMousePosition.y));
            lineRend.SetPosition(2, new Vector2(currentMousePosition.x, currentMousePosition.y));
            lineRend.SetPosition(3, new Vector2(currentMousePosition.x, initialMousePosition.y));

            transform.position = (currentMousePosition + initialMousePosition) / 2;

            boxColl.size = new Vector2(
                Mathf.Abs(initialMousePosition.x - currentMousePosition.x),
                Mathf.Abs(initialMousePosition.y - currentMousePosition.y));
                
            UpdateSelectorColor();
        }

        if (Input.GetMouseButtonUp(0))
        {
            foreach (PieceController piece in selectedPieces)
                piece.UpdateColor(selectorColor);

            lineRend.positionCount = 0;
            Destroy(boxColl);
            transform.position = Vector3.zero;
            selectorColor = Color.white;
            ClearPiecesList();
        }
    }

    public void AddToSelectedList(PieceController piece)
    {
        if (selectedPieces.Contains(piece))
            return;
        selectedPieces.Add(piece);
    }

    public void RemoveToSelectedList(PieceController piece)
    {
        if(selectedPieces.Contains(piece))
            selectedPieces.Remove(piece);
    }
    public void ClearPiecesList() => selectedPieces.Clear();
    public void UpdateSelectorColor()
    {
        if (selectedPieces.Count == 0)
            SetSelectorColor(Color.white);
        else
            SetSelectorColor(selectedPieces[0].CurrentColor);
    }

    private void SetSelectorColor(Color newColor)
    {
        selectorColor = newColor;
        lineRend.startColor = newColor;
        lineRend.endColor = newColor;
    }
} 

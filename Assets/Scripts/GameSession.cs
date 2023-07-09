using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public List<PieceController> allPieces;
    private bool isEnd = false;

    public void Update()
    {
        if(!isEnd)
            CheackWinCondition();
    }

    //������� ��� ������� �� ������ � ��������� �� ��� ������
    private void FindAllPieces()
    {
        foreach (PieceController pieceToAdd in UnityEngine.Object.FindObjectsOfType<PieceController>())
            AddPiecetoList(pieceToAdd);
    }

    //��������� ������� � ������
    //���� �� ��� ��������� � ���, �� ������� �����������
    private void AddPiecetoList(PieceController piece)
    {
        if(allPieces.Contains(piece))
            return;
        allPieces.Add(piece);
    }

    //��������� ������������ ������ ��� ���� �������� �� ������
    //���� ��� �����, �� ��������� �������
    private void CheackWinCondition()
    {
        if (allPieces.Count == 0)
            FindAllPieces();
            
        foreach (PieceController allPiece in allPieces)
            if (!allPiece.IsWinColor)
            {
                //Debug.Log(allPiece.name);
                return;
            }
        //��������� �������
        Debug.Log("endendend");
        LaunchVictory();
    }

    //������� ���������� ������
    //��������� � ���������� ������
    private void LaunchVictory()
    {
        //���� ���������� ������
        isEnd = true;
        FindObjectOfType<SceneTransition>().NextLevel();
    }
}

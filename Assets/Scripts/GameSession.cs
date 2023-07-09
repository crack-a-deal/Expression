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

    //Ќаходит все кусочки на уровне и формирует из них массив
    private void FindAllPieces()
    {
        foreach (PieceController pieceToAdd in UnityEngine.Object.FindObjectsOfType<PieceController>())
            AddPiecetoList(pieceToAdd);
    }

    //ƒобавл€ет кусочек в массив
    //если он уже находитс€ в нем, то функци€ завершаетс€
    private void AddPiecetoList(PieceController piece)
    {
        if(allPieces.Contains(piece))
            return;
        allPieces.Add(piece);
    }

    //ѕровер€ет правильность цветов дл€ всех кусочков на уровне
    //если все верно, но завершает уровень
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
        //«авершить уровень
        Debug.Log("endendend");
        LaunchVictory();
    }

    //‘ункци€ завершени€ уровн€
    //переходит к следующему уровню
    private void LaunchVictory()
    {
        //звук завершени€ уровн€
        isEnd = true;
        FindObjectOfType<SceneTransition>().NextLevel();
    }
}

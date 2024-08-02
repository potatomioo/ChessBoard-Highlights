using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Scripts.Core;

public class KingMov : ChessPiece{

    public int row;
    public int col;

    private void OnMouseDown()
    {
        if (last == this) {
            ChessBoardPlacementHandler.Instance.ClearHighlights();
            last = null;
        } else {
            ChessBoardPlacementHandler.Instance.ClearHighlights();
            CalculatePossibleMoves(row, col);
            last = this;
        }
    }

    public override void CalculatePossibleMoves(int row, int col){
        ChessBoardPlacementHandler.Instance.ClearHighlights();
         
        int[,] dist= {
            {1, 0}, {-1, 0}, {0, 1}, {0, -1},
            {1, 1}, {-1, -1}, {1, -1}, {-1, 1}
        };


        for(int i = 0;i<dist.GetLength(0);i++){
            int dr = dist[i,0];
            int dc = dist[i,1];
            int nrow = row + dr;
            int ncol = col + dc;
            if (IsWithinBounds(nrow, ncol)) {
                Debug.Log($"Visiting ({nrow}, {ncol})");
                if(ChessBoardPlacementHandler.Instance.isocc(nrow,ncol) == "Black"){
                    continue;
                }
                else if(ChessBoardPlacementHandler.Instance.isocc(nrow,ncol) == "White"){
                        opposeHL.Instance.Highlight(nrow, ncol);
                        Debug.Log($"opponent detected ({nrow},{ncol})");
                        continue;
                }
                else{
                    ChessBoardPlacementHandler.Instance.Highlight(nrow, ncol);
                }
            }
            else {
                Debug.Log($"Position ({nrow}, {ncol}) is out of bounds or occupied");
            }
        }
    }

    private bool IsWithinBounds(int i,int j){
        return i>=0 && i<8 && j>=0 && j<8;
    }
}

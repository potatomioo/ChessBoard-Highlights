using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
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
            {1,1},{-1,1},{1,-1},{-1,-1},{0,1},{1,0},{-1,0},{0,-1}
        };


        for(int i = 0;i<dist.GetLength(0);i++){
            int dr = dist[i,0];
            int dc = dist[i,1];
            int nrow = row + dr;
            int ncol = col + dc;
            while(IsWithinBounds(nrow,ncol)){
                if(ChessBoardPlacementHandler.Instance.isocc(nrow,ncol) == "Black") break;
                if(ChessBoardPlacementHandler.Instance.isocc(nrow,ncol) == "White"){
                    opposeHL.Instance.Highlight(nrow,ncol);
                    break;
                }
                ChessBoardPlacementHandler.Instance.Highlight(nrow, ncol);
                nrow += dist[i,0];
                ncol += dist[i,1];
            }
        }
    }

    private bool IsWithinBounds(int i,int j){
        return i>=0 && i<8 && j>=0 && j<8;
    }
}

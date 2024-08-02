using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawns : ChessPiece
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
        if(row == 1){
            if (IsWithinBounds(row, col)) {
                if(ChessBoardPlacementHandler.Instance.isocc(row+1,col) == ""){
                ChessBoardPlacementHandler.Instance.Highlight(row+1,col);
                if(ChessBoardPlacementHandler.Instance.isocc(row+2,col) == ""){
                ChessBoardPlacementHandler.Instance.Highlight(row+2,col);
                }
                }
            }
        }
        else{
            if (IsWithinBounds(row, col)) {
                if(ChessBoardPlacementHandler.Instance.isocc(row+1,col) == ""){
                ChessBoardPlacementHandler.Instance.Highlight(row+1,col);
                }
            }
        }

        //for opponents
        if(ChessBoardPlacementHandler.Instance.isocc(row+1,col-1) == "White"){
            opposeHL.Instance.Highlight(row+1,col-1);
        }
        if(ChessBoardPlacementHandler.Instance.isocc(row+1,col+1) == "White"){
            opposeHL.Instance.Highlight(row+1,col+1);
        }
    }

    private bool IsWithinBounds(int i,int j){
        return i>=0 && i<8 && j>=0 && j<8;
    }
}

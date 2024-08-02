using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public static ChessPiece last;
    public abstract void CalculatePossibleMoves(int row, int column);
}

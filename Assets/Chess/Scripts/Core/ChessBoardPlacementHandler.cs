using System;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]

public sealed class ChessBoardPlacementHandler : MonoBehaviour {
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;
    private GameObject[,] _chessBoard;
    // private bool[,] occupancyArray;
    private string[,] occupancyArray;


    internal static ChessBoardPlacementHandler Instance;


    private void Awake() {
        Instance = this;
        GenerateArray();
        // InitializeOccupancyArr();
        InitializeOccupancyArr();
    }

    private void GenerateArray() {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    // private void InitializeOccupancyArr() {
    //     occupancyArray = new bool[8, 8];
    // }
    private void InitializeOccupancyArr() {
        occupancyArray = new string[8, 8];
    }

    internal GameObject GetTile(int i, int j) {
        try {
            return _chessBoard[i, j];
        } catch (Exception) {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int row, int col) {
        Debug.Log($"Highlighting tile at ({row}, {col})");
        var tile = GetTile(row, col)?.transform;
        if (tile == null) {
            Debug.LogError("Invalid row or column.");
            return;
        }

        Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    internal void ClearHighlights() {
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform) {
                    Destroy(childTransform.gameObject);
                }
            }
        }
    }

    // I am making this method to mark the positions of pieces in occupy array. This is to check the empty spaces.
    // internal void mark(int i,int j){
    //     occupancyArray[i,j] = true;
    // }

    // internal bool isocc(int i,int j){
    //     if(occupancyArray[i,j] == true) return true;
    //     return false;
    // }

    internal void markWhite(int i,int j){
        occupancyArray[i,j] = "White";
    }
    internal void markBlack(int i,int j){
        occupancyArray[i,j] = "Black";
    }

    internal string isocc(int i,int j){
        return ($"{occupancyArray[i,j]}");
    }

    internal string valret(int i,int j){
        return ($"({i},{j}) is ({occupancyArray[i,j]})");
    }

}
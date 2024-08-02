using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Scripts.Core;

public class opposeHL : MonoBehaviour
{
    [SerializeField] private GameObject _highlightPrefab;

    internal static opposeHL Instance;

    private void Awake() {
        Instance = this;
    }


    internal void Highlight(int row, int col) {
        Debug.Log($"Highlighting tile at ({row}, {col})");
        var tile = ChessBoardPlacementHandler.Instance.GetTile(row, col)?.transform;
        if (tile == null) {
            Debug.LogError("Invalid row or column.");
            return;
        }

        Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }
}

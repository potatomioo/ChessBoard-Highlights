using System;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {

        [SerializeField] public int row,column;
        public string piece;

        private void Start() {
            Debug.Log("started");
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
            // ChessBoardPlacementHandler.Instance.mark(row,column);
            if(piece == "Black"){
                ChessBoardPlacementHandler.Instance.markBlack(row,column);
            }
            else if(piece == "White"){
                ChessBoardPlacementHandler.Instance.markWhite(row,column);
            }
        }
    }
}
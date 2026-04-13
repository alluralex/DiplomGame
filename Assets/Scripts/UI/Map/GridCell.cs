using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Field
{
    public class GridCell
    {
        public int X;
        public int Y;
        public CellState State;
        public GameObject WorldObject;
        public Button UIButton;       
    }

    public enum CellState
    {
        Locked,     
        Available,  
        Purchased   
    }
}
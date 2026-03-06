using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using static Cubes;

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
        Locked,     // Красная на минимапе
        Purchased,  // Синяя на минимапе
    }
}

using System;
using UnityEngine;

namespace Grid
{
  public class GridManager : MonoBehaviour
  {
    private Grid _grid;
    private void Start()
    {
      _grid = new Grid(10, 10);
    }
  }
}

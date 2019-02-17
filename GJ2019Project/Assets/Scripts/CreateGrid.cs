using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public GameObject cube;

    public int horCells = 10;
    public int verCells = 10;
    public Vector3 startPos = new Vector3(0f, 0f, 0f);
    public float spacingX = 1f;
    public float spacingY = 1f;

    public GameObject[,] cellsArray;

    void Start()
    {
        MakeGrid(horCells, verCells);
    }

    void MakeGrid(int hor, int vert)
    {
        cellsArray = new GameObject[hor, vert];
        GameObject clone;
        Vector3 clonePos;
        for (int x = 0; x < hor; ++x)
        {
            for (int y = 0; y < vert; ++y)
            {
                clonePos = new Vector3(startPos.x + (x * spacingX), startPos.y + (y * spacingY), startPos.z);
                clone = Instantiate(cube, clonePos, Quaternion.identity) as GameObject;
                clone.name = (y + 1) + "x" + (x + 1);
                cellsArray[x, y] = clone;
            }
        }
    }

    private void Update()
    {


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePlacer : MonoBehaviour
{
    
    private Grid grid;
    public GameObject Cube_L1;
    public GameObject Cube_L2;
    public GameObject Cube_L3;

    // Cubes: 1, 2 , 3
    public int CurrCube = 1;

    public GameObject CurrCubeSelect; 

    // Number of Cubes Available for placement 
    public int CubeCount_L1 = 3;
    public int CubeCount_L2 = 3;
    public int CubeCount_L3 = 3;


    // UI 
    public Text CubeText_L1;
    public Text CubeText_L2;
    public Text CubeText_L3;

    string TempText = ""; 
    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void Update()
    {
       // ValidPosCheck();
        ChangeCube();
        Countupdate();
        PlaceObj();
        TestObj();
    }

    public void PlaceObj()
    {
        // Left click places a cube  at spot 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {

                if (CurrCube == 1 && CubeCount_L1 >= 1)
                {
                    PlaceCubeNear(hitInfo.point);
                    CubeCount_L1--;
                }
                if (CurrCube == 2 && CubeCount_L2 >= 1)
                {
                    PlaceCubeNear(hitInfo.point);
                    CubeCount_L2--;
                }
                if (CurrCube == 3 && CubeCount_L3 >= 1)
                {
                    PlaceCubeNear(hitInfo.point);
                    CubeCount_L3--;
                }

            }

        }

    }
    public void TestObj()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceTestObj(hitInfo.point);
            }
        }
    }


    public void Countupdate()
    {
        CubeText_L1.text = "Count 1: " + CubeCount_L1.ToString();
        CubeText_L2.text = "Count 2: " + CubeCount_L2.ToString();
        CubeText_L3.text = "Count 3: " + CubeCount_L3.ToString();

    }


    public void ValidPosCheck()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            PlaceCubeNear(hitInfo.point);
        }

    }

    // Changes cube 
    public void ChangeCube()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrCube = 1; 
            CurrCubeSelect = Cube_L1;
            TempText = "Current Cube: " + CurrCube.ToString();
            Debug.Log(TempText);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrCube = 2;
            CurrCubeSelect = Cube_L2;
            TempText = "Current Cube: " + CurrCube.ToString();
            Debug.Log(TempText);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrCube = 3; 
            CurrCubeSelect = Cube_L3;
            TempText = "Current Cube: " + CurrCube.ToString();
            Debug.Log(TempText);

        }

    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = finalPosition;

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }

    private void PlaceTestObj(Vector3 clickPoint)
    {
       //var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        //                bluePortal = (GameObject)Instantiate(bluePortalPrefab, hit.point + (Vector3.up * 0.5f), rotation);


        var objectPos = grid.GetNearestPointOnGrid(clickPoint);
        Instantiate(Cube_L2, objectPos, Quaternion.identity);
        Debug.Log("Trying to place shit"); 
    }
}
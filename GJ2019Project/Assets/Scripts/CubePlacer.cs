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

    public int CurrCube = 1;

    public GameObject CurrCubeSelect; 
    public int CubeCount_L1 = 3;
    public int CubeCount_L2 = 3;
    public int CubeCount_L3 = 3;

    public Text CubeText_L1;
    public Text CubeText_L2;
    public Text CubeText_L3;

   
    static bool c1 = true;
    static bool c2 = true;
    static bool c3 = true;
    // Current Cube Valid
    bool CCV = c1;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void Update()
    {
       // ValidPosCheck();
        ChangeCube();
        Countupdate();
        CheckCount(); 
        
        // Left click places a cube  at spot 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
                if(CurrCube == 1 && c1 == true)
                {
                    CubeCount_L1--;
                }
                if (CurrCube == 2 && c2 == true)
                {
                    CubeCount_L2--;
                }
                if (CurrCube == 3 && c3 == true)
                {
                    CubeCount_L3--;
                }

          
               
            }

        }
        //                bluePortal = (GameObject)Instantiate(bluePortalPrefab, hit.point + (Vector3.up * 0.5f), rotation);


    }
    public void Countupdate()
    {
        CubeText_L1.text = "Count 1: " + CubeCount_L1.ToString();
        CubeText_L2.text = "Count 2: " + CubeCount_L2.ToString();
        CubeText_L3.text = "Count 3: " + CubeCount_L3.ToString();

    }
    public void CheckCount()
    {
        if (CubeCount_L1 == 0)
        {
            c1 = false;
        }

        if (CubeCount_L2 == 0)
        {
            c2 = false;
        }

        if (CubeCount_L3 == 0)
        {
            c3 = false;
        }

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
            Debug.Log(CCV);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrCube = 2;
            CurrCubeSelect = Cube_L2;
            Debug.Log(CCV);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrCube = 3; 
            CurrCubeSelect = Cube_L3;
            Debug.Log(CCV);

        }

    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = finalPosition;

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }
}
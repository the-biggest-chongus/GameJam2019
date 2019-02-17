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
    public int CubeCount_L1 = 8;
    public int CubeCount_L2 = 8;
    public int CubeCount_L3 = 8;


    // UI 
    public Text CubeText_L1;
    public Text CubeText_L2;
    public Text CubeText_L3;



    // Temp string for printing 
    string TempText = "";

    // Keeps track of lane score. If == 5 then all lanes are complete 
    int score = 0; 

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        CubeText_L1.text = "Count 1: " + CubeCount_L1.ToString();
        CubeText_L2.text = "Count 2: " + CubeCount_L2.ToString();
        CubeText_L3.text = "Count 3: " + CubeCount_L3.ToString();
    }

    private void Update()
    {
       // ValidPosCheck();
        SelectCube();
        PlaceObj();
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
                if (hitInfo.transform.tag == "Placeable" && CurrCube == 1 && CubeCount_L1 >= 1)
                {
                    PlaceObj(hitInfo.point);
                    CubeCount_L1--;
                    CubeText_L1.text = "Count 1: " + CubeCount_L1.ToString();
                }
                if (hitInfo.transform.tag == "Placeable" && CurrCube == 2 && CubeCount_L2 >= 1)
                {
                    PlaceObj(hitInfo.point);
                    CubeCount_L2--;
                    CubeText_L2.text = "Count 2: " + CubeCount_L2.ToString();

                }
                if (hitInfo.transform.tag == "Placeable" && CurrCube == 3 && CubeCount_L3 >= 1)
                {
                    PlaceObj(hitInfo.point);
                    CubeCount_L3--;
                    CubeText_L3.text = "Count 3: " + CubeCount_L3.ToString();

                }
            }
        }

        // Deletes obj at mouse position
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Attempting to Destroy object ");
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                //Destroy(GameObject.Find(hitInfo.name));
                //PlaceTestObj(hitInfo.point);
                if (hitInfo.transform.tag == "cube_1")
                {
                    // Need to increase counter for deleted block 
                    CubeCount_L1++;
                    CubeText_L1.text = "Count 1: " + CubeCount_L1.ToString();
                    Destroy(hitInfo.collider.gameObject);

                }
                if (hitInfo.transform.tag == "cube_2")
                {
                    // Need to increase counter for deleted block 
                    CubeCount_L2++;
                    CubeText_L2.text = "Count 2: " + CubeCount_L2.ToString();
                    Destroy(hitInfo.collider.gameObject);

                }
                if (hitInfo.transform.tag == "cube_3")
                {
                    // Need to increase counter for deleted block 
                    CubeCount_L3++;
                    CubeText_L3.text = "Count 3: " + CubeCount_L3.ToString();
                    Destroy(hitInfo.collider.gameObject);

                }
            }
        }
    }

    // Uses numbers 1,2,3 to select Cube 
     
    public void SelectCube()
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

    // Instantiates object at nearest grid point 
    private void PlaceObj(Vector3 clickPoint)
    {
        var objectPos = grid.GetNearestPointOnGrid(clickPoint);
        objectPos += new Vector3(0.2f, 0, 0.2f);

        // Apply Offset 
        if (CurrCube == 1)
        {
            //objectPos += new Vector3(0, 0, 0.3f);
            Instantiate(CurrCubeSelect, objectPos, Quaternion.Euler(0, 65f,0));
        }
        if (CurrCube == 2)
        {
            //objectPos += new Vector3(0, 0, 0.3f);
            Instantiate(CurrCubeSelect, objectPos, Quaternion.Euler(0,  65f, 0));

        }
        if (CurrCube == 3)
        {
           //objectPos += new Vector3(0, 0, 0.3f);
            Instantiate(CurrCubeSelect, objectPos, Quaternion.Euler(0,  65f, 0));
        }
       // Debug.Log("Trying to place shit"); 
    }








}
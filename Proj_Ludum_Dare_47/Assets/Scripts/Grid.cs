using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int width;
    public int depth;
    public float sideLength = 1f;
    public GameObject gridPref;

    [SerializeField]
    public GameObject[,] gridArray;


    public void Start()
    {
        genGrid();
    }

    //if you want to set grid size in the inspector
    [ContextMenu("Generate Grid")]
    public void genGrid(/*int width, int depth*/)
    {
        
        gridArray = new GameObject[width, depth];
        for (int x = 0; x< gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                float xPos = x * (sideLength + 0.01f);
                float zPos = z * (sideLength + 0.01f);
                GameObject gridSquare = (GameObject)Instantiate(gridPref, new Vector3(xPos, 0f, zPos), Quaternion.identity);
                gridSquare.name = "Square " + x + ":" + z;
                gridSquare.transform.SetParent(this.gameObject.transform); 
                gridArray[x, z] = gridSquare.gameObject;
            }

        }

    }

    //if you want to use code to set the grid size
    public void genGrid(int width, int depth)
    {
        this.width = width;
        this.depth = depth;
        genGrid();
    
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseFunctionality : MonoBehaviour
{
    public Material hoverMat;
    public Material selectedMat;
    public Material oldMat;
    public Material invalidMat;
    public Transform selectedGrid;

    public int currentMask;

    public Transform hoveredGrid;
    Renderer selectionRenderer;
    // Start is called before the first frame update
    void Start()
    {
        currentMask = 1 << 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (hoveredGrid != null)
        {
            //get the rennderer of the last hovered targed
            selectionRenderer = hoveredGrid.GetComponent<Renderer>();
            if (hoveredGrid.tag != "filledGrid")
            {
                //reset it
                selectionRenderer.material = oldMat;
            }
            else if (hoveredGrid.tag == "filledGrid")
            { 
                //reset it
                selectionRenderer.material = selectedMat;
            }


            //null the old target
            hoveredGrid = null;
        }
       
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, currentMask))
        {
            //save the selection and get its renderer
            var selection = hit.transform;
            selectionRenderer = selection.GetComponent<Renderer>();
            hoveredGrid = selection;
            oldMat = selectionRenderer.material;

            // Hovering
            if (selectionRenderer != null && hoveredGrid.tag != "filledGrid")
            {
                selectionRenderer.material = hoverMat;

            }
            else if (selectionRenderer != null && hoveredGrid.tag == "filledGrid")
            {
                selectionRenderer.material = invalidMat;

            }
            if (Input.GetMouseButtonUp(0) && hoveredGrid != null && hoveredGrid.tag != "filledGrid")
            {
                selectGrid(hoveredGrid.gameObject);
            }

        }
    }

    private void selectGrid(GameObject selObject)
    {
        selObject.GetComponent<Renderer>().material = selectedMat;
        selObject.tag = "filledGrid";
    }
}

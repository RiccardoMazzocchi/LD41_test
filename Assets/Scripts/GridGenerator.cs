using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    public int height;
    public int width;

    public Transform gridVisual;

	// Use this for initialization
	void Start () {
        CreateGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateGrid()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Transform clone;
                clone = Instantiate(gridVisual, new Vector3(x, y, 0), Quaternion.identity) as Transform;
                clone.name = "Grid (" + x.ToString() + ", " + y.ToString() + ")";
                clone.transform.parent = transform;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Vector3 worldPosition;
    public GameObject other;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Cube")
                {
                    Debug.Log("SAKKKK");
                    Destroy(other);
                }
            }
        }*/
        if (Main_Menu.game_Started == 0)
        {
            this.transform.position = new Vector3(0, -100, 0);
        }
        if (Main_Menu.game_Started == 1)
        {
            this.transform.position = Input.mousePosition;
        }
    }
}

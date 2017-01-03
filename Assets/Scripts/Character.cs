using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour 
{
	private Grid m_grid;
	public int mov = 4;
	private bool pathInit = false;
	private List<Cell> selecteds = new List<Cell>();
	public GameObject point;

	private bool drawingLine = false;
	private Vector3 initPos;
    private List<Vector3> positions = new List<Vector3>();
    private List<GameObject> points = new List<GameObject>();

    private bool showGUI = false;

	void Update () 
	{
		CheckMouse();
	}

	private void CheckMouse()
	{
		if (Input.GetMouseButtonDown(0) && !drawingLine)
		{
			drawingLine = true;
			initPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                  Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                  0f);
        }
		if (Input.GetMouseButton(0))
		{
            Vector3 mouseWorld = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                             0f);

            if (Vector2.Distance(initPos, mouseWorld) >= 1f)
			{
				initPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                  Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                  0f);
                points.Add((GameObject)Instantiate(point, mouseWorld, Quaternion.identity));
                positions.Add(mouseWorld);
			}
		}
		if (Input.GetMouseButtonUp(0) && drawingLine)
		{
			drawingLine = false;
            ShowMenu();
            ConfirmPath();
		}

	}

	private bool GetNear(int x, int y)
	{
		int mx = (int)transform.position.x;
		int my = (int)transform.position.y;

		bool valid = false;

		if (x - 1 == mx && y == my) valid = true;
		else if (x == mx && y - 1 == my) valid = true;
		else if (x == mx && y + 1 == my) valid = true;
		else if (x + 1 == mx && y == my) valid = true;

		return valid;
	}

    private void ShowMenu()
    {
        showGUI = true;
    }

    public void ConfirmPath()
    {
        showGUI = false;

        for (int i = positions.Count; i > 0; i--)
        {
            positions.RemoveAt(i - 1);
            Destroy(points[i - 1]);
            points.RemoveAt(i - 1);
        }
    }
}

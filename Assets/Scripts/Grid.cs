using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	[HideInInspector]
	public  bool[,] data;

	public  int x = 5;
	public  int y = 5;
	public  GameObject cell;
	public Material vermell;
	public Transform charter;

	void Awake() {
		data = new bool[x, y];
		MakeRandomGrid ();
		MakeGrid();

	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void MakeRandomGrid()
	{
		var rand = new System.Random();
		for (int ix = 0; ix < x; ix++)
		{
			for (int iy = 0; iy < y; iy++)
			{
				//bool a = rand.Next(0, 2) == 0;
				//data[ix, iy] = a;
				data[ix, iy] = true;
			}
		}
	}

	public void NewCell(int x, int y, bool act)
	{
		GameObject CellObj = (UnityEngine.GameObject) Instantiate(cell, new Vector3(x, y, 0f), Quaternion.identity);
		if (!act) CellObj.GetComponent<Cell>().ChangeType(Cell.Types.nTrans);
	}

	public void MakeGrid() {
		bool sem = true;
		for (int ix = 0; ix < x; ix++) {
			for (int iy = 0; iy < y; iy++)
			{
				if (sem && data[ix, iy])
				{
					//charter.position = new Vector3(ix, iy, 0);
					charter.position = new Vector3(5, 5, 0);

					sem = false;
				}
				NewCell(ix, iy, data[ix, iy]);
			}
		}
	}
}

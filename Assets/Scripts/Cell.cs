using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour 
{
	public Material green, red, defol;
	public enum Types { trans = 0, nTrans = 1, box = 2 }
	private Types m_type = Types.trans;
	private bool selected = false;
	public bool Selected {
		get { return selected; }
		set {
			selected = value;
			if (value == true) GetComponent<Renderer>().material = green;
			else GetComponent<Renderer>().material = defol;
		} 
	}

	public void ChangeType(Types typex)
	{
		m_type = typex;
		if (typex == Types.nTrans) this.GetComponent<Renderer>().material = red;
	}

	public Types Type { get { return m_type; } set { m_type = value; } }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardHighlights : MonoBehaviour {

	public static BoardHighlights Instance{set; get;}

	public GameObject hightlightPrefab;
	private List<GameObject> highlights;

	private void Start ()
	{
		Instance = this;
		highlights = new List<GameObject> ();
	}

	private GameObject GetHightlightObject()
	{
		GameObject go = highlights.Find (g => !g.activeSelf);

		if(go == null)
		{
			go = Instantiate (hightlightPrefab);
			highlights.Add (go);
		}
		return go;
	}

	public void HighlightAllowedMoves(bool[,] moves)
	{
		for(int i =0 ;i< 8 ; i++)
		{
			
			for(int j =0 ;j< 8 ; j++)
			{
				if(moves[i,j])
				{
					GameObject go = GetHightlightObject ();
					go.SetActive (true);
					go.transform.position = new Vector3 (i + 0.5f, 0, j + 0.5f);
				
				}
				
			}
		}


	}

	public void Hidehighlights()
	{
		foreach (GameObject go in highlights)
			go.SetActive (false);
	}
}

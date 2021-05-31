using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public static BoardManager  Instance { set; get;}
	private bool [,] allowedMoves { set; get;}

	public Chessman [,] Chessmans{ set; get;}
	private Chessman selectedChessman;

	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSITE = 0.5f;

	private int selectionX = -1;
	private int selectionY=-1;

	public List <GameObject> chessmanPrefabs;
	private List <GameObject> activeChessman = new List<GameObject>();

	public bool isWhiteTurn = true;

	// private Quaternion orientaton = quaternion.Euler(0,180,0);

	private void Start()
	{
		Instance = this;
		SpawnAllChessman ();
	}

	private void Update()
	{
		UpdateSelection ();
		DrawChessboard ();

		if(Input.GetMouseButtonDown(0))
		{
			if(selectionX >= 0 && selectionY >= 0)
			{
				if(selectedChessman == null)
				{
					//select
					SelectChessman (selectionX, selectionY);
				}else{
					
					//move
					MoveChessman (selectionX, selectionY);
				}

			}
				
		}
	
	}

	private void SelectChessman (int x ,int y)
	{
		if (Chessmans [x, y] == null)
			return;
		if (Chessmans [x, y].isWhite != isWhiteTurn)
			return;

		allowedMoves = Chessmans [x, y].PossibleMove ();
		selectedChessman = Chessmans [x, y];
		BoardHighlights.Instance.HighlightAllowedMoves (allowedMoves);
	}
	 
	private void MoveChessman(int x , int y)
	{

		if(allowedMoves[x,y]==true)
		{
			Chessman c = Chessmans [x, y];
			if(c!=null && c.isWhite != isWhiteTurn)
			{
				//get piece
				//king  end
				if(c.GetType()== typeof(King))
				{
					//end game
					return;
				}

				activeChessman.Remove (c.gameObject);
				Destroy (c.gameObject);
			}
			Chessmans [selectedChessman.CurrentX, selectedChessman.CurrentY] = null;
			selectedChessman.transform.position = GetTileCenter (x, y);
			selectedChessman.SetPosition (x, y);
			Chessmans [x, y] = selectedChessman;
			isWhiteTurn = !isWhiteTurn;
		}
		BoardHighlights.Instance.Hidehighlights ();
		selectedChessman = null;
		
	}

	private void UpdateSelection()
	{
		if (!Camera.main)
			return;
		RaycastHit hit;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,25.0f,LayerMask.GetMask("ChessPlan")))
		{
			selectionX = (int)hit.point.x;
			selectionY = (int)hit.point.z;
		}else
		{
			selectionX = -1;
			selectionY = -1;
		}
	}

	private void SpawnChessman(int index , int x , int y)
	{
		GameObject go = Instantiate (chessmanPrefabs [index], GetTileCenter(x,y), Quaternion.identity)as GameObject;
		go.transform.SetParent (transform);
		Chessmans [x, y] = go.GetComponent <Chessman> ();
		Chessmans [x, y].SetPosition (x, y);
		activeChessman.Add (go);
	}

	private void SpawnAllChessman()
	{
		activeChessman = new List<GameObject> ();
		Chessmans = new Chessman[8, 8];

		//white

		//k
		SpawnChessman (0, 3,0);
		//q
		SpawnChessman (1, 4,0);
		//r
		SpawnChessman (2, 0,0);
		SpawnChessman (2, 7,0);
		//b
		SpawnChessman (3, 2,0);
		SpawnChessman (3, 5,0);
		//kn
		SpawnChessman (4, 1,0);
		SpawnChessman (4, 6,0);
		//s
		for(int i = 0 ; i <8;i++)
		{
			SpawnChessman (5, i, 1);
		}

		//black

		//k
		SpawnChessman (6, 4,7);
		//q
		SpawnChessman (7, 3,7);
		//r
		SpawnChessman (8, 0,7);
		SpawnChessman (8, 7,7);
		//b
		SpawnChessman (9, 2,7);
		SpawnChessman (9, 5,7);
		//kn
		SpawnChessman (10, 1,7);
		SpawnChessman (10, 6,7);
		//s
		for(int i = 0 ; i <8;i++)
		{
			SpawnChessman (11, i, 6);
		}

	}

	private Vector3 GetTileCenter(int x , int y)
	{
		Vector3 origin = Vector3.zero;
		origin.x += (TILE_SIZE * x) + TILE_OFFSITE;
		origin.z += (TILE_SIZE * y) + TILE_OFFSITE;
		return origin;
	}

	private void DrawChessboard()
	{
		Vector3 widthLine = Vector3.right * 8;
		Vector3 heightLine = Vector3.forward * 8;

		for(int i = 0; i<=8;i++)
		{
			Vector3 start = Vector3.forward * i;
			Debug.DrawLine (start, start + widthLine);
			for(int j = 0 ; j<=8 ;j++)
			{
				start = Vector3.right * j;
				Debug.DrawLine (start, start + heightLine);
			}
		}

		if(selectionX >=0 && selectionY >= 0 )
		{
			Debug.DrawLine(
				Vector3.forward*selectionY+Vector3.right*selectionX,
				Vector3.forward*(selectionY+1)+Vector3.right*(selectionX+1));
			Debug.DrawLine(
				Vector3.forward*(selectionY+1)+Vector3.right*selectionX,
				Vector3.forward*selectionY+Vector3.right*(selectionX+1));
		}
	}

}

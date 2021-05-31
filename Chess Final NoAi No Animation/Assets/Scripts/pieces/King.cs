using UnityEngine;
using System.Collections;

public class King : Chessman {

	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];

		// up
		KingMove(CurrentX + 1, CurrentY, ref r); 
		// down
		KingMove(CurrentX - 1, CurrentY, ref r); 
		// left
		KingMove(CurrentX, CurrentY - 1, ref r);
		//right
		KingMove(CurrentX, CurrentY + 1, ref r); 
		// up left
		KingMove(CurrentX + 1, CurrentY -1, ref r);
		// down left
		KingMove(CurrentX - 1, CurrentY -1, ref r); 
		// up right
		KingMove(CurrentX +1, CurrentY + 1, ref r); 
		// down right
		KingMove(CurrentX - 1, CurrentY + 1, ref r); 

		return r;
	}

	public void KingMove(int x, int y, ref bool[,] r)
	{
		Chessman c;
		if (x >= 0 && x < 8 && y >= 0 && y < 8)
		{
			c = BoardManager.Instance.Chessmans[x, y];
			if (c == null)
				r[x, y] = true;
			else if (isWhite != c.isWhite)
				r[x, y] = true;
		}
	}
}﻿
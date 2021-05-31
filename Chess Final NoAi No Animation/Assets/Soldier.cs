using UnityEngine;
using System.Collections;

public class Soldier : Chessman {

	public override bool [,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];
		Chessman c, c2;

		//white team move
		if(isWhite)
		{
			//dleft
			if(CurrentX !=0 && CurrentY !=7)
			{
				c = BoardManager.Instance.Chessmans [CurrentX - 1, CurrentY + 1];
				if (c != null && !c.isWhite)
					r [CurrentX - 1, CurrentY + 1] = true;
			}
			//dright
			if(CurrentX !=7 && CurrentY !=7)
			{
				c = BoardManager.Instance.Chessmans [CurrentX + 1, CurrentY + 1];
				if (c != null && !c.isWhite)
					r [CurrentX + 1, CurrentY + 1] = true;
			}
			//middle
			if(CurrentY != 7)
			{
				c = BoardManager.Instance.Chessmans[CurrentX,CurrentY+1];
				if(c==null)
					r[CurrentX,CurrentY+1] = true;
			}
			//middlefirst
			if(CurrentY ==1)
			{
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 1];
				c2 = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 2];
				if (c == null && c2 == null)
					r [CurrentX, CurrentY + 2] = true;
			}

		}else{
			//black

				//dleft
				if(CurrentX !=0 && CurrentY !=0)
				{
					c = BoardManager.Instance.Chessmans [CurrentX - 1, CurrentY - 1];
					if (c != null && c.isWhite)
						r [CurrentX - 1, CurrentY - 1] = true;
				}
				//dright
				if(CurrentX !=7 && CurrentY !=0)
				{
					c = BoardManager.Instance.Chessmans [CurrentX + 1, CurrentY - 1];
					if (c != null && c.isWhite)
						r [CurrentX + 1, CurrentY - 1] = true;
				}
				//middle
				if(CurrentY != 0)
				{
					c = BoardManager.Instance.Chessmans[CurrentX,CurrentY-1];
					if(c==null)
						r[CurrentX,CurrentY-1] = true;
				}
				//middlefirst
				if(CurrentY == 6)
				{
					c = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 1];
					c2 = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 2];
					if (c == null && c2 == null)
						r [CurrentX, CurrentY - 2] = true;
				}


		}

		return r;
	}
}

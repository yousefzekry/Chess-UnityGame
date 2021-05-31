using UnityEngine;
using System.Collections;

public class Bishop : Chessman {

	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];

		Chessman c;
		int i, j;

		//topleft
		i = CurrentX;
		j = CurrentY;
		while(true)
		{
			i--;
			j++;
			if (i < 0 || j >= 8)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else
			{
				if (isWhite != c.isWhite)
					r [i, j] = true;

				break;
			}
		}

		//topright
		i = CurrentX;
		j = CurrentY;
		while (true) {
			i++;
			j++;
			if (i >= 8 || j >= 8)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isWhite != c.isWhite)
					r [i, j] = true;

				break;
			}

		}

		//downleft
		i = CurrentX;
		j = CurrentY;
		while (true) {
			i--;
			j--;
			if (i < 0 || j < 0)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isWhite != c.isWhite)
					r [i, j] = true;

				break;
			}

		}

		//downright
		i = CurrentX;
		j = CurrentY;
		while (true) {
			i++;
			j--;
			if (i >= 8 || j < 0)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isWhite != c.isWhite)
					r [i, j] = true;

				break;
			}

		}

		return r;
	}
}

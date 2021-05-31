using UnityEngine;
using System.Collections;

public class Queen : Chessman {

	public override bool [,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];

		Chessman c;
		int i, j;

		// right

		i = CurrentX;
		while (true) {
			i++;
			if (i >= 8)
				break;


			c = BoardManager.Instance.Chessmans [i, CurrentY];
			if (c == null)
				r [i, CurrentY] = true;
			else {
				if (c.isWhite != isWhite)
					r [i, CurrentY] = true;

				break;
			}

		}

		//left
		i = CurrentX;
		while (true) {
			i--;
			if (i < 0)
				break;


			c = BoardManager.Instance.Chessmans [i, CurrentY];
			if (c == null)
				r [i, CurrentY] = true;
			else {
				if (c.isWhite != isWhite)
					r [i, CurrentY] = true;

				break;
			}

		}

		//Up
		i = CurrentY;
		while (true) {
			i++;
			if (i >= 8)
				break;


			c = BoardManager.Instance.Chessmans [CurrentX, i];
			if (c == null)
				r [CurrentX, i] = true;
			else {
				if (c.isWhite != isWhite)
					r [CurrentX, i] = true;

				break;
			}

		}


		//down
		i = CurrentY;
		while (true) {
			i--;
			if (i < 0)
				break;


			c = BoardManager.Instance.Chessmans [CurrentX, i];
			if (c == null)
				r [CurrentX, i] = true;
			else {
				if (c.isWhite != isWhite)
					r [CurrentX, i] = true;

				break;
			}

		}

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

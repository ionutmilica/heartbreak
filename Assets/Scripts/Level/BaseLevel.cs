using System;
using UnityEngine;
using System.Collections;
using Random = System.Random;

namespace Level
{
	public abstract class BaseLevel
	{
		protected int[,] _matrix;

		protected int _height;

		public int Height { get { return _height; } }

		protected int _width;

		public int Width { get { return _width; } }

		protected Random rand = new Random();

		protected Vector3 _startPosition;
		
		public int[,] GetMatrix()
		{
			return _matrix;
		}

		public virtual Vector3 GetStartingPosition()
		{
			return _startPosition;
		}

		protected void InitMatrix(int h, int w)
		{
			_height = h;
			_width = w;
			_matrix = new int[h, w];
			Reset ();
		}

		protected void Put(int x, int y, int value)
		{
			_matrix [x, y] = value;
		}

		protected int Get(int x, int y)
		{
			return _matrix[x, y];
		}

		protected int Random(int min, int max)
		{
			return rand.Next (min, max);
		}

		protected void Reset()
		{
			for (int i = 0; i < _height; i++) 
			{
				for (int j = 0; j < _width; j++)
				{
					_matrix[i, j] = 0;
				}
			}
		}
	}
}


using UnityEngine;
using System.Collections.Generic;
using HeartBreak;

namespace Level
{
    public class HeartLevel : BaseLevel
	{
		private List<Pair> coords = new List<Pair>();

		public HeartLevel(int height, int width)
		{
			InitMatrix(height, width);
			init();
		}

		public override Vector3 GetStartingPosition()
		{
			return new Vector3 (17f, 6f, 0f);
		}

		protected void init()
		{
			AddLevelBorder ();
			DelimitOutsideOfInside ();
			TilesSetup ();
			AddTraps ();
			AddMushrooms ();
			AddFinalHeart ();
			AddRobots ();
		}

		protected void AddLevelBorder()
		{
			List<int> xGrid = new List<int> { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,0,0,0,0,0,0,0,0,0,40,40,40,40,40,40,40,40,40,1,2,3,4,5,6,39,38,37,36,35,34,7,8,9,10,11,12,13,14,15,16,33,32,31,30,29,28,27,26,25,24,17,18,19,20,21,22,23 };
			List<int> yGrid = new List<int> { 20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,30,31,32,33,34,35,36,36,36,36,36,36,36,36,36,36,36,36,36,36,36,36,36,36,36,36,35,34,33,32,33,34,35 };

			for (int i = 0; i < xGrid.Count; i++) 
			{
				Put (xGrid[i], yGrid[i], yGrid[i] > 30 ? 11 : 10);
			}
		}

		protected void DelimitOutsideOfInside()
		{
			for (int i = 0; i < _height; i++) 
			{
				int status = 0;
			
				for (int j = 0; j < _width; j++) 
				{
					if (Helpers.IsLooselyEqual(Get (i, j), 10, 11) && status == 0) 
					{
						status = 1;
						continue;
					}

					if (Helpers.IsLooselyEqual(Get (i, j), 10, 11) && status == 1) 
					{	
						status = 0;
						continue;
					}

					Put (i, j, status == 0 ? -1 : 1);
				}
			}
		}

		void TilesSetup()
		{
			for (int i = 2; i < _height - 7; i += 3)
			{
				int left = getLeftBound(i);
				int right = getRightBound(i);
				
				generateTile(i, left, right);
			}
		}

		void AddTraps()
		{
			for (int i = 2; i < _height - 7; i += 3) 
			{
				for (int j = 0; j < _width; j++)
				{
					if (i + 1 == 6) continue;
					int currentTileType = Get(j, i);
					int upperTileType = Get(j, i + 1);
					
					if (upperTileType == 1 && currentTileType >= 2 && currentTileType <= 4 && Random (0, 100) < 15 + GameManager.level)
					{
						Put (j, i + 1, 6);
					}
				}
			}
		}

		protected void AddMushrooms()
		{
			for (int i = 2; i < _height - 7; i += 3) 
			{
				for (int j = 0; j < _width; j++)
				{
					int currentTileType = Get(j, i);
					//int upperTileType = Get(j, i + 1);
					
					if (currentTileType >= 2 && currentTileType <= 4 && Random(0, 100) < 3)
					{
						Put (j, i + 1, 9);
					}
				}
			}
		}

		protected void AddFinalHeart()
		{
			List<int> xes = new List<int> ();
			List<int> yes = new List<int> ();
			
			for (int i = _height - 1; i >= 1; i--) 
			{
				bool found = false;
				
				for (int j = 1; j < _width; j++)
				{
					if (Helpers.NotEqualStrict(Get (j - 1, i), 10, 11) && Get (j, i) == 1 && Helpers.IsBetween(Get(j, i - 1), 2, 4))
					{
						if ((j == 33 && i == 18) || (j == 33 && i == 22)) continue;
						
						xes.Add(j);
						yes.Add(i);
						found = true;
					}
				}
				
				if (found) break;
			}
			
			int heartPos = Random(0, xes.Count - 1);
			Put (xes[heartPos], yes[heartPos], 7);
		}

		public void AddRobots()
		{
			int robots = 0;
			int maxRobots = 3 > coords.Count ? coords.Count : 3;
			if (coords.Count > 0) 
			{
				maxRobots = Random(3, maxRobots);

				while (robots < maxRobots)
				{
					int tile = Random(0, coords.Count - 1);
					Put (coords[tile].x, coords[tile].y, 8);
					coords.RemoveAt(tile);
					robots++;
				}
			}
		}
		
		private void generateTile(int line, int left, int right)
		{
			int size = right - left;
			while (true) {
				int tileSize = Random(2, 6);
				
				if (size < 3) break;
				
				int max = left + tileSize > right ? right : left + tileSize;
				int toFill = max - left;
				
				for (int i = left; i < max; i++) {
					int tileId = 3;
					if (toFill == 2) tileId = 5;
					else if (max > toFill) {
						if (i == left) tileId = 2;
						else if (i == max - 1) tileId = 4;
						else tileId = 3;
					} 
					else tileId = 3;

					if (Helpers.NotEqualStrict(Get (i, line), 10, 11, -1)) {
						Put (i, line, tileId);
					}
				}
				
				if (toFill == 5) {
					if (line + 1 != 6)
						coords.Add(new Pair(left, line+1));
				}
				
				left += tileSize + Random(2, 4);
				size = right - left;
			}
		}
		
		private int getLeftBound(int line)
		{
			for (int i = 0; i < _width; i++) 
			{
				if (Helpers.IsLooselyEqual (Get (i, line), 10, 11)) 
				{
					return i + 1;
				}
			}
			return -1;
		}
		
		private int getRightBound(int line)
		{
			for (int i = _width - 1; i >= 0; i--)
			{
				if (Helpers.IsLooselyEqual (Get (i, line), 10, 11))
				{	
					return i - 1;
				}
			}
			return -1;
		}
	}
}

using UnityEngine;
using Level;

namespace HeartBreak
{
	public class BoardManager : MonoBehaviour
	{
		public GameObject heartTiles;
		public GameObject outSide;
		public GameObject inSide;

		public GameObject safeBorder;
		/** Tile structure **/
		public GameObject tileCenter;
		public GameObject tileRight;
		public GameObject tileLeft;

		public GameObject spikeTile;
		public GameObject cloudTile;
		public GameObject heartTile;
		public GameObject enemy;
		public GameObject mushroomTile;
		public GameObject player;
		
		private Transform boardHolder;

		private BaseLevel level;

		public void SetupScene (int l)
		{
			level = new HeartLevel (41, 41);
			BoardSetup();
		}

		protected void SetPlayerPosition(Vector3 pos)
		{
			GameObject player = GameObject.FindGameObjectWithTag ("Player");

            if (player)
            {
                player.transform.position = pos;
            }
            else
            {
                Debug.LogError("SetPlayerPosition: No player found on the game.");
            }
        }

		public void BoardSetup ()
		{
			boardHolder = new GameObject("Board").transform;

			SetPlayerPosition(level.GetStartingPosition());

            var levelMatrix = level.GetMatrix();

			for (int i = 0; i < level.Height; i++) 
			{
				for (int j = 0; j < level.Width; j++) 
				{
					int tileType = levelMatrix[i, j];

					GameObject toInstantiate = null;

					switch (tileType) 
					{
						case 2:
							toInstantiate = tileLeft;
							break;
						case 3:
							toInstantiate = tileCenter;
							break;
						case 4:
							toInstantiate = tileRight;
							break;
						case 5:
							toInstantiate = cloudTile;
							break;
						case 6:
							toInstantiate = spikeTile;
							break;
						case 7:
							toInstantiate = heartTile;
							break;
						case 8:
							toInstantiate = enemy;
							break;
						case 9:
							toInstantiate = mushroomTile;
							break;
						case 10:
							toInstantiate = heartTiles;
							break;
						case 11:
							toInstantiate = safeBorder;
							break;
						case -1:
							toInstantiate = heartTiles;
							break;
					}

					if (toInstantiate) 
					{
						GameObject instance = Instantiate(toInstantiate, new Vector3 (i, j, 0f), Quaternion.identity) as GameObject;
						instance.transform.SetParent(boardHolder);
					}
				}
			}
		}
	}
}
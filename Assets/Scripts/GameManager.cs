using UnityEngine;

namespace HeartBreak
{
    public class GameManager : MonoBehaviour
	{
		public static GameManager instance = null;
		public static int level = 1;
		public static int points = 0;
		public static int bestScore = 0;
		
		void Awake()
		{
			if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
			GetComponent<BoardManager>().SetupScene(level);

            PrepareSound();
		}


        public void PrepareSound()
        {
            AudioSource audio = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>();

            if (audio && ! audio.isPlaying)
            {
                audio.Play();
            }
        }
	}

}

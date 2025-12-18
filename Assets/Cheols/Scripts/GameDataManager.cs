using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cheols
{
    public class GameDataManager : Singleeton<GameDataManager>
    {
        public int isMusic = 0;
        public int isSound = 0;
        public float gameTime = 0;
        public int gameScore;
        public string curId;
        //public GameDataGroup gameDataGroup = new GameDataGroup();

        // 플레이어에 대한 정보
        public float bombtime = 2.0f;
        public float bombing = 0f;
        public bool isBomb = false;
        public float NoBombSpeed = 1.0f;

        public float fixTime = 60.0f;
        public float fixing = 0f;
        public bool isFix = false;
        public float NoFixSpeed = 1.0f;


        public float hp = 5f;
        public float maxHp = 5f;
        public int upgrade = 0;
        public int maxUpgrade = 3;
        public int bomb = 0;
        public int maxBomb = 3;

        public void LoadData()
        {
            if(!PlayerPrefs.HasKey("Music"))
            {
                PlayerPrefs.SetInt("Music", 1);
                int a = PlayerPrefs.GetInt("Music");
            }
            if (!PlayerPrefs.HasKey("Sound"))
            {
                PlayerPrefs.SetInt("Sound", 1);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cheols
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] Enemys;
        public Vector3 spawnValue;
        public int enemyCount;

        public float spawnWait;
        public float startWait;
        public float waveWait;

        public float[] itemPer = new float[3];

        public List<GameObject> listEnemys = new List<GameObject>();
     

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        // Update is called once per frame
        void Update()
        {

        }


        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    GameObject enemy = Enemys[Random.Range(0, Enemys.Length)];
                    Vector3 spawnPosition = new Vector3(
                        Random.Range(-spawnValue.x, spawnValue.x),
                        spawnValue.y, spawnValue.z);

                    //Quaternion spawnRotation = Quaternion.identity;
                    listEnemys.Add(Instantiate(enemy, spawnPosition, enemy.transform.rotation));
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }

        public int CreateItem()
        {
            int per = Random.Range(0, 100);

            if (per > itemPer[2])
            {
                return -1;
            }
            else if (per > itemPer[1])
            {
                return 2;
            }
            else if (per > itemPer[0])
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

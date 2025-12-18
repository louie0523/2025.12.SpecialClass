using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cheols
{
    public class Player : MonoBehaviour
    {
        // 총알 딜레이
        public float bulletTime = 0.1f;
        // 총알 딜레이만크 시간이 지나갔는지 체크
        public float reloadTime = 0f;
        Rigidbody thisRigi;
        // 플레이어의 이동속도
        public float speed = 2.0f;
        // 총알 프리펩
        public GameObject objBullet;
        // 총알이 생성될 위치
        public GameObject BulletPoint;

        public GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
            thisRigi = this.GetComponent<Rigidbody>();

            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
            if (gameManagerObject != null)
            {
                gameManager = gameManagerObject.GetComponent<GameManager>();
            }
            if (gameManagerObject == null)
            {
                Debug.LogError("gameManger가 존재하지 않습니다.");
            }


        }
        private void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(moveX, 0 , moveZ);
            thisRigi.velocity = move * speed;

            // 현재 플레이어의 위치와 월드 좌표계를 스크린 좌표계로 바꾼다
            Vector3 posInWorld = Camera.main.WorldToScreenPoint(this.transform.position);

            // 스크린 좌표계에서 움직일 수 있는 범위를 제한한다.
            float posX = Mathf.Clamp(posInWorld.x, 0, Screen.width);
            float posZ = Mathf.Clamp(posInWorld.y, 0, Screen.height);

            //제한된 이동을 다시 월드 좌표계로 변경한다,
            Vector3 posInScreen = Camera.main.ScreenToWorldPoint(new Vector3(posX, posZ, 0));

            //이동시킨다
            thisRigi.position = new Vector3(posInScreen.x, 0, posInScreen.z);
        }
        // Update is called once per frame
        void Update()
        {
            Move();
            FireBullet();
        }
        void FireBullet()
        {
            reloadTime += Time.deltaTime;
            if (Input.GetButton("Fire1") && bulletTime <= reloadTime)
            {
                reloadTime = 0f;
                GameObject bullet = Instantiate(objBullet, BulletPoint.transform.position, this.transform.rotation);
                bullet.GetComponent<Bullet>().SetBullect(BulletPoint.transform.position + Vector3.forward);
            }
            if(Input.GetButton("Fire2") && (GameDataManager.Instance.bombtime <= GameDataManager.Instance.bombing)) {
                if(GameDataManager.Instance.bomb == 0)
                {
                    GameDataManager.Instance.isBomb = true;
                } else
                {
                    GameDataManager.Instance.bomb--;
                    GameDataManager.Instance.bombing = 0;
                    for(int i = 0; i < gameManager.listEnemys.Count; i++)
                    {
                        if (gameManager.listEnemys[i].GetComponent<Enemy>() == null)
                        {
                            gameManager.listEnemys[i].GetComponent<Enemy>().hp -= 1;
                            if (gameManager.listEnemys[i].GetComponent<Enemy>().hp < 0)
                            {

                                Destroy(gameManager.listEnemys[i].gameObject);
                            }
                        }
                    }
                }


            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                GameDataManager.Instance.hp -= 1f;
                if (GameDataManager.Instance.hp < 1.0f)
                {
                    Destroy(gameObject);
                }
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                GameDataManager.Instance.hp -= 1f;
            }
            if (other.CompareTag("Item"))
            {
                switch (other.GetComponent<Item>().itemStatus)
                {
                    case ItemStatus.hp:
                        if(GameDataManager.Instance.hp < GameDataManager.Instance.maxHp)
                        {
                            GameDataManager.Instance.hp += 1;
                        }
                        break;
                    case ItemStatus.upgrade:
                        if (GameDataManager.Instance.upgrade < GameDataManager.Instance.maxUpgrade)
                        {
                            GameDataManager.Instance.upgrade++;
                        }
                        break;
                    case ItemStatus.bomb:
                        if (GameDataManager.Instance.bomb < GameDataManager.Instance.maxBomb)
                        {
                            GameDataManager.Instance.bomb++;
                        }
                        break;
                }
                Destroy(other.gameObject);
                return;
            }
        }
    }
}

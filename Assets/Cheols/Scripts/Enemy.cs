using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cheols
{
    public class Enemy : MonoBehaviour
    {
        public float speed;
        public float ThrowPower = 50.0f;
        private GameObject Player;
        public GameObject objBullet;
        public Transform BulletPoint;
        public float delay = 0.5f;
        public float fireRate = 1.0f;
        public float hp = 1.0f;
        public float maxHp = 1.0f;


  
        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            if(Player == null)
            {
                Debug.Log("게임 Player 존재하지 않습니다.");
            }

            GetComponent<Rigidbody>().velocity = transform.forward * speed;
            Invoke("ThrowPlayer", Random.Range(0.5f, 1.5f));
            InvokeRepeating("fireBullet", delay, fireRate);
        }
        void ThrowPlayer()
        {
            if(Player != null)
            {
                Vector3 dir = Player.transform.position - this.transform.position;
                this.GetComponent<Rigidbody>().AddForce(new Vector3(dir.x, 0, 0) * ThrowPower);
            }
        }
        void fireBullet()
        {
            if(Player != null && objBullet != null)
            {
                GameObject bullet = Instantiate(objBullet, BulletPoint.transform.position, this.transform.rotation);
                bullet.GetComponent<Bullet>().SetBullect(Player.transform.position + Vector3.forward);
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                return;
            }
            if (other.CompareTag("Bullet"))
            {
                hp -= 1f;
                if (hp < 1.0f)
                {
                    Destroy(gameObject);
                }
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
        void Update()
        {
        
        }
    }
}

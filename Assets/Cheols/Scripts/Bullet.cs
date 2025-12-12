using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cheols
{
    public class Bullet : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Vector3 destination;
        [UnityEngine.SerializeField]
        private bool isThrow = false;
        public float speed = 1.0f;

        // 방향
        public Vector3 dir;

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (isThrow)
            {
                // 방향계산에 따른 조준탄
                this.transform.position += dir.normalized * Time.deltaTime * speed;
            }
        }
        public void SetBullect(Vector3 _destnation)
        {
            destination = _destnation;
            isThrow = true;

            // 방향 계산
            dir = destination - this.transform.position; 
        }
    }
}

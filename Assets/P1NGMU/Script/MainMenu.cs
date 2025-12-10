using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P1NGMU
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenualBack;
        public GameObject Menual;
        public GameObject Story;
        public void BtnManual()
        {
            MenualBack.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenMenual", 1.5f);
        }

        public void BtnStory()
        {
            MenualBack.GetComponent<Animator>().SetTrigger("Cloese");
            Invoke("OpenStory", 1.5f);
        }

        void OpenMenual()
        {
            Menual.SetActive(true);
            Menual.GetComponent<Animator>().SetTrigger("Open");
        }

        void OpenMenuBack()
        {
            MenualBack.GetComponent<Animator>().SetTrigger("Open");
        }
        void OpenStory()
        {
            Story.SetActive(true);
            Story.GetComponent<Animator>().SetTrigger("Open");
        }
    }
}

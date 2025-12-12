using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cheols
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenuBack;
        public GameObject Menual;
        public GameObject Story;
        public void BtnMenual()
        {
            MenuBack.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenMeneual", 1.5f);
        }
        public void BtnStory()
        {
            MenuBack.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenStory", 1.5f);
        }
        public void BtnBack(int num)
        {
            switch (num)
            {
                case 0:
                    Menual.GetComponent<Animator>().SetTrigger("Close");
                    Invoke("OpenMenuBack", 1.5f);
                    break;
                case 1:
                    Story.GetComponent<Animator>().SetTrigger("Close");
                    Invoke("OpenMenuBack", 1.5f);
                    break;
            }
        }
        void OpenMeneual()
        {
            Menual.SetActive(true);
            Menual.GetComponent<Animator>().SetTrigger("Open");
        }
        void OpenMenuBack()
        {
            MenuBack.SetActive(true);
            MenuBack.GetComponent<Animator>().SetTrigger("Open");
        }
        void OpenStory()
        {
            Story.SetActive(true);
            Story.GetComponent<Animator>().SetTrigger("Open");
        }
        public void BtnStart()
        {
            SceneManager.LoadScene("stage01");
        }
        public void BtnExit()
        {
            Application.Quit();
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

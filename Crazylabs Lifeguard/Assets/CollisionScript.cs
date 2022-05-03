using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using UnityEngine.UI;
public class CollisionScript : MonoBehaviour
{
    public GameObject rooster, chichMesh;
    public GameObject prnt;


    private void Update()
    {
        if (this.gameObject.tag == "Untagged" && !RushMechanic.instance.cubes.Contains(this.gameObject))
        {
            Destroy(this.gameObject);

        }



    }
    public Text debug1, debug2;
    public int currentIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube" && !RushMechanic.instance.cubes.Contains(other.gameObject))
        {

            other.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.tag = ("Untagged");
            // other.gameObject.AddComponent<Collision>();
            //  other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            RushMechanic.instance.StackCube(other.gameObject, RushMechanic.instance.cubes.Count - 1);

            if (LevelController.vibration) {
             
                MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
                


            }


        }

        else if (other.gameObject.tag == "kýrmýzý1" && this.gameObject.tag != "adam")
        {
            // dest = true;
            currentIndex = RushMechanic.instance.cubes.IndexOf(this.gameObject);

            // if(ATMRush.instance.cubes.FindIndex(d => d == this.gameObject)==ATMRush.instance.cubes.Count-1)
            if (currentIndex == RushMechanic.instance.cubes.Count - 1)
            {
                RushMechanic.instance.cubes.RemoveAt(RushMechanic.instance.cubes.Count - 1);
            }
            else
            {
                //   for (int i = ATMRush.instance.cubes.Count - 1; i >= ATMRush.instance.cubes.FindIndex(d => d == this.gameObject); i--)
                for (int i = RushMechanic.instance.cubes.Count - 1; i >= currentIndex; i--)
                {
                    Debug.Log(i);
                    if (i > 0)
                    {
                       
                        RushMechanic.instance.cubes.RemoveAt(i);
                       

                        //   ATMRush.instance.cubes[i].transform.DOMoveZ(5f, 0.1f);
                        //      ATMRush.instance.cubes[i].transform.DOMoveX(1f, 0.1f);

                    }
                }

            }

        }
        else if (other.gameObject.tag == "Finish" && this.gameObject.tag == "adam")
        {

            Movement.canMove = false;
            Invoke("kameraAnim", 1);

            for (int i = 0; i < RushMechanic.instance.cubes.Count; i++)
            {

                RushMechanic.instance.cubes[i].transform.DOLocalMoveX(0, RushMechanic.instance.ortalamaSüre);



            }
            //  ATMRush.instance.cubes[0].transform.DOLocalMoveX(0, 2f);
            RushMechanic.instance.karakter.transform.DOLocalMoveZ(90, RushMechanic.instance.ilerlemeSüre);

            //  ATMRush.instance.cubes[0].transform.DOLocalMoveX(0, 1f);

            //karakter.transform.DOLocalMove(new Vector3(0, 0, 90f), 3f);
            //

        }
        else if (other.gameObject.tag == "Finish2" && this.gameObject.tag == "adam")
        {
            RushMechanic.instance.karakter.transform.DOLocalRotate(new Vector3(0, 90, 0), RushMechanic .instance.rotateSüre);
        }





        else if (other.gameObject.tag == "Finish3" && this.gameObject.tag == "adam")
        {
            RushMechanic.instance.kamera.transform.parent = null;
        }
       




       
    }

       
        public GameObject kamera;
    void kameraAnim()
    {
        kamera.GetComponent<kameraTakip>().enabled = false;
        kamera.GetComponent<Animation>().Play("levelsonu");
      

        Invoke("levelsonuEkran", 1.7f);
        Invoke("zoom", 1f);

    }
    public GameObject winPanel, losePanel, winScreen, loseScreen;

    public AudioSource aSource;
    public AudioClip kutlama;

    void zoom()
    {
        kamera.GetComponent<Camera>().fieldOfView = 75;
    }
    void levelsonuEkran()
    {
        if (RushMechanic.instance.cubes.Count > 2)
        {
            winPanel.SetActive(true);
            winScreen.SetActive(true);
            PlayerPrefs.SetInt("diamond", PlayerPrefs.GetInt("diamond") + 10);
            aSource.PlayOneShot(kutlama);
        }
        else
        {
            losePanel.SetActive(true);
            loseScreen.SetActive(true);
            PlayerPrefs.SetInt("diamond", PlayerPrefs.GetInt("diamond") + 5);
        }
    }
    
    public void sesDurdur()
    {
        aSource.Stop();
    }


    


}


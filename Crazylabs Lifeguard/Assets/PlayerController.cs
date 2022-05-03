using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
   
    public  float Speed;
    public   float rightSpeed;

    public static bool canMove;

    Vector3 boyut1 = new Vector3 (0.5f,0.5f,0.5f);
    Vector3 boyut2 = new Vector3(0.6f, 0.6f, 0.6f);
    Vector3 boyut3 = new Vector3(0.7f, 0.7f, 0.7f);


    int adamsayi;
  
    public GameObject bitişNoktası;

    public GameObject tryAgainPanel;

      public  Animator heroAnim;
    public RuntimeAnimatorController idle, run;
    void Start()
    {
      
    }

    private void Update()
    {
       
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "oy")
        {
            Destroy(col.gameObject);
            oySayaç++;
        }
        else if (col.gameObject.tag == "yeşil1")
        {
            Destroy(col.gameObject);
            bitişNoktası.SetActive(false);
            UpgradeEfekt();
            oySayaç = oySayaç + 10;
        }

        else if (col.gameObject.tag == "yeşil2")
        {
            Destroy(col.gameObject);
            UpgradeEfekt();
            bitişNoktası.SetActive(false);
            oySayaç = oySayaç + 10;

        }
        else if (col.gameObject.tag == "yeşil3")
        {
            Destroy(col.gameObject);
            UpgradeEfekt();
            bitişNoktası.SetActive(false);
            oySayaç = oySayaç + 10;
        }
        else if (col.gameObject.tag == "yeşil4")
        {
            Destroy(col.gameObject);
            UpgradeEfekt();
            bitişNoktası.SetActive(false);
            oySayaç = oySayaç + 10;
        }

        else if (col.gameObject.tag == "kırmızı1")
        {
            Destroy(col.gameObject);
            
            bitişNoktası.SetActive(false);
           
        }
        else if (col.gameObject.tag == "kırmızı2")
        {
            Destroy(col.gameObject);
            bitişNoktası.SetActive(false);
        }
        else if (col.gameObject.tag == "kırmızı3")
        {
            Destroy(col.gameObject);
           
            bitişNoktası.SetActive(false);
        }
        else if (col.gameObject.tag == "kırmızı4")
        {
            Destroy(col.gameObject);
           
            bitişNoktası.SetActive(false);
        }
      




        //
        else if (col.gameObject.tag == "adam")
        {
            Destroy(col.gameObject);
            adamsayi++;
            
        }

       //else if (col.gameObject.tag == "bitişnoktası")
      //  {
        //    canMove = false;
          //  heroAnim.runtimeAnimatorController = idle;
          //  bitişNoktası.SetActive(false);
       // }

       else if (col.gameObject.tag == "engel")
        {
            tryAgainPanel.SetActive(true);
            heroAnim.runtimeAnimatorController = idle;
            canMove = false;
        }

        }


    void FixedUpdate()
    {
     
        #region karakterBoyutu
        if ( oySayaç>= 15 )
        {
            transform.localScale = Vector3.Lerp(transform.localScale, boyut1, 1);
        }
        if (oySayaç >= 30)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, boyut2, 1);
        }
        if (oySayaç >= 45)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, boyut3, 1);
        }

        #endregion karakterBoyutu



        if (canMove)
        {
            transform.position += new Vector3(1, 0, 0) * Speed;

            if (Input.GetKey(KeyCode.RightArrow) && transform.position.z > -1.508f)
            {
                transform.position -= new Vector3(0, 0, 1) * rightSpeed;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.z < 1.469f)
            {
                transform.position += new Vector3(0, 0, 1) * rightSpeed;
            }
        }
    }


    #region oy

    //public GameObject mektup;
    int oySayaç;
   // public Text oyYazı;
    public void OyToplama()
    {



    }

    #endregion oy




    #region Efektler
    public GameObject fxExp;
    public GameObject fxUpgrade;
    public GameObject upgradePos, expPos;

    public void UpgradeEfekt()
    {
        var myNewSmoke = Instantiate(fxUpgrade, upgradePos.transform.position, Quaternion.identity);
        myNewSmoke.transform.parent = upgradePos.gameObject.transform;
       // Destroy(fxUpgrade, 1.5f);
    }


    #endregion Efektler

}

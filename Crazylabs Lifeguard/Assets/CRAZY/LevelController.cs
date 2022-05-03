using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;

public class LevelController : MonoBehaviour
{

    public GameObject Hero, floor, floor1,kamera,runnerKamera;
    public Animator idleHeroAnim;
    public Animation kamera1;
    public Camera mainCam,runCam;
    public GameObject level1, level2, level3;
    
    public RuntimeAnimatorController idle, jumping, surfing, win, lose,cam1;
    public GameObject karakterBaþlangýç;

    void Start()
    {
        if(!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }

        if (!PlayerPrefs.HasKey("leveltext"))
        {
            PlayerPrefs.SetInt("leveltext", 1);
        }

    }

    public void debug(int x)
    {
        if (x == 1)
        {
            Movement.instance.moveSpeed += -1;
        }
        if (x == 2)
        {
            Movement.instance.moveSpeed += 1;
        }

        if (x == 3)
        {
            Movement.instance.swipeSpeed += -1;
        }
        if (x == 4)
        {
            Movement.instance.swipeSpeed += 1;
        }

    }

    public Text debug1, debug2;
    int moveSpeed = 5;
    public GameObject karakter,sörfTahtasý;
    public Text boyaText, diamondText, levelText;
    int boyaint;

    public GameObject settingsbuton, settingopenbuton;
    void Update()
    {
        if (!settingsbuton.activeSelf) settingopenbuton.SetActive(false);
        if (boyaint >=1) boyaText.text = "draw it!";
        else boyaText.text = "choose color!";

        levelText.text = "LEVEL "+PlayerPrefs.GetInt("leveltext").ToString();
        diamondText.text = PlayerPrefs.GetInt("diamond").ToString();

   // if(boyamaEkran.activeSelf)    boyamaEfekt();



        debug1.text = Movement.instance.moveSpeed.ToString();
        debug2.text = Movement.instance.swipeSpeed.ToString();
    }

    public void boyaSec()
    {
        boyaint += 1;
    }
    public GameObject createNewButton, confirmButton,denizrunner,runStartButon;
    public void basla1()
    {
        // kamera.GetComponent<Animator>().runtimeAnimatorController = cam1;
        // Invoke("basla2", 1.48f);
        kamera1.Play("Cam1");
        x = 1;
        StartCoroutine(numerator());

    }
    int x;
    public IEnumerator numerator()

    {
        if (x == 1)
        {
            yield return new WaitForSeconds(1.5f);
            createNewButton.SetActive(true);
        }
       else if (x == 2)
        {
            yield return new WaitForSeconds(4.5f);
            confirmButton.SetActive(true);
        }
        else if (x == 3)
        {
            yield return new WaitForSeconds(2f);

            // denizrunner.SetActive(true);
            runnerKamera.SetActive(true);
            runStartButon.SetActive(true);

        }

    }

    public void basla2()
    {

        kamera1.Play("Cam2");
        x = 2;
        StartCoroutine(numerator());
    }

    public void basla3()
    {

        kamera1.Play("Cam3");
        x = 3;
        StartCoroutine(numerator());
      
        Destroy(GameObject.FindWithTag("Level"));
        
        if(PlayerPrefs.GetInt("level")==1)
        {
            var myNewSmoke = Instantiate(level1,level1.transform.position, Quaternion.identity);
        }
        if (PlayerPrefs.GetInt("level") == 2)
        {
            var myNewSmoke = Instantiate(level2, level2.transform.position, Quaternion.identity);
        }
        if (PlayerPrefs.GetInt("level") == 3)
        {
            var myNewSmoke = Instantiate(level3, level3.transform.position, Quaternion.identity);
        }
    }
    public void runStart()
    {
        Movement.canMove = true;
    }
    public void WinFonk()
    {
        PlayerPrefs.SetInt("leveltext", PlayerPrefs.GetInt("leveltext") + 1);


        if (PlayerPrefs.GetInt("level")==1)
        {
          
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        }
        else if (PlayerPrefs.GetInt("level") == 2)
        {
           
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        }
        else if (PlayerPrefs.GetInt("level") == 3)
        {
           
            PlayerPrefs.SetInt("level", 1);
        }
      

        kamera.transform.position = new Vector3(-3.045701f, 1.52f, -3.784f);
        Vector3 acý = new Vector3(15.594f, -28, 0);
        kamera.transform.rotation = Quaternion.Euler(acý);
        runnerKamera.transform.position = new Vector3(0.03f, 2.119571f, 0.5809987f);
        runnerKamera.transform.rotation = Quaternion.Euler(21.66f,0, 0);
        runCam.fieldOfView = 75;
        runnerKamera.SetActive(false);
        karakterBaþlangýç.SetActive(true);
        karakter.transform.position = new Vector3(0, 2.2695701f, 3.238147f);
        karakter.transform.rotation = Quaternion.Euler(0, 0, 0);
        boyaint = 0;
        runnerKamera.GetComponent<kameraTakip>().enabled = true;
        for (int i = 1; i < RushMechanic.instance.cubes.Count; i++)
        {

            // ATMRush.instance.cubes.RemoveAt(i);
            Destroy(RushMechanic.instance.cubes[i]);
            RushMechanic.instance.cubes.Clear();
            RushMechanic.instance.cubes.Add(sörfTahtasý);
               
            // ATMRush.instance.cubes[i].gameObject.tag = ("Untagged");

        }
    }
    public GameObject settingsPanel;
    public void setttings(int x)
    {
        if (x == 1)
        {
            if (settingsPanel.activeSelf) settingsPanel.SetActive(false);
            else settingsPanel.SetActive(true);
        }
        if (x ==2 )
        {
            if (AudioListener.volume == 1) AudioListener.volume = 0;
            else AudioListener.volume = 1;
        }

        if (x == 3)
        {
            if (vibration) vibration = false;
            else vibration = true;
        }
    }

    public static bool vibration = true;

    float holdTime;
    public GameObject boyamaEkran;
   
    void boyamaEfekt()
    {
        

        if (Input.GetMouseButton(0))
        {
            holdTime += Time.deltaTime;

            if (holdTime > 0.4f)
            {
                Debug.Log("basili");

                if (LevelController.vibration)
                {
                
                    MMVibrationManager.Haptic(HapticTypes.LightImpact);
                
                }

          //      aSource.mute = false;



            }
        }

        else
        {
            holdTime = 0;
          
           // aSource.mute = true;
        }
    }

}

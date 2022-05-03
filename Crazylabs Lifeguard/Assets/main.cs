using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
 
   
   
    public GameObject adamPrefab;

    public static bool engelCarpma;
   
   
    
    void Start()
    {
       

    }

   
    void Update()
    {


      
    


    }
    private void FixedUpdate()
    {
        

    }
  
  
  
    public GameObject girisCanvas, oyunCanvas;
   
    public  Animator heroAnim;
    public RuntimeAnimatorController idle, run;
    public void oyunBaslat()
    {
        PlayerController.canMove = true;
        girisCanvas.SetActive(false);
        oyunCanvas.SetActive(true);

        heroAnim.runtimeAnimatorController = run;
    }
   
}

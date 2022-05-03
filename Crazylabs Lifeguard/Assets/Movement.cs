using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float swipeSpeed;
    public float moveSpeed;

    public static bool canMove = false ;
    //public float geriBasSpeed;
    private Camera cam;

    public static Movement instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
      
    }
    void Start()
    {
        cam = Camera.main;
        firstCube = RushMechanic.instance.cubes[0];
    }

 
    void Update()
    {
        if(canMove)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;


            if (Input.GetButton("Fire1"))
            {

                Move();
                if (RushMechanic.instance.cubes[0].gameObject.transform.position.x <= -1.65f) RushMechanic.instance.cubes[0].gameObject.transform.position = new Vector3(-1.65f, RushMechanic.instance.cubes[0].gameObject.transform.position.y, RushMechanic.instance.cubes[0].gameObject.transform.position.z);
                if (RushMechanic.instance.cubes[0].gameObject.transform.position.x >= 1.65f) RushMechanic.instance.cubes[0].gameObject.transform.position = new Vector3(1.65f, RushMechanic.instance.cubes[0].gameObject.transform.position.y, RushMechanic.instance.cubes[0].gameObject.transform.position.z);
            }
        }
        
       
    }
    GameObject firstCube;
    void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
        //    GameObject firstCube = ATMRush.instance.cubes[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstCube.transform.localPosition.y;
            hitVec.z = firstCube.transform.localPosition.z;

            firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVec, Time.deltaTime * swipeSpeed);

        }

     }
   




}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
public class RushMechanic : MonoBehaviour
{
    public static RushMechanic  instance;
    public float movementDelay = 0.25f;
    public float büyümeKatsayisi = 1.5f;
    public float arasýndakiMesafe = 0.25f;
    public Vector3 scaleSayisi;
    public Animator anim;
    public RuntimeAnimatorController idle, run,victory;

    public GameObject kamera, karakter;
    public float ortalamaSüre, ilerlemeSüre, rotateSüre;



    public List<GameObject> cubes = new List<GameObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetButton("Fire1") && Movement.canMove==true)
        {
            MoveListElements();
        }
        if (Input.GetButtonUp("Fire1") && Movement.canMove == true)
        {
            MoveOrigin();
        }
      
    }

    
    public float arasýndakiMesafe_Y, arasýndakiMesafeZ2;
    public RuntimeAnimatorController tutunma;
    public Camera runCamera;
    public AudioSource aSource;
    public AudioClip efekt;
    public void StackCube(GameObject other,int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cubes[index].transform.localPosition;
     if(cubes.Count ==1)   newPos.z -= arasýndakiMesafe;   // scale'imiz 0.25 olduðu için 0.25 ileri atacaz yeni gelenleri böylece arada boþluk kalmayacak.
        if (cubes.Capacity == 1) newPos.y -= arasýndakiMesafe_Y;
        else newPos.z -= arasýndakiMesafeZ2;
        other.transform.localPosition = newPos;
        other.GetComponent<Animator>().runtimeAnimatorController = tutunma;
        other.transform.Rotate(35f, 180, 0);
        StartCoroutine(MakeObjectsBigger());
   
        cubes.Add(other);
        if (PlayerPrefs.GetInt("level") == 1) other.transform.position = new Vector3(other.transform.position.x, -0.9f, other.transform.position.z);
       else if (PlayerPrefs.GetInt("level") == 2) other.transform.position = new Vector3(other.transform.position.x, -0.89543f, other.transform.position.z);
        else if (PlayerPrefs.GetInt("level") == 3) other.transform.position = new Vector3(other.transform.position.x, -0.89543f, other.transform.position.z);

        aSource.PlayOneShot(efekt);
      if(LevelController.vibration)  MMVibrationManager.Haptic(HapticTypes.RigidImpact);
        other.transform.rotation = Quaternion.Euler(40, 0, 0);
        Debug.Log(cubes.Count);
        if (cubes.Count == 4) runCamera.DOFieldOfView(85, 2f);
        if (cubes.Count == 6) runCamera.DOFieldOfView(95, 2f);
        if (cubes.Count<4) runCamera.DOFieldOfView(75, 1.4f);
    }
    int x;
   void cameraIncrease()
    {
        runCamera.fieldOfView += 5;
    }
    public IEnumerator MakeObjectsBigger()

    {
        for(int i = cubes.Count-1; i>0; i--)
        {
            int index = i;
            Vector3 scale = scaleSayisi;
            scale *= büyümeKatsayisi;

            cubes[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
            cubes[index].transform.DOScale(scaleSayisi, 0.1f));

            yield return new WaitForSeconds(0.05f);
        }
    }

    void MoveListElements()
    {
        for(int i = 1; i< cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[i - 1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, movementDelay);
        }
    }

    void MoveOrigin()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[0].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, 0.70f);
        }
    }

    public void MoveFinish()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = 0;
            cubes[i].transform.DOLocalMove(pos, 1f);
        }
    }


}

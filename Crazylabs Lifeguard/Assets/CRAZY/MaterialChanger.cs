using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    
    public GameObject DefObject,MaviObject,PembeObject,YesilObject,TuruncuObject;
    // Start is called before the first frame update
    public void MaviMatChange()
    {
        MaviObject.SetActive(true);
        DefObject.SetActive(false);
        PembeObject.SetActive(false);
        YesilObject.SetActive(false);
        TuruncuObject.SetActive(false);
    }
    public void PembeMatChange()
    {
        MaviObject.SetActive(false);
        DefObject.SetActive(false);
        PembeObject.SetActive(true);
        YesilObject.SetActive(false);
        TuruncuObject.SetActive(false);
    }
    public void YesilMatChange()
    {
        MaviObject.SetActive(false);
        DefObject.SetActive(false);
        PembeObject.SetActive(false);
        YesilObject.SetActive(true);
        TuruncuObject.SetActive(false);
    }
    public void TuruncuMatChange()
    {
        MaviObject.SetActive(false);
        DefObject.SetActive(false);
        PembeObject.SetActive(false);
        YesilObject.SetActive(false);
        TuruncuObject.SetActive(true);
    }
    public void DefMatChange()
    {
        MaviObject.SetActive(false);
        DefObject.SetActive(true);
        PembeObject.SetActive(false);
        YesilObject.SetActive(false);
        TuruncuObject.SetActive(false);
    }

}

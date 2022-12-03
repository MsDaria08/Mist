using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEhergyShield = 3;
    public float energyShieldButtomY = -6f;
    public float energyShieldRagious = 1.5f;
    public List<GameObject> basketList;
   
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 1; i <= numEhergyShield; ++i) //<=
        {
            GameObject tBasketGo = Instantiate<GameObject>(energyShieldPrefab);
            tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
            tBasketGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
            basketList.Add(tBasketGo);
        }
    }

    
    void Update()
    {
    }

    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray =
        GameObject.FindGameObjectsWithTag("DragonEgg");
        foreach (GameObject tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_0Scene");
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SnowPool : MonoBehaviour
{
    [SerializeField] private GameObject snowPrefab; //Prefabs nieve
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List <GameObject> snowList; //Lista de nieve

    //Singelton hace que tengamos una sola instancia de snow y nos permite acceder desde el InputManager
    private static SnowPool instance;
    public static SnowPool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AddSnowToPool(poolSize);
        
    }

    private void AddSnowToPool(int amount) {
        for (int i = 0; i < amount; i++)
        {
            GameObject snow = Instantiate(snowPrefab);
            snow.SetActive(false);
            snowList.Add(snow);
            snow.transform.parent = transform;
        }
    }

    public GameObject RequestSnow() {
        for (int i = 0; i < snowList.Count; i++) {
            if (snowList[i].activeSelf) {
                snowList[i].SetActive(true);
                return snowList[i];
            }
        }
        AddSnowToPool(1);
        snowList[snowList.Count-1].SetActive(true);
        return snowList[snowList.Count-1];
    }
    
}

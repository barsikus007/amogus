using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Aboba2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject sphere;

    public void CubeGen()
    {
        var text = GetComponent<TMP_InputField>().text;
        if (text == "") return;
        for (var i = 0; i < int.Parse(text); i++) Instantiate(cube, sphere.transform.position, Quaternion.identity);
    }
}
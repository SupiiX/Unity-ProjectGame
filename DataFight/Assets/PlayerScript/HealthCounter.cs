using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    public GameObject counter;

    private TMP_Text text;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        text = counter.GetComponent<TMP_Text>();
        //i = 0;
    }

    // Update is called once per frame
    void Update()
    {


    }

}

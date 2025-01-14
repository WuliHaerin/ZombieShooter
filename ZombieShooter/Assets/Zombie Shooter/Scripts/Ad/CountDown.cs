using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float time;
    public TMP_Text timeText;
    // Start is called before the first frame update

    private void OnEnable()
    {
        time=3;
    }
    void Start()
    {
        timeText.text = time.ToString();
        StartCoroutine(Count());
    }

    // Update is called once per frame
    void Update()
    {
        if(time<0)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Count()
    {
        while(time>0)
        {
            yield return new WaitForSeconds(1);
            time--;
            timeText.text = time.ToString();

        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

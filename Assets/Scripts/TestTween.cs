using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TestTween : MonoBehaviour
{
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        img.DOFade(0, 2).OnComplete(()=> {
            Debug.Log("ACABOU!");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

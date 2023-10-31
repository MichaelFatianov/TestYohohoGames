using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    float _timer;
    int _counter;
   
    void Update()
    {
        _counter++;
        _timer += Time.deltaTime;
        if(_timer >= 1f)
        {
            _timer = 0f;
            _counterText.text = "FPS:" + _counter.ToString();
            _counter = 0;
        }
    }
}

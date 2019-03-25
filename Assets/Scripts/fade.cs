using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade : MonoBehaviour
{
    public GameObject MenuObject;
    public bool transition = true;
    public float delta;
    public string loadScene;
    int FadeDirection = 1;
    float fadeing = 0.0f;
    public float IntermediateFadeTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transition == true && FadeDirection == 1)
        {
            fadeing = fadeing + delta * Time.deltaTime;
            MenuObject.GetComponent<CanvasGroup>().alpha = fadeing;

        }

        if (fadeing >= 1.0f + IntermediateFadeTime)
        {
            FadeDirection = -1;

        }

        if (fadeing <= 0.0f && FadeDirection == -1)
        {
            SceneManager.LoadScene("Stage 1");
        }

        if (transition == true && FadeDirection == -1)
        {
            fadeing = fadeing - delta * Time.deltaTime;
            MenuObject.GetComponent<CanvasGroup>().alpha = fadeing;

        }
    }



}


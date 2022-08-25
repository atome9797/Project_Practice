using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleFromMicrophone : MonoBehaviour
{

    [SerializeField]
    private Image[] images_Gauge;

    public static AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public float minScalef;
    public float maxScalef;
    public AudioLoudnessDetection detecter;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        //юс╫ц
        /*float loudness = detecter.GetLoudnessFromMicrophone();

        if (loudness < threshold)
        {
            loudness = 0;
        }
        Debug.Log((float)Mathf.Lerp(minScalef, maxScalef, loudness));
        images_Gauge[0].fillAmount = (float)Mathf.Lerp(minScalef, maxScalef, loudness);*/
    }

    public static void PlaySnd()
    {
        source.Play();
    }

    public static void RecSnd()
    {
        source.clip = Microphone.Start(Microphone.devices[0].ToString(), false, 5, 44100);
    }

}

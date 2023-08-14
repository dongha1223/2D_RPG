using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg;
    public int CharPerseconds;
    public GameObject EndCursur;

    AudioSource audioSource;
    Text msgText;
    int index;
    float talkSpeed;
    public bool isAni;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAni)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursur.SetActive(false);

        talkSpeed = 1.0f / CharPerseconds;

        isAni = true;

        Invoke("Effecting", talkSpeed);
    }
    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
        {
            audioSource.Play();
        }
        index++;

        talkSpeed = 1.0f / CharPerseconds;
        Invoke("Effecting", talkSpeed);
    }

    void EffectEnd()
    {
        isAni = false;
        EndCursur.SetActive(true);
    }
}

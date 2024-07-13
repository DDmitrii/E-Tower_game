using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] sound;
    public AudioSource a;
    public void clickSound() {
        a.clip = sound[0];
        a.Play();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            clickSound();
        }
    }
}
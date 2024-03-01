using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class AudioManager : MonoBehaviour
    {
        public AudioClip[] list;
        public AudioSource source;
        // Start is called before the first frame update
        void Start()
        {
            source.clip = list[0];
            source.Play();
        }

        // Update is called once per frame
         void Update()
         {

         }
    }

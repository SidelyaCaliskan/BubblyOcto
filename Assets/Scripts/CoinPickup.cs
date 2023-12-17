using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
   [SerializeField] private AudioClip coinPickupSound;
   
   //this can also be adjusted in the audio source component.
   [SerializeField] private float coinPickupSoundVolume = 1f;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Player")
      {
         //playClipAtPoint because the gameobject is destroying itself
         AudioSource.PlayClipAtPoint(coinPickupSound, Camera.main.transform.position, coinPickupSoundVolume);
         Destroy(gameObject);
      }
   }
}

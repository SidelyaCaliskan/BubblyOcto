using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
   [SerializeField] private AudioClip coinPickupSound;

   //we have two colliders and we don't want to increase coins score twice
   private bool wasCollected = false;
   
   //this can also be adjusted in the audio source component.
   [SerializeField] private float coinPickupSoundVolume = 1f;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Player" && !wasCollected)
      {
         wasCollected = true;
         FindObjectOfType<GameSession>().AddToCoins();
         
         //playClipAtPoint because the gameobject is destroying itself
         AudioSource.PlayClipAtPoint(coinPickupSound, Camera.main.transform.position, coinPickupSoundVolume);
         
         //to not trigger two sound effects
         gameObject.SetActive(false);
         
         Destroy(gameObject);
      }
   }
}

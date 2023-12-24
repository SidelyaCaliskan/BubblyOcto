using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScript : MonoBehaviour
{
    [SerializeField] 
    private  float parallaxSpeed;
private Transform cameraTransform;

private void private void Start() {
    cameraTransform = Camera.main.transform;

}

private void void Update()
{
    float relativeDist = cameraTransform.position.x * parallazSpeed;
    transform.position = new Vector3(relativeDist, transformPosition.y, transformPosition.z);
}
}

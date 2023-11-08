using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformKoopaToBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Camera mainCamera;
    [SerializeField] GameObject cameraPosition;

    [SerializeField] GameObject objectBase;
    [SerializeField] GameObject objectToTransform;
    private bool hasSwitched = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !hasSwitched)
        {
            mainCamera.transform.position = cameraPosition.transform.position;
            objectToTransform.SetActive(true);
            if (objectBase != null)
            {
                objectBase.SetActive(false);
                Destroy(objectBase, 0.1f);
            }

            hasSwitched = true;
        }
    }
}

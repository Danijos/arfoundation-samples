using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectPlacement : MonoBehaviour
{
    public ARRaycastManager raycastManager;  // Componente ARRaycastManager
    public GameObject objectToPlace;         // Objeto a colocar
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();  // Lista para los raycasts

    void Update()
    {
        // Detectar el toque del usuario
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            // Lanzar raycast desde la cámara
            if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
            {
                // Obtener el punto de impacto en el plano detectado
                Pose hitPose = hits[0].pose;

                // Instanciar el objeto en la posición del hit
                Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
            }
        }
    }
}

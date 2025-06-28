using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    //Definiert was verfolgt werden soll -> Player
    public Vector3 offset;      //Definiert den Abstand zu Kamera


    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;  //die Kamera folgt dem Objekt mit dem definierten Offset (Abstand)
        }
    }
}

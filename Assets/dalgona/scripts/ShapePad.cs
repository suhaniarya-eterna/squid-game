using UnityEngine;

public class ShapePad : MonoBehaviour
{
    public DalgonaManager manager;
    public DalgonaManager.ShapeType shape;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player selected shape: " + shape);
            manager.SelectShape(shape);
        }
    }
}
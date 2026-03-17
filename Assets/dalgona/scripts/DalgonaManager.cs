using UnityEngine;

public class DalgonaManager : MonoBehaviour
{
    public enum ShapeType
    {
        Circle,
        Triangle,
        Star,
        Umbrella
    }

    public ShapeType selectedShape;

    public GameObject circleCandy;
    public GameObject triangleCandy;
    public GameObject starCandy;
    public GameObject umbrellaCandy;

    public void SelectShape(ShapeType shape)
    {
        selectedShape = shape;

        Debug.Log("Shape chosen: " + shape);

        SpawnShape();
    }

    void SpawnShape()
    {
        circleCandy.SetActive(false);
        triangleCandy.SetActive(false);
        starCandy.SetActive(false);
        umbrellaCandy.SetActive(false);

        switch(selectedShape)
        {
            case ShapeType.Circle:
                circleCandy.SetActive(true);
                break;

            case ShapeType.Triangle:
                triangleCandy.SetActive(true);
                break;

            case ShapeType.Star:
                starCandy.SetActive(true);
                break;

            case ShapeType.Umbrella:
                umbrellaCandy.SetActive(true);
                break;
        }

        Debug.Log("Candy spawned. Start carving.");
    }
}
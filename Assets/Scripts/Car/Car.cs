using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject carPrefab;

    public int speed = 20;
    public int gearAmount = 5;

    public int TotalSpeed
    {
        get { return speed * gearAmount; }
    }

    public void CreateCar()
    {
        var a = Instantiate(carPrefab);
        a.transform.position = Vector3.zero;
    }
}
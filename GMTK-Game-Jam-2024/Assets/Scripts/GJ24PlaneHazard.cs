using UnityEngine;

public class GJ24PlaneHazard : GJ24SizeableObject
{
    public override void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
        if (transform.position.x < EdgeOfViewableScreen)
        {
            Destroy(gameObject);
        }
    }
}

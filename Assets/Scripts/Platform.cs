using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update() => transform.position += Vector3.left * (speed * Time.deltaTime);

    private void OnBecameInvisible() => Destroy(gameObject);
}
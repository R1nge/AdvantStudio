using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update() => transform.localPosition += Vector3.left * (speed * Time.deltaTime);

    private void OnBecameInvisible() => Destroy(gameObject);
}
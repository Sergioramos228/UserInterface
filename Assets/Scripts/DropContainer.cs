using UnityEngine;

public class DropContainer : MonoBehaviour
{
    [SerializeField] private Transform _container;

    public Transform Container => _container;
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Pistol : Gun
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _damage;
    public override float maxDistance { get; set; }
    public override float damage { get; set; }

    public void Start()
    {
        maxDistance = _maxDistance;
        damage = _damage;
        base.Start();
    }

    public override void Shoot()
    {
        {
            RaycastHit hit;
            GameObject targetHit;
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance, targetLayer))
            {
                targetHit = hit.collider.gameObject;
                Debug.Log("targetHit");

                if (targetHit.CompareTag(targetTag) && targetHit.TryGetComponent<Target>(out Target target))
                {
                    Debug.Log(target);
                    target.TakeDamage(damage);
                }
                Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * maxDistance, Color.red, 2f);
                Debug.Log($"Hit: {hit.collider.gameObject.name} | Layer: {hit.collider.gameObject.layer} | Tag: {hit.collider.tag}");
            }
        }
    }
}

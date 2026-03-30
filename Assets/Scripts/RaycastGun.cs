using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class RaycastGun : Gun
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _muzzleEffect;
    [SerializeField] private GameObject _barrel;
    [SerializeField] private Vector2 spreadOffsets;
    public override float maxDistance { get; set; }
    public override float damage { get; set; }
    public override GameObject muzzleEffect { get; set; }
    public override GameObject barrel { get; set; }

    public void Start()
    {
        maxDistance = _maxDistance; 
        damage = _damage;
        muzzleEffect = _muzzleEffect;
        barrel = _barrel;
        base.Start();
    }

    public override void Shoot()
    {
        {
            RaycastHit hit;
            int mask = ~(1 << playerLayer);
            Vector3 direction = playerCamera.transform.forward;
            direction += new Vector3(Random.Range(0, spreadOffsets.x), Random.Range(0, spreadOffsets.y), 0);
            bool anythingHit = Physics.Raycast(playerCamera.transform.position, direction, out hit, maxDistance, mask);

            if (anythingHit)
            {
                if (hit.collider.gameObject.CompareTag(targetTag) && hit.collider.gameObject.TryGetComponent<Target>(out Target target))
                {
                    target.TakeDamage(damage);
                }

                GameObject effect = Instantiate(_muzzleEffect, hit.point + hit.normal * 0.05f, Quaternion.LookRotation(hit.normal));
                effect.SetActive(true);
            }
        }
    }
}
 
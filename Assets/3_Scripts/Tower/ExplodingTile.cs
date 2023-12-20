using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingTile : TowerTile
{
    [SerializeField]
    float radius;
    [SerializeField]
    float force;
    [SerializeField]
    Material explosiveTileMaterial;

    new Collider collider;

    public override void Get()
    {
        base.Get();
        collider = GetComponent<Collider>();
    }
    public override void Release()
    {
        if (CameraShakeManager.Instance)
            CameraShakeManager.Instance.Play(1);
        if (TileColorManager.Instance)
            TileColorManager.Instance.OnColorListChanged -= ResetColor;
    }

    public override void SetColor(Color color)
    {
        if (Active)
            renderer.sharedMaterial = TileColorManager.GetSharedMaterial(explosiveTileMaterial, color);
        else
            renderer.sharedMaterial = TileColorManager.GetSharedMaterial(originalMaterial, color);
    }

    public override void Explode(bool instant = false)
    {
        if (!Active)
            return;
        base.Explode(instant);
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, 1 << gameObject.layer);
        foreach (Collider hit in hits) {
            if (hit == collider)
                continue;
            ExplodingTile tile = hit.GetComponent<ExplodingTile>();
            if (tile) {
                tile.Explode(true);
            } else {
                hit.attachedRigidbody?.AddExplosionForce(force, collider.bounds.center, radius, 0, ForceMode.Impulse);
            }
        }
    }

    protected override void OnExplosion()
    {
        MissionsManager.Instance.ProcessMissions(MissionType.DestroyExplosiveBarrels, 1);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerTileFactory : Singleton<TowerTileFactory>
{
    [SerializeField]
    private PoolManager<TowerTile> poolTiles;
    [SerializeField]
    private List<PoolManager<TowerTile>> poolSpecialTiles;

    private bool IsPoolingEnabled => RemoteConfig.BOOL_OBJECT_POOL_ENABLED && Application.isPlaying;
    
    public void Initialize()
    {
        if (!IsPoolingEnabled)
        {
            return;
        }
        
        poolTiles.Initialize(OnGetTile, OnReleaseTile);
        poolSpecialTiles.ForEach(pool => pool.Initialize(OnGetTile, OnReleaseTile));
    }


    public TowerTile Create(Vector3 position, Quaternion direction, Transform parent, float specialTileChance)
    {
        PoolManager<TowerTile> pool = GetPool(specialTileChance);
        
        if (IsPoolingEnabled)
        {
            return pool.Get(position, direction, parent);
        }

        TowerTile prefab = pool.Prefab;
        Quaternion rotation = direction * prefab.transform.rotation;
        TowerTile towerTile = Instantiate(prefab, position, rotation, parent);
        OnGetTile(towerTile);
        return towerTile;
    }

    private PoolManager<TowerTile> GetPool(float specialTileChance)
    {
        bool isSpecial = Random.value <= specialTileChance;
        
        return !isSpecial ? poolTiles : poolSpecialTiles[Random.Range(0, poolSpecialTiles.Count)];
    }

    public void Delete(TowerTile tile)
    {
        if (IsPoolingEnabled)
        {
            poolTiles.Release(tile);
            return;
        }

        OnReleaseTile(tile);
        if (Application.isPlaying)
        {
            Destroy(tile.gameObject);
        }
        else
        {
            DestroyImmediate(tile.gameObject);
        }
    }

    private void OnGetTile(TowerTile tile)
    {
        tile.gameObject.SetActive(true);
        tile.Get();

    }
    
    private void OnReleaseTile(TowerTile tile)
    {
        tile.Release();
        tile.gameObject.SetActive(false);
    }
}

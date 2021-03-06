﻿using System.Collections.Generic;

using UnityEngine;

// Controls bombs, inherits from Projectile
public class Bomb : Projectile
{
    // Constructor criteria
    private readonly Ship Player;
    private readonly GameObject BombExplosionPrefab;
    private GameObject BombExplosionObject;
    private readonly float FiredTime;
    private readonly float Radius;

    // Projectile constructor
    public Bomb(Ship player, uint id, GameController.IFF iff, float damage, float radius, Vector3 position, Quaternion rotation, 
        Vector3 velocity, float speed, float lifetime)
    {
        this.Player = player;
        this.ID = id;
        this.IFF = iff;
        this.Damage = damage;
        this.Radius = radius;
        this.Position = position;
        this.Rotation = rotation;
        this.Velocity = velocity;
        this.Speed = speed;
        this.Lifetime = lifetime;
        this.ProjectilePrefab = Resources.Load<GameObject>(GameController.BombPrefabName);
        this.ProjectileObject = GameObject.Instantiate(this.ProjectilePrefab, this.Position, this.Rotation);
        this.BombExplosionPrefab = Resources.Load<GameObject>(GameController.BombExplostionPrefabName);
        this.FiredTime = Time.time;
        this.Initialize();
    }


    // Fixed Update is called a fixed number of times per second, Physics updates should be done in FixedUpdate
    public override void FixedUpdate()
    {
        // If bomb has existed for less than its lifetime max
        if(Time.time - this.FiredTime <= this.Lifetime)
        {
            // If projectile still exists
            if(this.ProjectileObject != null)
            {
                // Accelerate forward
                this.ProjectileRigidbody.velocity = this.ProjectileObject.transform.forward * this.Speed;
            }
            // If projectile has burnt out
            else
            {
                // Set to dead
                this.Alive = false;
                // Add to projectile removal list
                GameController.AddProjectileToRemovalList(this.ID);
            }
        }
        // If bomb has hit lifetime
        else
        {
            // Detonate bomb
            this.Detonate();
        }
    }

    // Detonate bomb
    public void Detonate()
    {
        // Spawn explosion object
        this.BombExplosionObject = GameObject.Instantiate(this.BombExplosionPrefab, this.ProjectileObject.transform.position, Quaternion.identity);
        // Set explosion object to self destroy after 1 second
        GameObject.Destroy(this.BombExplosionObject, 1);
        // Loop through all ships
        foreach(KeyValuePair<uint, Ship> ship in GameController.Ships)
        {
            // If ship is other faction and currently alive
            if(ship.Value.IFF != this.IFF && ship.Value.Alive == true)
            {
                // Get distance from ship to bomb
                float distance = Vector3.Distance(this.ProjectileObject.transform.position, ship.Value.ShipObject.transform.position);
                // If distance is less than bomb radius
                if(distance <= this.Radius)
                {
                    // Tell ship to take damage relative to it's distance to the bomb
                    ship.Value.TakeDamage(this.Damage - (distance / this.Radius * this.Damage));
                }
            }
        }
        // Set to not alive
        this.Alive = false;
        // Destroy game object
        GameObject.Destroy(this.ProjectileObject);
        // Add to projectile removal list
        GameController.AddProjectileToRemovalList(this.ID);
    }
}

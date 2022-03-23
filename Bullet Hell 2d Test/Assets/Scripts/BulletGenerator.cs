using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private int numberOfColumns;
    [SerializeField] private float speed;
    [SerializeField] private Sprite texture;
    [SerializeField] private Color color;
    [SerializeField] private float lifetime;
    [SerializeField] private float firerate;
    [SerializeField] private float size;
    [SerializeField] private Material material;
    [SerializeField] private float spinSpeed;
    private float angle;
    private float time;

    private ParticleSystem system;

    private void Awake()
    {
        GenerateBullets();
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        
        transform.rotation = Quaternion.Euler(0,0,time * spinSpeed);
    }

    void GenerateBullets()
    {
        angle = 360f / numberOfColumns;

        for (int i = 0; i < numberOfColumns; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 100000;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            var emission = system.emission;
            emission.enabled = false;

            var shape = system.shape;
            shape.enabled = true;
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.sprite = null;

            var text = system.textureSheetAnimation;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);
            text.enabled = true;

            var collision = system.collision;
            collision.enabled = true;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.lifetimeLoss = 1;
            collision.sendCollisionMessages = true;
            
            go.GetComponent<ParticleSystemRenderer>().renderMode = ParticleSystemRenderMode.Stretch;
            go.GetComponent<ParticleSystemRenderer>().lengthScale = 1;
        }

        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, firerate);
    }

    void DoEmit()
    {
        foreach (Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;
            system.Emit(emitParams, 10);
        }
    }
}
using GameEngine.Systems;

namespace GameEngine;
public class Scene
{
    public AssetsDatabase Assets { get; } = new();
    private readonly Dictionary<Type, List<Component>> _componentsByType = [];
    private readonly Dictionary<Entity, List<Component>> _componentsByEntity = [];
    private readonly List<GameSystem> _systems = [];
    private readonly List<Entity> _entities = [];

    public static Scene CreateDefault()
    {
        var scene = new Scene();
        scene.Assets.Load();
        scene.AddSystem<RenderSystem>();
        scene.AddSystem<TimeSystem>();
        scene.AddSystem<CollisionSystem>();

        return scene;
    }

    public void RemoveEntity<T>(T entity) where T : Entity
    {
        _entities.Remove(entity);
        _componentsByEntity.Remove(entity);

        foreach (var kvp in _componentsByType)
        {
            kvp.Value.RemoveAll(c => c.Entity.Equals(entity));
        }

        entity.Dispose();
    }

    public void RemoveComponent<T>(Entity entity) where T : Component
    {
        if (_componentsByEntity.TryGetValue(entity, out var entityComponents))
        {
            entityComponents.RemoveAll(c => c is T);
        }

        if (_componentsByType.TryGetValue(typeof(T), out var typeComponents))
        {
            typeComponents.RemoveAll(c => c.Entity.Equals(entity));
        }
    }

    public IEnumerable<T> GetComponents<T>(Entity entity) where T : Component
    {
        return _componentsByEntity.GetValueOrDefault(entity, []).OfType<T>();
    }

    public IEnumerable<T> GetComponents<T>() where T : Component
    {
        return _componentsByType.GetValueOrDefault(typeof(T), []).Cast<T>();
    }

    public T? GetComponent<T>(Entity entity) where T : Component
    {
        return GetComponents<T>(entity).FirstOrDefault();
    }

    public T? GetEntity<T>() where T : Entity
    {
        return _entities.OfType<T>().FirstOrDefault();
    }

    public T CreateEntity<T>() where T : Entity, new()
    {
        var entity = new T
        {
            Scene = this
        };

        entity.Initialize();
        _entities.Add(entity);

        return entity;
    }

    internal T AddComponent<T>(Entity entity) where T : Component, new()
    {
        var component = new T
        {
            Entity = entity
        };

        if (_componentsByType.TryGetValue(typeof(T), out var existingComponents))
        {
            existingComponents.Add(component);
        }
        else
        {
            _componentsByType.Add(typeof(T), [component]);
        }

        if (_componentsByEntity.TryGetValue(entity, out var existingEntityComponents))
        {
            existingEntityComponents.Add(component);
        }
        else
        {
            _componentsByEntity.Add(entity, [component]);
        }

        return component;
    }

    public T AddSystem<T>() where T : GameSystem, new()
    {
        var system = new T
        {
            Scene = this
        };

        system.Initialize();
        _systems.Add(system);

        return system;
    }

    public virtual void Update(double time)
    {
        foreach (var system in _systems)
        {
            system.Update(time);
        }

        foreach (var entity in _entities)
        {
            entity.Update(time);
        }
    }
}

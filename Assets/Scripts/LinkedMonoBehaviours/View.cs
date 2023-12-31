using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyedListener, IScaleListener
{
    protected GameEntity _linkedEntity;

    public virtual void Link(IEntity entity)
    {
        gameObject.Link(entity);
        _linkedEntity = (GameEntity)entity;
        _linkedEntity.AddPositionListener(this);
        _linkedEntity.AddDestroyedListener(this);
        _linkedEntity.AddScaleListener(this);

        var pos = _linkedEntity.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public void Unlink()
    {
    }

    public virtual void OnPosition(GameEntity entity, Vector3 value)
    {
        transform.localPosition = new Vector3(value.x, value.y);
    }

    public virtual void OnDestroyed(GameEntity entity) => DestroyMe();

    protected virtual void DestroyMe()
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }

    public void OnScale(GameEntity entity, float scale)
    {
        transform.localScale = scale * Vector3.one*Constants.SCALE_MODIFIER;
    }
}


using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using static GameMatcher;

public sealed class AddViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _parent;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        _parent = new GameObject("Views").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(Asset);

    protected override bool Filter(GameEntity entity) => entity.hasAsset && !entity.asset.isLoading;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            StartLinkingView(e);
        }
    }

    void StartLinkingView(GameEntity entity)
    {
        entity.asset.isLoading = true;
        var opHandle = Addressables.LoadAssetAsync<GameObject>(entity.asset.assetKey);
        opHandle.Completed += (x) => ObjectLoadCompleted(x, entity);
    }

    private void ObjectLoadCompleted(AsyncOperationHandle<GameObject> obj, GameEntity entity)
    {
        var view = GameObject.Instantiate(obj.Result, _parent).GetComponent<IView>();
        view.Link(entity);
        entity.AddView(view);
    }
}

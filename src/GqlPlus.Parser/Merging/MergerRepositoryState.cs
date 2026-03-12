namespace GqlPlus.Merging;

internal sealed class MergerRepositoryState(
  BaseFactory<IMergerRepository>.FactoryDict mergers,
  BaseFactory<IMergerRepository>.FactoryDict allMergers,
  Dictionary<Type, List<Type>> allMergerTypes
) : BaseFactory<IMergerRepository>
{
  internal FactoryDict Mergers { get; } = mergers;
  internal FactoryDict AllMergers { get; } = allMergers;
  internal Dictionary<Type, List<Type>> AllMergerTypes { get; } = allMergerTypes;
}

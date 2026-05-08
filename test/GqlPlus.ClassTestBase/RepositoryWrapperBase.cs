using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using GqlPlus.Factories;

namespace GqlPlus;

public abstract class RepositoryWrapperBase<TInterface, TClass>(
  TInterface repo
) : BaseFactory<TInterface>
  where TClass : class, TInterface
  where TInterface : IRepository
{
  public void WriteFactories(string label,
    [NotNull] IEnumerable<KeyValuePair<Type, Factory<object, TInterface>>> keyedFactories,
    [NotNull] params KeyValuePair<Type, FactoryList>[] keyedLists)
  {
    foreach ((Type key, Factory<object, TInterface> factory) in keyedFactories) {
      AddRelationship("=", key, factory);
    }

    foreach ((Type key, FactoryList factories) in keyedLists) {
      for (int i = 0; i < factories.Count; i++) {
        AddRelationship($"#{i}", key, factories[i]);
      }
    }

    DiFluid.WriteTree(label + "Repository", _relationships);
  }

  private readonly Map<DiTree> _relationships = [];
  protected abstract TInterface Wrapper { get; }

  protected TInterface AddRelationship<T>(string callerName)
    => repo.FluentAction(_
      => AddRelationship(callerName, ResolvedType(), typeof(T)));
  private void AddRelationship(string callerName, Type callerTtype, Factory<object, TInterface> factory)
  {
    object? instance = factory?.Invoke(Wrapper);
    if (instance is not null) {
      AddRelationship(callerName, callerTtype, instance.GetType());
    }
  }
  private void AddRelationship(string callerName, Type? callerType, Type targetType)
  {
    string targetName = targetType.SafeTypeName();
    if (callerType is not null) {
      string name = callerType.SafeTypeName().Split('+')[0];
      if (_relationships.TryGetValue(name, out DiTree? tree)) {
        tree.Requires.TryAdd(callerName, targetName);
      } else {
        _relationships[name] = new DiTree(name, false, 0) {
          Requires = [targetName.ToPair(callerName)]
        };
      }
    }
  }

  private readonly Type[] _baseTypes = [typeof(TClass), typeof(RepositoryWrapperBase<,>), typeof(GeneralHelpers)];

  private Type? ResolvedType()
  {
    int skipFrames = 1;

    Type? callerType = FrameCallerType(skipFrames);
    while (_baseTypes.Contains(callerType)) {
      skipFrames++;
      callerType = FrameCallerType(skipFrames);
    }

    Type? lastType = null;
    while (callerType is { ContainsGenericParameters: true }) {
      if (_baseTypes.Contains(callerType)) {
        return lastType;
      }

      lastType = callerType;
      skipFrames++;
      callerType = FrameCallerType(skipFrames);
    }

    return callerType;

    static Type? FrameCallerType(int skip)
    {
      Type? callerType = new StackFrame(skip).GetMethod()?.DeclaringType;
      while (callerType?.IsNested == true) {
        callerType = callerType.DeclaringType;
      }

      return callerType;
    }
  }

  protected string CallerName
    => ResolvedType()?.SafeTypeName() ?? "Unknown";
}

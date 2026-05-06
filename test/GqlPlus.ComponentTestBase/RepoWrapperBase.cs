using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace GqlPlus;

public abstract class RepoWrapperBase<TInterface, TClass>(
  TInterface repo
) where TClass : class, TInterface
{
  public void WriteFactories(string label, [NotNull] IEnumerable<KeyValuePair<Type, Factory<object, TInterface>>> factories)
  {
    foreach ((Type key, Factory<object, TInterface> factory) in factories) {
      object instance = factory(Wrapper);
      AddRelationship("=", key, instance.GetType());
    }

    DiFluid.WriteTree(label + "Repo", _relationships);
  }

  private readonly Map<DiTree> _relationships = [];
  public abstract TInterface Wrapper { get; }

  public TInterface AddRelationship<T>(string callerName)
  {
    AddRelationship(callerName, ResolvedType(), typeof(T));

    return repo;
  }

  public void AddRelationship(string callerName, Type? callerType, Type targetType)
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

  private readonly Type[] _baseTypes = [typeof(TClass), typeof(RepoWrapperBase<,>)];

  private Type? ResolvedType()
  {
    int skipFrames = 1;

    while (_baseTypes.Contains(FrameCallerType(skipFrames))) {
      skipFrames++;
    }

    Type? callerType;
    Type? lastType = null;
    do {
      callerType = FrameCallerType(skipFrames);
      if (_baseTypes.Contains(callerType)) {
        return lastType;
      }

      lastType = callerType;
      skipFrames++;
    } while (callerType is { ContainsGenericParameters: true });

    return callerType;

    static Type? FrameCallerType(int skip)
      => new StackFrame(skip).GetMethod()?.DeclaringType;
  }
}

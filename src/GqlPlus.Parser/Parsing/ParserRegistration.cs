namespace GqlPlus.Parsing;

internal class ParserRepositoryBuilder
{
  internal readonly Dictionary<Type, Type> Singles = [];
  internal readonly Dictionary<Type, Type> Arrays = [];
  internal readonly Dictionary<Type, Type> InterfaceSingles = [];
  internal readonly Dictionary<Type, Type> InterfaceArrays = [];

  internal void AddSingle(Type forType, Type serviceType)
    => Singles[forType] = serviceType;

  internal void AddArray(Type forType, Type serviceType)
    => Arrays[forType] = serviceType;

  internal void AddInterfaceSingle(Type interfaceType, Type serviceType)
    => InterfaceSingles[interfaceType] = serviceType;

  internal void AddInterfaceArray(Type interfaceType, Type serviceType)
    => InterfaceArrays[interfaceType] = serviceType;
}


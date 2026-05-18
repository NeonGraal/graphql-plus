using System.Runtime.CompilerServices;

namespace GqlPlus.Resolving;

public interface IResolverRepository
  : IRepository
{
  Resolver<T>.D ResolverFor<T>([CallerMemberName] string callerName = "")
    where T : IModelBase;

  DeferList<ITypeResolver>.D TypeResolvers([CallerMemberName] string callerName = "");
}

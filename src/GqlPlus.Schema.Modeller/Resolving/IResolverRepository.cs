using System.Runtime.CompilerServices;

namespace GqlPlus.Resolving;

internal interface IResolverRepository
  : IRepository
{
  Defer<IResolver<T>>.D ResolverFor<T>([CallerMemberName] string callerName = "")
    where T : IModelBase;

  Defer<ITypeResolver>.DA TypeResolvers([CallerMemberName] string callerName = "");
}

using System.Runtime.CompilerServices;

namespace GqlPlus.Resolving;

internal interface IResolverRepository
  : IRepository
{
  IResolver<T> ResolverFor<T>([CallerMemberName] string callerName = "")
    where T : IModelBase;

  IEnumerable<ITypeResolver> TypeResolvers { get; }
}

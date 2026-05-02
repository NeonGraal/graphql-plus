using System.Runtime.CompilerServices;

namespace GqlPlus.Resolving;

internal interface IResolverRepository
{
  IResolver<T> ResolverFor<T>([CallerMemberName] string callerName = "")
    where T : IModelBase;

  IEnumerable<ITypeResolver> TypeResolvers { get; }
}

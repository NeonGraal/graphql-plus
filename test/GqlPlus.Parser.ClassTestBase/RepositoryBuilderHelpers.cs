using System.Diagnostics.CodeAnalysis;
using GqlPlus.Ast.Schema;
using GqlPlus.Merging;

namespace GqlPlus;

#pragma warning disable IDE1006 // Naming Styles
public static class RepositoryBuilderHelpers
{
  public static void AllMergersForReturns<T>([NotNull] this IMergerRepository repo, params IMergeAll<T>[] results)
    where T : IAstType
  {
    IEnumerable<IMergeAll<T>> factory() => results;
    repo.AllMergersFor<T>().ReturnsForAnyArgs(factory);
  }

  public static void MergerForReturns<T>([NotNull] this IMergerRepository repo, IMerge<T> result)
    where T : IAstError
  {
    IMerge<T> factory() => result;
    repo.MergerFor<T>().ReturnsForAnyArgs(factory);
  }
}

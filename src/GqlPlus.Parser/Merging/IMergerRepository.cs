using System.Runtime.CompilerServices;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public interface IMergerRepository
  : IRepository
{
  DeferOne<IMerge<T>>.D MergerFor<T>([CallerMemberName] string callerName = "") where T : IAstError;
  DeferList<IMergeAll<T>>.D AllMergersFor<T>([CallerMemberName] string callerName = "") where T : IAstType;
}

using System.Runtime.CompilerServices;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public interface IMergerRepository
  : IRepository
{
  Defer<IMerge<T>>.D MergerFor<T>([CallerMemberName] string callerName = "") where T : IAstError;
  Defer<IMergeAll<T>>.DA AllMergersFor<T>([CallerMemberName] string callerName = "") where T : IAstType;
}

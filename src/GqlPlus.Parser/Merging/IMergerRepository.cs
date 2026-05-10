using System.Runtime.CompilerServices;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public interface IMergerRepository
  : IRepository
{
  MergerOne<T>.D MergerFor<T>([CallerMemberName] string callerName = "") where T : IAstError;
  MergerList<T>.D AllMergersFor<T>([CallerMemberName] string callerName = "") where T : IAstType;
}

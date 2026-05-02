using System.Runtime.CompilerServices;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public interface IMergerRepository
{
  ILoggerFactory LoggerFactory { get; }
  IMerge<T> MergerFor<T>([CallerMemberName] string callerName = "") where T : IAstError;
  IEnumerable<IMergeAll<T>> AllMergersFor<T>([CallerMemberName] string callerName = "") where T : IAstType;
}

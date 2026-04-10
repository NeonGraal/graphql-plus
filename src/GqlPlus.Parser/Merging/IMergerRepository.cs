using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

public interface IMergerRepository
{
  ILoggerFactory LoggerFactory { get; }
  IMerge<T> MergerFor<T>() where T : IAstError;
  IEnumerable<IMergeAll<T>> AllMergersFor<T>() where T : IAstType;
}

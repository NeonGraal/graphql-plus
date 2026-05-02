using System.Diagnostics.CodeAnalysis;
using GqlPlus.Ast.Schema;
using GqlPlus.Merging;
using GqlPlus.Structures;

namespace GqlPlus;

static public class RepositoryBuilderHelpers
{
  public static void AllMergersForReturns<T>([NotNull] this IMergerRepository repo, params IMergeAll<T>[] results)
    where T : IAstType
    => repo.AllMergersFor<T>().ReturnsForAnyArgs(results);

  public static void MergerForReturns<T>([NotNull] this IMergerRepository repo, IMerge<T> result)
    where T : IAstError
    => repo.MergerFor<T>().ReturnsForAnyArgs(result);

  public static void DecoderForReturns<T>([NotNull] this IDecoderRepository repo, IDecoder<T> result)
    => repo.DecoderFor<T>().ReturnsForAnyArgs(result);

  public static void DecoderForReturns<TDecoder, TBase>([NotNull] this IDecoderRepository repo, TDecoder result)
    where TDecoder : class, IDecoder<TBase>
    => repo.DecoderFor<TDecoder, TBase>().ReturnsForAnyArgs(result);

  public static void EncoderForReturns<T>([NotNull] this IEncoderRepository repo, IEncoder<T> result)
    => repo.EncoderFor<T>().ReturnsForAnyArgs(result);

  public static void EncodersForReturns<TList>([NotNull] this IEncoderRepository repo, params TList[] results)
    where TList : class
    => repo.EncodersFor<TList>().ReturnsForAnyArgs(results);
}

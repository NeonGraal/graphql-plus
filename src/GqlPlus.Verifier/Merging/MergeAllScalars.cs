using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllScalars(
  IMerge<AstScalar<ScalarRangeNumberAst>> numbers,
  IMerge<AstScalar<ScalarRegexAst>> regexes,
  IMerge<AstScalar<ScalarReferenceAst>> references
) : IMerge<AstScalar>
{
  public bool CanMerge(IEnumerable<AstScalar> items)
  {
    if (items.Count() < 2) {
      return items.Count() == 1;
    }

    if (items.Select(i => i.GetType()).Distinct().Count() != 1) {
      return false;
    }

    var first = items.First();

    return first switch {
      AstScalar<ScalarRangeNumberAst> => numbers.CanMerge(items.Cast<AstScalar<ScalarRangeNumberAst>>()),
      AstScalar<ScalarRegexAst> => regexes.CanMerge(items.Cast<AstScalar<ScalarRegexAst>>()),
      AstScalar<ScalarReferenceAst> => references.CanMerge(items.Cast<AstScalar<ScalarReferenceAst>>()),
      _ => false,
    };
  }

  public IEnumerable<AstScalar> Merge(IEnumerable<AstScalar> items)
  {
    if (items == null) {
      return [];
    }

    var numberKinds = items.OfType<AstScalar<ScalarRangeNumberAst>>();
    var regexKinds = items.OfType<AstScalar<ScalarRegexAst>>();
    var referenceKinds = items.OfType<AstScalar<ScalarReferenceAst>>();

    var numbersMerged = numbers.Merge(numberKinds);
    var regexesMerged = regexes.Merge(regexKinds);
    var referencesMerged = references.Merge(referenceKinds);

    return [.. numbersMerged, .. regexesMerged, .. referencesMerged];
  }
}

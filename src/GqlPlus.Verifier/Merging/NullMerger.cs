using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class NullMerger<TAliased>(ILoggerFactory logger)
  : IMerge<TAliased>
  where TAliased : AstAliased
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(NullMerger<TAliased>));

  public bool CanMerge(TAliased[] items)
  {
    _logger.LogInformation("Null merging of {Type}", items.GetType().GetElementType()?.ExpandTypeName());
    return items.Length == 1;
  }

  public TAliased Merge(TAliased[] items) => items.First();
}

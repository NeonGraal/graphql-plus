using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class GroupedVerifier<TAliased>(
   IMerge<TAliased> merger,
   ILoggerFactory logger
) : IVerifyAliased<TAliased>
 where TAliased : AstAliased
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(GroupedVerifier<TAliased>));

  public abstract string Label { get; }

  public virtual void Verify(TAliased[] item, ITokenMessages errors)
  {
    if (item.Length == 0) {
      return;
    }

    _logger.LogInformation("Group verifying of {Type}", item.GetType().GetElementType()?.ExpandTypeName());

    var byId = item.AliasedMap();

    foreach (var (id, definitions) in byId) {
      _logger.LogInformation("Verifying {Id} with {Count} definitions", id, definitions.Length);

      if (!merger.CanMerge(definitions)) {
        errors.Add(definitions.Last().Error($"Multiple {Label} with id '{id}' can't be merged."));
      }
    }
  }
}

public interface IVerifyAliased<TAliased> : IVerify<TAliased[]>
    where TAliased : AstAliased
{ }

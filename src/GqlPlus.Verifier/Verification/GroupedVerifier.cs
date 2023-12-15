using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GqlPlus.Verifier.Verification;

internal abstract class GroupedVerifier<TAliased>(
   IMerge<TAliased> merger,
   ILoggerFactory logger
) : IVerifyAliased<TAliased>
 where TAliased : AstAliased
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(GroupedVerifier<TAliased>));

  public abstract string Label { get; }

  public virtual ITokenMessages Verify(TAliased[] item)
  {
    var errors = new TokenMessages();

    if (item.Length == 0) {
      return errors;
    }

    _logger.LogInformation("Group verifying of {Type}", item.GetType().GetElementType()?.ExpandTypeName());

    var byId = item.AliasedMap();

    foreach (var (id, definitions) in byId) {
      _logger.LogInformation("Verifying {Id} with {Count} definitions", id, definitions.Length);

      if (!merger.CanMerge(definitions)) {
        errors.Add(definitions.Last().Error($"Multiple {Label} with id '{id}' can't be merged."));
      }
    }

    return errors;
  }
}

public interface IVerifyAliased<TAliased> : IVerify<TAliased[]>
    where TAliased : AstAliased
{ }

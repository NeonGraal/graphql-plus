using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal abstract class AliasedVerifier<TAliased>(
   IVerify<TAliased> verifier,
   IMerge<TAliased> merger,
   ILoggerFactory logger
) : IVerifyAliased<TAliased>
 where TAliased : AstAliased
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(AliasedVerifier<TAliased>));

  public abstract string Label { get; }

  public ITokenMessages Verify(TAliased[] item)
  {
    var errors = new TokenMessages();

    if (item.Length == 0) {
      return errors;
    }

    _logger.LogInformation("Alias verifying of {Type}", item.GetType().GetElementType()?.ExpandTypeName());

    var byId = item.AliasedMap();

    foreach (var (id, definitions) in byId) {
      _logger.LogInformation("Verifying {Id} with {Count} definitions", id, definitions.Length);
      foreach (var group in definitions.GroupBy(GroupKey)) {
        if (!merger.CanMerge([.. group])) {
          errors.Add(group.Last().Error($"Invalid {Label}. Multiple {Label} with id '{id}' and group '{group.Key}' found."));
          continue;
        }
      }
    }

    errors.AddRange(item.SelectMany(verifier.Verify));

    return errors;
  }

  protected abstract object GroupKey(TAliased item);
}

public interface IVerifyAliased<TAliased> : IVerify<TAliased[]>
    where TAliased : AstAliased
{ }

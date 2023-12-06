using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal abstract class AliasedVerifier<TAliased>(
   IVerify<TAliased> verifier,
   IMerge<TAliased> merger
) : IVerifyAliased<TAliased>
 where TAliased : AstAliased
{
  public abstract string Label { get; }

  public ITokenMessages Verify(TAliased[] item)
  {
    var errors = new TokenMessages();

    var byId = item.AliasedMap();

    foreach (var (id, definitions) in byId) {
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

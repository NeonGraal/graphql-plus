using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal abstract class AliasedVerifier<TAliased>(
   IVerify<TAliased> definition
) : IVerifyAliased<TAliased>
 where TAliased : AstAliased
{
  public abstract string Label { get; }

  public ITokenMessages Verify(TAliased[] target)
  {
    var errors = new TokenMessages();

    var byId = target.AliasedMap();

    foreach (var (id, definitions) in byId) {
      foreach (var group in definitions.GroupBy(GroupKey)) {
        if (group.Count() > 1) {
          errors.Add(group.Last().Error($"Invalid {Label}. Multiple {Label} with id '{id}' and group '{group.Key}' found."));
          continue;
        }
      }
    }

    errors.AddRange(target.SelectMany(definition.Verify));

    return errors;
  }

  protected abstract object GroupKey(TAliased aliased);
}

public interface IVerifyAliased<TAliased> : IVerify<TAliased[]>
    where TAliased : AstAliased
{ }

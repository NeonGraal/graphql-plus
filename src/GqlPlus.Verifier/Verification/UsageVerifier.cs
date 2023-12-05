using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal abstract class UsageVerifier<TUsage, TDefinition>(
    IVerify<TUsage>? usage,
    IVerify<TDefinition>? definition
) : IVerifyUsage<TUsage, TDefinition>
  where TUsage : AstBase where TDefinition : AstNamed
{
  public abstract string Label { get; }
  public abstract string UsageKey(TUsage item);

  public IEnumerable<TokenMessage> Verify(UsageDefinitions<TUsage, TDefinition> target)
  {
    var errors = new List<TokenMessage>();

    var used = target.Usages.ToDictionary(UsageKey);

    var defined = target.Definitions.ToDictionary(f => f.Name);

    foreach (var (k, u) in used) {
      if (!defined.ContainsKey(k)) {
        errors.Add(u.Error($"Invalid {Label} usage. {Label} not defined."));
      }

      if (usage is not null) {
        errors.AddRange(usage.Verify(u));
      }
    }

    foreach (var (k, d) in defined) {
      if (!used.ContainsKey(k)) {
        errors.Add(d.Error($"Invalid {Label} definition. {Label} not used."));
      }

      if (definition is not null) {
        errors.AddRange(definition.Verify(d));
      }
    }

    return errors;
  }
}

public record class UsageDefinitions<TUsage, TDefinition>(TUsage[] Usages, TDefinition[] Definitions)
  where TUsage : AstBase where TDefinition : AstNamed;

public interface IVerifyUsage<TUsage, TDefinition> : IVerify<UsageDefinitions<TUsage, TDefinition>>
    where TUsage : AstBase where TDefinition : AstNamed
{ }

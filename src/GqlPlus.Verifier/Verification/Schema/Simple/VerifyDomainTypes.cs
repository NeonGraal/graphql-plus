using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema.Simple;

internal class VerifyDomainTypes(
  IVerifyAliased<AstDomain> aliased,
  IEnumerable<IVerifyDomain> domains
) : AstParentVerifier<AstDomain, string, EnumContext>(aliased)
{
  protected override string GetParent(AstType<string> usage)
    => usage.Parent ?? "";

  protected override EnumContext MakeContext(AstDomain usage, AstType[] aliased, ITokenMessages errors)
  {
    var validTypes = aliased.AliasedMap(p => (AstDescribed)p.First());

    return new(validTypes, errors, aliased.MakeEnumValues());
  }

  protected override void UsageValue(AstDomain usage, EnumContext context)
  {
    base.UsageValue(usage, context);

    foreach (var domain in domains) {
      domain.Verify(usage, context);
    }
  }

  protected override bool CheckAstParent(AstDomain usage, AstDomain? parent, EnumContext context)
  {
    if (base.CheckAstParent(usage, parent, context)) {
      if (usage.Domain == parent.Domain) {
        return true;
      } else {
        context.AddError(usage, usage.Label + " Parent", $"'{parent.Name}' invalid domain. Found '{parent.Domain}'");
      }
    }

    return false;
  }

  protected override void CheckMergeParent(ParentUsage<AstDomain> input, EnumContext context)
  {
    var failures = domains.SelectMany(domain => domain.CanMergeItems(input.Usage, context));
    if (failures.Any()) {
      context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} items into Parent {input.Parent} items");
      context.Add(failures);
    }
  }
}

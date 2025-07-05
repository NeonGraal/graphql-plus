using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyDomainTypes(
  IVerifyAliased<IGqlpDomain> aliased,
  IEnumerable<IVerifyDomain> domains
) : AstParentVerifier<IGqlpDomain, IGqlpTypeRef, EnumContext>(aliased)
{
  protected sealed override string GetParent(IGqlpType<IGqlpTypeRef> usage)
    => usage.Parent?.Name ?? "";

  protected override EnumContext MakeContext(IGqlpDomain usage, IGqlpType[] aliased, IMessages errors)
  {
    IMap<IGqlpDescribed> validTypes = aliased.AliasedMap(p => (IGqlpDescribed)p.First());

    return new(validTypes, errors, aliased.MakeEnumValues());
  }

  protected override void UsageValue(IGqlpDomain usage, EnumContext context)
  {
    base.UsageValue(usage, context);

    foreach (IVerifyDomain domain in domains) {
      domain.Verify(usage, context);
    }
  }

  protected override bool CheckAstParent(IGqlpDomain usage, IGqlpDomain? parent, EnumContext context)
  {
    if (base.CheckAstParent(usage, parent, context)) {
      if (usage.DomainKind == parent.DomainKind) {
        return true;
      } else {
        context.AddError(usage, usage.Label + " Parent", $"'{parent.Name}' invalid domain. Found '{parent.DomainKind}'");
      }
    }

    return false;
  }

  protected override void CheckMergeParent(ParentUsage<IGqlpDomain> input, EnumContext context)
  {
    IEnumerable<IMessage> failures = domains.SelectMany(domain => domain.CanMergeItems(input.Usage, context));
    if (failures.Any()) {
      context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} items into Parent {input.Parent} items");
      context.Add(failures);
    }
  }
}

using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyDomainTypes(IVerifierRepository verifiers) : AstParentVerifier<IGqlpDomain, IAstTypeRef, EnumContext>(verifiers)
{
  private readonly IEnumerable<IVerifyDomain> _domains = verifiers.GetDomains();

  protected sealed override string GetParent(IAstType<IAstTypeRef> usage)
   => (usage.Parent?.Name).IfWhiteSpace();

  protected override EnumContext MakeContext(IGqlpDomain usage, IAstType[] aliased, IMessages errors)
  {
    IMap<IAstDescribed> validTypes = aliased.AliasedMap(p => (IAstDescribed)p.First());

    return new(validTypes, errors, aliased.MakeEnumValues());
  }

  protected override void UsageValue(IGqlpDomain usage, EnumContext context)
  {
    base.UsageValue(usage, context);

    foreach (IVerifyDomain domain in _domains) {
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

  protected override void CheckMergeParent(SelfUsage<IGqlpDomain> input, EnumContext context)
  {
    IEnumerable<IMessage> failures = _domains.SelectMany(domain => domain.CanMergeItems(input.Usage, context));
    if (failures.Any()) {
      context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} items into Parent {input.Current} items");
      context.Add(failures);
    }
  }
}

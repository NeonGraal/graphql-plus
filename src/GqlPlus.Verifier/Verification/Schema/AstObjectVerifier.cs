using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class AstObjectVerifier<TObject, TField, TReference, TContext>(
  IVerifyAliased<TObject> aliased,
  IMerge<TField> mergeFields,
  IMerge<AstAlternate<TReference>> mergeAlternates,
  ILoggerFactory logger
) : AstParentItemVerifier<TObject, TReference, TContext, TField>(aliased, mergeFields)
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
  where TContext : UsageContext
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(AstParentItemVerifier<TObject, TReference, TContext, TypeParameterAst>));

  protected override void UsageValue(TObject usage, TContext context)
  {
    base.UsageValue(usage, context);

    if (usage.Parent is not null) {
      context.CheckType(usage.Parent, false);
    }

    foreach (var field in usage.Fields) {
      UsageField(field, context);
    }

    var input = new ParentUsage<TObject>([], usage, "an alternative");
    _logger.LogInformation("Checking Alternates with {Input}", input);
    foreach (var alternate in usage.Alternates) {
      UsageAlternate(alternate, context);
      if (alternate.Modifiers.Length == 0) {
        CheckAlternate(new([alternate.Type.FullName], usage, "an alternate"), usage.Name, context, true);
      }
    }

    foreach (var typeParameter in usage.TypeParameters) {
      if (!context.Used.Contains("$" + typeParameter.Name)) {
        context.AddError(typeParameter, usage.Label, $"'${typeParameter.Name}' not used");
      }
    }
  }

  protected virtual void UsageAlternate(AstAlternate<TReference> alternate, TContext context)
    => context
      .CheckType(alternate.Type)
      .CheckModifiers(alternate);

  protected virtual void UsageField(TField field, TContext context)
    => context
      .CheckType(field.Type)
      .CheckModifiers(field);

  protected override string GetParent(AstType<TReference> usage)
    => usage.Parent?.FullName ?? "";

  protected override void CheckParentType(
    ParentUsage<TObject> input,
    TContext context,
    bool top,
    Action<TObject>? onParent = null)
  {
    if (input.Parent?.StartsWith('$') == true) {
      var parameter = input.Parent[1..];
      if (top && input.Usage.TypeParameters.All(p => p.Name != parameter)) {
        context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Parent}' not defined");
      }

      return;
    }

    base.CheckParentType(input, context, top, onParent);
  }

  protected override IEnumerable<TField> GetItems(TObject usage)
    => usage.Fields;

  protected override void OnParentType(ParentUsage<TObject> input, TContext context, TObject parentType, bool top)
  {
    base.OnParentType(input, context, parentType, top);

    _logger.LogInformation("Checking Alternates with {Input}, {Top} of {ParentType}", input, top, parentType.Name);
    input = input with { Label = "an alternate" };
    foreach (var alternate in parentType.Alternates) {
      if (alternate.Modifiers.Length == 0) {
        CheckAlternate(input.AddParent(alternate.Type.FullName), parentType.Name, context, false);
      }
    }
  }

  private void CheckAlternate(ParentUsage<TObject> input, string current, TContext context, bool top)
  {
    if (context.DifferentName(input, top ? null : current)
      && context.GetType(input.Parent, out var type)
      && type is TObject alternateType) {
      CheckParent(input, alternateType, context, false);

      _logger.LogInformation("Checking Alternates with {Input}, {Top} of {AlternateType}, {Current}", input, top, alternateType.Name, current);
      foreach (var alternate in alternateType.Alternates) {
        if (alternate.Modifiers.Length == 0) {
          CheckAlternate(input.AddParent(alternate.Type.FullName), alternateType.Name, context, false);
        }
      }
    }
  }

  protected override bool CanMergeParent(ParentUsage<TObject> input, TContext context)
  {
    var alternates = GetParentItems(input, input.Usage, context, ast => ast.Alternates).ToArray();

    return base.CanMergeParent(input, context)
      && (alternates.Length == 0 || mergeAlternates.CanMerge(alternates));
  }
}

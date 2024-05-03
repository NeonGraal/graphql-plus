using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema;

[SuppressMessage("Performance", "CA1823:Avoid unused private fields")]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
internal abstract partial class AstObjectVerifier<TObject, TObjField, TObjBase, TContext>(
  IVerifyAliased<TObject> aliased,
  IMerge<TObjField> mergeFields,
  IMerge<AstAlternate<TObjBase>> mergeAlternates,
  ILoggerFactory logger
) : AstParentItemVerifier<TObject, TObjBase, TContext, TObjField>(aliased, mergeFields)
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
  where TContext : UsageContext
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(AstParentItemVerifier<TObject, TObjBase, TContext, TypeParameterAst>));

  protected override void UsageValue(TObject usage, TContext context)
  {
    base.UsageValue(usage, context);

    if (usage.Parent is not null) {
      context.CheckType(usage.Parent, " Parent", false);
    }

    foreach (TObjField field in usage.Fields) {
      UsageField(field, context);
    }

    ParentUsage<TObject> input = new([], usage, "an alternative");
    CheckingAlternates(input);
    foreach (AstAlternate<TObjBase> alternate in usage.Alternates) {
      UsageAlternate(alternate, context);
      if (alternate.Modifiers.Length == 0) {
        CheckAlternate(new([alternate.Type.FullName], usage, "an alternate"), usage.Name, context, true);
      }
    }

    foreach (TypeParameterAst typeParameter in usage.TypeParameters) {
      if (!context.Used.Contains("$" + typeParameter.Name)) {
        context.AddError(typeParameter, usage.Label, $"'${typeParameter.Name}' not used");
      }
    }
  }

  protected virtual void UsageAlternate(AstAlternate<TObjBase> alternate, TContext context)
    => context
      .CheckType(alternate.Type, " Alternate")
      .CheckModifiers(alternate);

  protected virtual void UsageField(TObjField field, TContext context)
    => context
      .CheckType(field.Type, " Field")
      .CheckModifiers(field);

  protected override string GetParent(AstType<TObjBase> usage)
    => usage.Parent?.FullName ?? "";

  protected override void CheckParentType(
    ParentUsage<TObject> input,
    TContext context,
    bool top,
    Action<TObject>? onParent = null)
  {
    if (input.Parent?.StartsWith('$') == true) {
      string parameter = input.Parent[1..];
      if (top && input.Usage.TypeParameters.All(p => p.Name != parameter)) {
        context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Parent}' not defined");
      }

      return;
    }

    base.CheckParentType(input, context, top, onParent);
  }

  protected override bool CheckAstParentType(ParentUsage<TObject> input, AstType astType)
    => base.CheckAstParentType(input, astType)
      || astType.Label == "Dual";

  protected override IEnumerable<TObjField> GetItems(TObject usage)
    => usage.Fields;

  protected override void OnParentType(ParentUsage<TObject> input, TContext context, TObject parentType, bool top)
  {
    if (top && parentType.Label != "Dual") {
      base.OnParentType(input, context, parentType, top);
    }

    CheckingAlternates(input, top, parentType.Name);
    input = input with { Label = "an alternate" };
    foreach (AstAlternate<TObjBase> alternate in parentType.Alternates) {
      if (alternate.Modifiers.Length == 0) {
        CheckAlternate(input.AddParent(alternate.Type.FullName), parentType.Name, context, false);
      }
    }
  }

  private void CheckAlternate(ParentUsage<TObject> input, string current, TContext context, bool top)
  {
    if (context.DifferentName(input, top ? null : current)
      && context.GetType(input.Parent, out AstDescribed? type)
      && type is TObject alternateType) {
      CheckParent(input, alternateType, context, false);

      CheckingAlternates(input, top, alternateType.Name, current);
      foreach (AstAlternate<TObjBase> alternate in alternateType.Alternates) {
        if (alternate.Modifiers.Length == 0) {
          CheckAlternate(input.AddParent(alternate.Type.FullName), alternateType.Name, context, false);
        }
      }
    }
  }

  [LoggerMessage(Level = LogLevel.Information, Message = "Checking Alternates with {Input}")]
  private partial void CheckingAlternates(ParentUsage<TObject> input);

  [LoggerMessage(Level = LogLevel.Information, Message = "Checking Alternates with {Input}, {Top} of {Alternate}")]
  private partial void CheckingAlternates(ParentUsage<TObject> input, bool top, string alternate);

  [LoggerMessage(Level = LogLevel.Information, Message = "Checking Alternates with {Input}, {Top} of {Alternate}, {Current}")]
  private partial void CheckingAlternates(ParentUsage<TObject> input, bool top, string alternate, string current);

  protected override void CheckMergeParent(ParentUsage<TObject> input, TContext context)
  {
    base.CheckMergeParent(input, context);

    AstAlternate<TObjBase>[] alternates = GetParentItems(input, input.Usage, context, ast => ast.Alternates).ToArray();
    if (alternates.Length > 0) {
      Token.ITokenMessages failures = mergeAlternates.CanMerge(alternates);
      if (failures.Any()) {
        context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} alternates into Parent {input.Parent} alternates");
        context.Add(failures);
      }
    }
  }
}

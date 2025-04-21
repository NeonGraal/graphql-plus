using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Verification.Schema;

internal abstract class AstObjectVerifier<TObject, TObjBase, TObjArg, TObjField, TObjAlt, TContext>(
  IVerifyAliased<TObject> aliased,
  IMerge<TObjField> mergeFields,
  IMerge<TObjAlt> mergeAlternates,
  ILoggerFactory logger
) : AstParentItemVerifier<TObject, IGqlpObjBase, TContext, TObjField>(aliased, mergeFields)
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField<TObjBase>
  where TObjAlt : IGqlpObjAlternate, IGqlpObjBase<TObjArg>
  where TObjBase : IGqlpObjBase<TObjArg>
  where TObjArg : IGqlpObjArg
where TContext : UsageContext
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(AstParentItemVerifier<TObject, IGqlpObjBase, TContext, IGqlpTypeParam>));

  protected override void UsageValue(TObject usage, TContext context)
  {
    base.UsageValue(usage, context);

    if (usage.ObjParent is not null) {
      context
        .CheckType(usage.ObjParent, " Parent", false)
        .CheckArgs(usage.ObjParent.BaseArgs, " Parent");
    }

    foreach (IGqlpTypeParam param in usage.TypeParams) {
      if (string.IsNullOrWhiteSpace(param.Constraint)) {
        continue;
      }

      if (!context.GetType(param.Constraint, out IGqlpDescribed? value)) {
        context.AddError(param, usage.Label + " Type Param", $"'{param.Constraint}' not defined");
      }
    }

    foreach (TObjField field in usage.ObjFields) {
      UsageField(field, context);
    }

    ParentUsage<TObject> input = new([], usage, "an alternative");
    _logger.CheckingAlternates(input);
    foreach (TObjAlt alternate in usage.ObjAlternates) {
      UsageAlternate(alternate, context);
      if (!alternate.Modifiers.Any()) {
        CheckAlternate(new([alternate.FullType], usage, "an alternate"), usage.Name, context, true);
      }
    }

    foreach (IGqlpTypeParam typeParam in usage.TypeParams) {
      bool paramUsed = context.Used.Contains("$" + typeParam.Name);
      context.AddError(typeParam, usage.Label, $"'${typeParam.Name}' not used", !paramUsed);
    }
  }

  protected virtual void UsageAlternate(TObjAlt alternate, TContext context)
    => context
      .CheckType(alternate, " Alternate")
      .CheckArgs(alternate.BaseArgs, " Alternate")
      .CheckModifiers(alternate);

  protected virtual void UsageField(TObjField field, TContext context)
    => context
      .CheckType(field.BaseType, " Field")
      .CheckArgs(field.BaseType.BaseArgs, " Field")
      .CheckModifiers(field);

  protected override string GetParent(IGqlpType<IGqlpObjBase> usage)
  {
    IGqlpObjBase? parent = usage.Parent;
    if (parent is null) {
      return "";
    }

    return (parent.IsTypeParam ? "$" : "") + parent.Name;
  }

  protected override void CheckParentType(
    ParentUsage<TObject> input,
    TContext context,
    bool top,
    Action<TObject>? onParent = null)
  {
    if (input.Parent?.StartsWith("$", StringComparison.Ordinal) == true) {
      string parameter = input.Parent[1..];
      bool addError = top && input.Usage.TypeParams.All(p => p.Name != parameter);
      context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Parent}' not defined", addError);

      return;
    }

    base.CheckParentType(input, context, top, onParent);
  }

  protected override bool CheckAstParentType(ParentUsage<TObject> input, IGqlpType astType)
    => base.CheckAstParentType(input, astType)
      || astType.Label == "Dual";

  protected override IEnumerable<TObjField> GetItems(TObject usage)
    => usage.ObjFields;

  protected override void OnParentType(ParentUsage<TObject> input, TContext context, TObject parentType, bool top)
  {
    if (top && parentType.Label != "Dual") {
      base.OnParentType(input, context, parentType, top);
    }

    _logger.CheckingAlternates(input, top, parentType.Name);
    input = input with { Label = "an alternate" };
    foreach (TObjAlt alternate in parentType.ObjAlternates) {
      if (!alternate.Modifiers.Any()) {
        CheckAlternate(input.AddParent(alternate.Name), parentType.Name, context, false);
      }
    }
  }

  private void CheckAlternate(ParentUsage<TObject> input, string current, TContext context, bool top)
  {
    if (context.DifferentName(input, top ? null : current)
      && context.GetType(input.Parent, out IGqlpDescribed? type)
      && type is TObject alternateType) {
      CheckParent(input, alternateType, context, false);

      _logger.CheckingAlternates(input, top, alternateType.Name, current);
      foreach (TObjAlt alternate in alternateType.ObjAlternates) {
        if (!alternate.Modifiers.Any()) {
          CheckAlternate(input.AddParent(alternate.Name), alternateType.Name, context, false);
        }
      }
    }
  }

  protected override void CheckMergeParent(ParentUsage<TObject> input, TContext context)
  {
    base.CheckMergeParent(input, context);

    TObjAlt[] alternates = [.. GetParentItems(input, input.Usage, context, ast => ast.ObjAlternates)];
    if (alternates.Length > 0) {
      ITokenMessages failures = mergeAlternates.CanMerge(alternates);
      if (failures.Any()) {
        context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} alternates into Parent {input.Parent} alternates");
        context.Add(failures);
      }
    }
  }
}

internal static partial class AstObjectVerifierLogging
{
  [LoggerMessage(Level = LogLevel.Information, Message = "Checking Alternates with {Input}")]
  internal static partial void CheckingAlternates(this ILogger logger, object input);

  [LoggerMessage(Level = LogLevel.Information, Message = "Checking Alternates with {Input}, {Top} of {Alternate}")]
  internal static partial void CheckingAlternates(this ILogger logger, object input, bool top, string alternate);

  [LoggerMessage(Level = LogLevel.Information, Message = "Checking Alternates with {Input}, {Top} of {Alternate}, {Current}")]
  internal static partial void CheckingAlternates(this ILogger logger, object input, bool top, string alternate, string current);
}

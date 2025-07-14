using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Todo")]
internal abstract class AstObjectVerifier<TObject, TObjBase, TObjArg, TObjField, TObjAlt, TContext>(
  ObjectVerifierParams<TObject, TObjField, TObjAlt, TObjArg> verifiers
) : AstParentItemVerifier<TObject, IGqlpObjBase, TContext, TObjField>(verifiers.Aliased, verifiers.MergeFields)
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField<TObjBase>
  where TObjAlt : IGqlpObjAlternate, IGqlpObjBase<TObjArg>
  where TObjBase : IGqlpObjBase<TObjArg>
  where TObjArg : IGqlpObjArg
  where TContext : EnumContext
{
  private readonly ILogger _logger = verifiers.Logger.CreateTypedLogger<AstParentItemVerifier<TObject, IGqlpObjBase, TContext, IGqlpTypeParam>>();

  private readonly Matcher<TObjArg>.L _constraintMatcher = verifiers.ConstraintMatcher;

  protected override void UsageValue(TObject usage, TContext context)
  {
    base.UsageValue(usage, context);

    if (usage.ObjParent is not null) {
      CheckTypeRef(context, usage.ObjParent, " Parent", false);
    }

    UsageTypeParams(usage.Label, usage.TypeParams, context);
    UsageFields(usage.ObjFields, context);
    UsageAlternates(usage, context);
    CheckParamsUsed(usage.Label, usage.TypeParams, context);
  }

  private static void UsageTypeParams(string label, IEnumerable<IGqlpTypeParam> typeParams, TContext context)
  {
    foreach (IGqlpTypeParam param in typeParams) {
      if (!context.GetType(param.Constraint, out IGqlpDescribed? value)) {
        context.AddError(param, label + " Type Param", $"Constraint '{param.Constraint}' not defined");
      }
    }
  }

  protected virtual void UsageFields(IEnumerable<TObjField> fields, TContext context)
  {
    foreach (TObjField field in fields) {
      CheckTypeRef(context, field.BaseType, " Field");
      context.CheckModifiers(field);
    }
  }

  private void UsageAlternates(TObject usage, TContext context)
  {
    ParentUsage<TObject> input = new([], usage, "an alternative");
    _logger.CheckingAlternates(input);
    foreach (TObjAlt alternate in usage.ObjAlternates) {
      CheckTypeRef(context, alternate, " Alternate");
      context.CheckModifiers(alternate);
      if (!alternate.Modifiers.Any()) {
        CheckAlternate(new([alternate.FullType], usage, "an alternate"), usage.Name, context, true);
      }
    }
  }

  private void CheckParamsUsed(string label, IEnumerable<IGqlpTypeParam> typeParams, TContext context)
  {
    foreach (IGqlpTypeParam typeParam in typeParams) {
      bool paramUsed = context.Used.Contains("$" + typeParam.Name);
      context.AddError(typeParam, label, $"'${typeParam.Name}' not used", !paramUsed);
    }
  }

  protected void CheckTypeRef<T>(TContext context, T reference, string suffix, bool check = true)
    where T : IGqlpObjType
  {
    string typeName = (reference.IsTypeParam ? "$" : "") + reference.Name;
    CheckTypeRef(AddCheckError, context, reference, check);

    void AddCheckError(string errPrefix, string errSuffix, bool check = true)
    {
      if (string.IsNullOrWhiteSpace(errSuffix)) {
        context.AddError(reference, reference.Label + suffix, $"{errPrefix}", check);
      } else {
        context.AddError(reference, reference.Label + suffix, $"{errPrefix} {typeName}. {errSuffix}", check);
      }
    }
  }

  protected TContext CheckTypeRef<T>(CheckError error, TContext context, T reference, bool check = true)
    where T : IGqlpObjType
  {
    string typeName = (reference.IsTypeParam ? "$" : "") + reference.Name;
    if (context.GetType(typeName, out IGqlpDescribed? refType)) {
      CheckTypeArgs(error, context, reference, check, refType);
    } else {
      error($"'{typeName}' not defined", "", check);

      if (reference is IGqlpObjBase baseType) {
        CheckArgsTypes(error, context, baseType);
      }
    }

    return context;
  }

  private void CheckArgsTypes(CheckError error, TContext context, IGqlpObjBase baseType)
  {
    foreach (IGqlpObjArg arg in baseType.Args) {
      CheckArgType(error, context, arg);
    }
  }

  internal virtual void CheckArgType(CheckError error, TContext context, IGqlpObjArg arg)
    => CheckTypeRef(error, context, arg);

  private void CheckParamsArgs(CheckError error, TContext context, IGqlpObject definition, TObjBase baseType)
  {
    IEnumerable<(TObjArg, IGqlpTypeParam)> argAndParams = baseType.BaseArgs
      .Zip(definition.TypeParams, static (a, p) => (a, p));
    foreach ((TObjArg arg, IGqlpTypeParam param) in argAndParams) {
      CheckArgType(error, context, arg);

      if (string.IsNullOrWhiteSpace(param.Constraint)) {
        error("Invalid Constraint on", "undefined");
        continue;
      }

      if (!_constraintMatcher.Matches(arg, param.Constraint!, context)) {
        error($"Invalid Constraint on ${param.Name} of", $"'{arg.Name}' not match '{param.Constraint}'");
      }
    }
  }

  internal void CheckTypeArgs<TBase>(CheckError error, TContext context, TBase type, bool check, IGqlpDescribed? value)
    where TBase : IGqlpObjType
  {
    int numArgs = type is IGqlpObjBase baseNum ? baseNum.Args.Count() : 0;
    if (value is IGqlpObject definition) {
      CheckTypeArgsDefLabels(error, type, check, definition);
      CheckTypeArgsDefBase(error, context, type, numArgs, definition, definition.TypeParams.Count());
    } else if (value is IGqlpSimple simple && numArgs != 0) {
      error("Args invalid on", $"Expected 0, given {numArgs}");
    }
  }

  private void CheckTypeArgsDefBase<TBase>(CheckError error, TContext context, TBase type, int numArgs, IGqlpObject definition, int numParams) where TBase : IGqlpObjType
  {
    if (type is TObjBase baseType) {
      if (numParams == numArgs) {
        CheckParamsArgs(error, context, definition, baseType);
      } else {
        error("Args mismatch on", $"Expected {numParams}, given {numArgs}");
        CheckArgsTypes(error, context, baseType);
      }
    } else if (numParams > 0) {
      error("Args mismatch on", $"Expected {numParams}, given 0");
    }
  }

  private static void CheckTypeArgsDefLabels<TBase>(CheckError error, TBase type, bool check, IGqlpObject definition) where TBase : IGqlpObjType
  {
    if (check && definition.Label != "Dual" && definition.Label != type.Label) {
      error("Type kind mismatch for", $"Found {definition.Label} '{definition.Name}'");
    }
  }

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
      bool addError = top && input.Usage.TypeParams.All(IsParameterMismatch);
      context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Parent}' not defined", addError);

      return;

      bool IsParameterMismatch(IGqlpTypeParam p)
        => p.Name != parameter;
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
      && context.GetTyped(input.Parent, out TObject? alternateType)) {
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
      IMessages failures = verifiers.MergeAlternates.CanMerge(alternates);
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

internal record class ObjectVerifierParams<TObject, TObjField, TObjAlt, TObjArg>(
  IVerifyAliased<TObject> Aliased,
  IMerge<TObjField> MergeFields,
  IMerge<TObjAlt> MergeAlternates,
  Matcher<TObjArg>.D ConstraintMatcher,
  ILoggerFactory Logger
)
  where TObject : IGqlpObject
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjArg : IGqlpObjArg
  ;

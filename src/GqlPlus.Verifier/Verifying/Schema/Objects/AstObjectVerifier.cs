using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Todo")]
internal abstract class AstObjectVerifier<TObject, TObjField>(
  ObjectVerifierParams<TObject, TObjField> verifiers
) : AstParentItemVerifier<TObject, IGqlpObjBase, EnumContext, TObjField>(verifiers.Aliased, verifiers.MergeFields)
  where TObject : IGqlpObject<TObjField>
  where TObjField : IGqlpObjField
{
  private readonly ILogger _logger = verifiers.Logger.CreateTypedLogger<AstParentItemVerifier<TObject, IGqlpObjBase, EnumContext, IGqlpTypeParam>>();

  private readonly Matcher<IGqlpObjArg>.L _constraintMatcher = verifiers.ConstraintMatcher;

  protected override void UsageValue(TObject usage, EnumContext context)
  {
    base.UsageValue(usage, context);

    if (usage.Parent is not null) {
      CheckTypeRef(context, usage.Parent, " Parent", false);
    }

    UsageTypeParams(usage.Label, usage.TypeParams, context);
    foreach (TObjField field in usage.ObjFields) {
      UsageField(field, usage, context);
    }

    UsageAlternates(usage, context);
    CheckParamsUsed(usage.Label, usage.TypeParams, context);
  }

  private static void UsageTypeParams(string label, IEnumerable<IGqlpTypeParam> typeParams, EnumContext context)
  {
    foreach (IGqlpTypeParam param in typeParams) {
      if (!context.GetType(param.Constraint, out IGqlpDescribed? value)) {
        context.AddError(param, label + " Type Param", $"Constraint '{param.Constraint}' not defined");
      }
    }
  }

  protected virtual void UsageField(TObjField field, TObject usage, EnumContext context)
  {
    if (string.IsNullOrWhiteSpace(field.EnumLabel)) {
      CheckTypeRef(context, field.Type, " Field");
      context.CheckModifiers(field);
      CheckForSelf(new([field.Type.FullType], usage, "a field"), usage.Name, context);
    } else {
      CheckFieldEnum(field, usage, context);
    }
  }

  private static void CheckFieldEnum(TObjField field, TObject usage, EnumContext context)
  {
    if (!string.IsNullOrWhiteSpace(field.EnumType?.Name)) {
      context.CheckEnumValue("Field", field);
      return;
    }

    if (context.GetEnumValue(field.EnumLabel!, out string? enumType)) {
      field.SetEnumType(enumType);
      return;
    }

    context.AddError(field, usage.Label + " Field Enum", $"Enum Label '{field.EnumLabel}' not defined");
  }

  private void UsageAlternates(TObject usage, EnumContext context)
  {
    SelfUsage<TObject> input = new([], usage, "an alternative");
    _logger.CheckingAlternates(input);
    foreach (IGqlpObjAlt alternate in usage.Alternates) {
      CheckTypeRef(context, alternate, " Alternate");
      context.CheckModifiers(alternate);
      CheckForSelf(new([alternate.FullType], usage, "an alternate"), usage.Name, context);
    }
  }

  private void CheckParamsUsed(string label, IEnumerable<IGqlpTypeParam> typeParams, EnumContext context)
  {
    foreach (IGqlpTypeParam typeParam in typeParams) {
      bool paramUsed = context.Used.Contains("$" + typeParam.Name);
      context.AddError(typeParam, label, $"'${typeParam.Name}' not used", !paramUsed);
    }
  }

  protected void CheckTypeRef(EnumContext context, IGqlpObjType reference, string label, bool check = true)
  {
    string typeName = (reference.IsTypeParam ? "$" : "") + reference.Name;
    CheckTypeRef(AddCheckError, context, reference, check);

    void AddCheckError(string errPrefix, string errSuffix, bool check = true)
    {
      if (string.IsNullOrWhiteSpace(errSuffix)) {
        context.AddError(reference, label, $"{errPrefix} {typeName}", check);
      } else {
        context.AddError(reference, label, $"{errPrefix} {typeName}. {errSuffix}", check);
      }
    }
  }

  protected EnumContext CheckTypeRef(CheckError error, EnumContext context, IGqlpObjType reference, bool check = true)
  {
    string typeName = (reference.IsTypeParam ? "$" : "") + reference.Name;
    if (context.GetType(typeName, out IGqlpDescribed? definition)) {
      CheckTypeArgs(error, context, reference, definition);
    } else {
      error($"'{typeName}' not defined", "", check);

      if (reference is IGqlpObjBase baseType) {
        CheckArgsTypes(error, context, baseType);
      }
    }

    return context;
  }

  private void CheckArgsTypes(CheckError error, EnumContext context, IGqlpObjBase reference)
  {
    foreach (IGqlpObjArg arg in reference.Args) {
      CheckArgEnum(context, arg);
      CheckTypeRef(error, context, arg);
    }
  }

  private void CheckArgEnum(EnumContext context, IGqlpObjArg arg)
  {
    if (string.IsNullOrWhiteSpace(arg.EnumLabel)
      && !context.GetType(arg.Name, out IGqlpDescribed? type)
      && context.GetEnumValue(arg.Name, out string? enumType)) {
      arg.SetEnumType(enumType);
    }

    if (!string.IsNullOrWhiteSpace(arg.EnumLabel)) {
      context.CheckEnumValue("Arg", arg);
    }
  }

  private void CheckParamsArgs(CheckError error, EnumContext context, IGqlpObject definition, IGqlpObjBase reference)
  {
    IEnumerable<(IGqlpObjArg, IGqlpTypeParam)> argAndParams = reference.Args
      .Zip(definition.TypeParams, static (a, p) => (a, p));
    foreach ((IGqlpObjArg arg, IGqlpTypeParam param) in argAndParams) {
      CheckArgEnum(context, arg);
      CheckTypeRef(error, context, arg);

      if (string.IsNullOrWhiteSpace(param.Constraint)) {
        error("Invalid Constraint on", "undefined");
        continue;
      }

      if (!_constraintMatcher.Matches(arg, param.Constraint!, context)) {
        error($"Invalid Constraint on ${param.Name} of", $"'{arg.Name}' not match '{param.Constraint}'");
      }
    }
  }

  internal void CheckTypeArgs(CheckError error, EnumContext context, IGqlpObjType reference, IGqlpDescribed? definition)
  {
    int numArgs = reference is IGqlpObjBase baseNum ? baseNum.Args.Count() : 0;
    if (definition is IGqlpObject objectDef) {
      CheckTypeArgsDefBase(error, context, reference, numArgs, objectDef, objectDef.TypeParams.Count());
    } else if (definition is IGqlpSimple simple && numArgs != 0) {
      error("Args mismatch on", $"Expected none, given {numArgs}");
    }
  }

  private void CheckTypeArgsDefBase(CheckError error, EnumContext context, IGqlpObjType reference, int numArgs, IGqlpObject definition, int numParams)
  {
    if (reference is IGqlpObjBase baseRef) {
      if (numParams == numArgs) {
        CheckParamsArgs(error, context, definition, baseRef);
      } else {
        error("Args mismatch on", $"Expected {numParams}, given {numArgs}");
        if (numArgs > 0) {
          CheckArgsTypes(error, context, baseRef);
        }
      }
    } else if (numParams > 0) {
      error("Args mismatch on", $"Expected {numParams}, given none");
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
    SelfUsage<TObject> input,
    EnumContext context,
    bool top,
    Action<TObject>? onParent = null)
  {
    if (input.Current?.StartsWith("$", StringComparison.Ordinal) == true) {
      string parameter = input.Current[1..];
      bool addError = top && input.Usage.TypeParams.All(IsParameterMismatch);
      context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Current}' not defined", addError);

      return;

      bool IsParameterMismatch(IGqlpTypeParam p)
        => p.Name != parameter;
    }

    base.CheckParentType(input, context, top, onParent);
  }

  protected override bool CheckAstParentType(SelfUsage<TObject> input, IGqlpType astType)
    => base.CheckAstParentType(input, astType)
      || astType.Label == "Dual";

  protected override IEnumerable<TObjField> GetItems(TObject usage)
    => usage.ObjFields;

  protected override void OnParentType(SelfUsage<TObject> input, EnumContext context, TObject parentType, bool top)
  {
    if (top && parentType.Label != "Dual") {
      base.OnParentType(input, context, parentType, top);
    }

    input = input with { Label = "a field" };
    foreach (TObjField field in parentType.ObjFields) {
      CheckForSelf(input.AddNext(field.Type.Name), parentType.Name, context);
    }

    input = input with { Label = "an alternate" };
    foreach (IGqlpObjAlt alternate in parentType.Alternates) {
      CheckForSelf(input.AddNext(alternate.Name), parentType.Name, context);
    }
  }

  private void CheckForSelf(SelfUsage<TObject> input, string current, EnumContext context)
  {
    if (context.DifferentName(input, current)
      && context.GetTyped(input.Current, out TObject? parentType)) {
      CheckParent(input, parentType, context, false);

      foreach (TObjField field in parentType.ObjFields) {
        CheckForSelf(input.AddNext(field.Type.Name), parentType.Name, context);
      }

      foreach (IGqlpObjAlt alternate in parentType.Alternates) {
        CheckForSelf(input.AddNext(alternate.Name), parentType.Name, context);
      }
    }
  }

  protected override void CheckMergeParent(SelfUsage<TObject> input, EnumContext context)
  {
    base.CheckMergeParent(input, context);

    IGqlpObjAlt[] alternates = [.. GetParentItems(input, input.Usage, context, ast => ast.Alternates)];
    if (alternates.Length > 0) {
      IMessages failures = verifiers.MergeAlternates.CanMerge(alternates);
      if (failures.Any()) {
        context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} alternates into Parent {input.Current} alternates");
        context.Add(failures);
      }
    }
  }

  protected override EnumContext MakeContext(TObject usage, IGqlpType[] aliased, IMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParams.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues());
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

internal record class ObjectVerifierParams<TObject, TObjField>(
  IVerifyAliased<TObject> Aliased,
  IMerge<TObjField> MergeFields,
  IMerge<IGqlpObjAlt> MergeAlternates,
  Matcher<IGqlpObjArg>.D ConstraintMatcher,
  ILoggerFactory Logger
)
  where TObject : IGqlpObject
  where TObjField : IGqlpObjField
  ;

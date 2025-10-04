using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Todo")]
internal abstract class AstObjectVerifier<TObject, TObjField>(
  TypeKind kind,
  ObjectVerifierParams<TObject, TObjField> verifiers
) : AstParentItemVerifier<TObject, IGqlpObjBase, ObjectContext, TObjField>(verifiers.Aliased, verifiers.MergeFields)
  where TObject : IGqlpObject<TObjField>
  where TObjField : IGqlpObjField
{
  private readonly Matcher<IGqlpObjTypeArg>.L _constraintMatcher = verifiers.ConstraintMatcher;

  protected override void UsageValue(TObject usage, ObjectContext context)
  {
    base.UsageValue(usage, context);

    if (usage.Parent is not null) {
      CheckTypeRef(context, usage.Parent, " Parent", context.ParentKinds, false);
    }

    UsageTypeParams(usage.Label, usage.TypeParams, context);
    foreach (TObjField field in usage.ObjFields) {
      UsageField(field, usage, context);
    }

    foreach (IGqlpObjAlt alternate in usage.Alternates) {
      UsageAlternate(alternate, usage, context);
    }

    CheckParamsUsed(usage.Label, usage.TypeParams, context);
  }

  private static void UsageTypeParams(string label, IEnumerable<IGqlpTypeParam> typeParams, ObjectContext context)
  {
    foreach (IGqlpTypeParam param in typeParams) {
      if (!context.GetType(param.Constraint, out IGqlpDescribed? value)) {
        context.AddError(param, label + " Type Param", $"Constraint '{param.Constraint}' not defined");
      }
    }
  }

  protected virtual void UsageField(TObjField field, TObject usage, ObjectContext context)
  {
    if (field.EnumValue is not null) {
      CheckObjEnum(usage.Label + " Field", field, context);
      return;
    }

    CheckTypeRef(context, field.Type, " Field");
    context.CheckModifiers(field);
    CheckForSelf(new([field.Type.FullType], usage, "a field"), usage.Name, context);
  }

  private void UsageAlternate(IGqlpObjAlt alternate, TObject usage, ObjectContext context)
  {
    if (alternate.EnumValue is not null) {
      CheckObjEnum(usage.Label + " Alternate", alternate, context);
      return;
    }

    CheckTypeRef(context, alternate, "Alternate");
    context.CheckModifiers(alternate);
    CheckForSelf(new([alternate.FullType], usage, "an alternate"), usage.Name, context);
  }

  private static void CheckObjEnum(string label, IGqlpObjectEnum objEnum, ObjectContext context)
  {
    if (objEnum.EnumValue is null) {
      return;
    }

    IGqlpEnumValue enumValue = objEnum.EnumValue;

    if (!string.IsNullOrWhiteSpace(enumValue.EnumType)) {
      context.CheckEnumValue(label, objEnum);
      return;
    }

    if (context.GetEnumValue(enumValue.EnumLabel, out string? enumType)) {
      objEnum.SetEnumType(enumType);
      return;
    }

    context.AddError(objEnum, label + " Enum", $"Enum Label '{enumValue.EnumLabel}' not defined");
  }

  private void CheckParamsUsed(string label, IEnumerable<IGqlpTypeParam> typeParams, ObjectContext context)
  {
    foreach (IGqlpTypeParam typeParam in typeParams) {
      bool paramUsed = context.Used.Contains("$" + typeParam.Name);
      context.AddError(typeParam, label, $"'${typeParam.Name}' not used", !paramUsed);
    }
  }

  protected void CheckTypeRef(ObjectContext context, IGqlpObjType reference, string label, HashSet<TypeKind>? validKinds = null, bool check = true)
  {
    string typeName = (reference.IsTypeParam ? "$" : "") + reference.Name;
    CheckTypeRef(AddCheckError, context, reference, validKinds, check);

    void AddCheckError(string errPrefix, string errSuffix, bool check = true)
    {
      if (string.IsNullOrWhiteSpace(errSuffix)) {
        context.AddError(reference, label, $"{errPrefix} {typeName}", check);
      } else {
        context.AddError(reference, label, $"{errPrefix} {typeName}. {errSuffix}", check);
      }
    }
  }

  protected ObjectContext CheckTypeRef(CheckError error, ObjectContext context, IGqlpObjType reference, HashSet<TypeKind>? validKinds = null, bool check = true)
  {
    string typeName = (reference.IsTypeParam ? "$" : "") + reference.Name;
    validKinds ??= context.FieldKinds;
    if (context.GetType(typeName, out IGqlpDescribed? definition)) {
      if (definition is IGqlpType typeDef && !validKinds.Contains(typeDef.Kind)) {
        error("Invalid Kind for", $"{typeDef.Kind} not one of {string.Join(",", validKinds)}", check);
      }

      CheckTypeArgs(error, context, reference, definition);
    } else {
      error($"'{typeName}' not defined", "", check);

      if (reference is IGqlpObjBase baseType) {
        CheckArgsTypes(error, context, baseType);
      }
    }

    return context;
  }

  private void CheckArgsTypes(CheckError error, ObjectContext context, IGqlpObjBase reference)
  {
    foreach (IGqlpObjTypeArg arg in reference.Args) {
      CheckArgEnum(context, arg);
      CheckTypeRef(error, context, arg);
    }
  }

  private void CheckArgEnum(ObjectContext context, IGqlpObjTypeArg arg)
  {
    if (arg.EnumValue is null) {
      return;
    }

    IGqlpEnumValue enumValue = arg.EnumValue;
    if (!context.GetType(enumValue.EnumType, out IGqlpDescribed? type)
      && context.GetEnumValue(enumValue.EnumLabel, out string? enumType)) {
      arg.SetEnumType(enumType);
    }

    context.CheckEnumValue("Arg", arg);
  }

  private void CheckParamsArgs(CheckError error, ObjectContext context, IGqlpObject definition, IGqlpObjBase reference)
  {
    IEnumerable<(IGqlpObjTypeArg, IGqlpTypeParam)> argAndParams = reference.Args
      .Zip(definition.TypeParams, static (a, p) => (a, p));
    foreach ((IGqlpObjTypeArg arg, IGqlpTypeParam param) in argAndParams) {
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

  internal void CheckTypeArgs(CheckError error, ObjectContext context, IGqlpObjType reference, IGqlpDescribed? definition)
  {
    int numArgs = reference is IGqlpObjBase baseNum ? baseNum.Args.Count() : 0;
    if (definition is IGqlpObject objectDef) {
      CheckTypeArgsDefBase(error, context, reference, numArgs, objectDef, objectDef.TypeParams.Count());
    } else if (definition is IGqlpSimple simple && numArgs != 0) {
      error("Args mismatch on", $"Expected none, given {numArgs}");
    }
  }

  private void CheckTypeArgsDefBase(CheckError error, ObjectContext context, IGqlpObjType reference, int numArgs, IGqlpObject definition, int numParams)
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
    ObjectContext context,
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
      || astType.Kind == TypeKind.Dual;

  protected override IEnumerable<TObjField> GetItems(TObject usage)
    => usage.ObjFields;

  protected override void OnParentType(SelfUsage<TObject> input, ObjectContext context, TObject parentType, bool top)
  {
    if (top && parentType.Kind != TypeKind.Dual) {
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

  private void CheckForSelf(SelfUsage<TObject> input, string current, ObjectContext context)
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

  protected override void CheckMergeParent(SelfUsage<TObject> input, ObjectContext context)
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

  protected override ObjectContext MakeContext(TObject usage, IGqlpType[] aliased, IMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParams.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues(), kind);
  }
}

internal record class ObjectVerifierParams<TObject, TObjField>(
  IVerifyAliased<TObject> Aliased,
  IMerge<TObjField> MergeFields,
  IMerge<IGqlpObjAlt> MergeAlternates,
  Matcher<IGqlpObjTypeArg>.D ConstraintMatcher,
  ILoggerFactory Logger
)
  where TObject : IGqlpObject
  where TObjField : IGqlpObjField
  ;

using System.Diagnostics.CodeAnalysis;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Todo")]
internal class AstObjectVerifier<TObjField>(
  IVerifierRepository verifiers,
  TypeKind fieldKind
) : AstParentItemVerifier<IAstObject<TObjField>, IAstObjBase, ObjectContext, TObjField>(verifiers)
  where TObjField : IAstObjField
{
  private readonly Matcher<IAstTypeArg>.L _constraintMatcher = verifiers.MatcherFor<IAstTypeArg>();
  private readonly IMerge<IAstAlternate> _mergeAlternates = verifiers.MergerFor<IAstAlternate>();

  protected override void UsageValue(IAstObject<TObjField> usage, ObjectContext context)
  {
    UsageTypeParams(usage.Label, usage.TypeParams, context);

    base.UsageValue(usage, context);

    if (usage.Parent is not null) {
      CheckTypeRef(context, usage.Parent, "Parent of " + usage.Name, context.ParentKinds, false);
    }

    foreach (TObjField field in usage.ObjFields) {
      UsageField(field, usage, context);
    }

    foreach (IAstAlternate alternate in usage.Alternates) {
      UsageAlternate(alternate, usage, context);
    }

    CheckParamsUsed(usage.Label, usage.TypeParams, context);
  }

  private static void UsageTypeParams(string label, IEnumerable<IAstTypeParam> typeParams, ObjectContext context)
  {
    foreach (IAstTypeParam param in typeParams) {
      if (!context.GetType(param.Constraint, out IAstDescribed? value)) {
        context.AddError(param, label + " Type Param", $"Constraint '{param.Constraint}' not defined");
      }
    }
  }

  protected virtual void UsageField(TObjField field, IAstObject<TObjField> usage, ObjectContext context)
  {
    if (field.EnumValue is not null) {
      CheckObjEnum(usage.Label + " Field", field, context);
      return;
    }

    CheckTypeRef(context, field.Type, "Field of " + usage.Name);
    context.CheckModifiers(field);
    CheckForSelf(new(field.Type.FullType, usage, "a field"), usage.Name, context);
  }

  private void UsageAlternate(IAstAlternate alternate, IAstObject<TObjField> usage, ObjectContext context)
  {
    if (alternate.EnumValue is not null) {
      CheckObjEnum(usage.Label + " Alternate", alternate, context);
      return;
    }

    CheckTypeRef(context, alternate, "Alternate of " + usage.Name);
    context.CheckModifiers(alternate);
    CheckForSelf(new(alternate.FullType, usage, "an alternate"), usage.Name, context);
  }

  private static void CheckObjEnum(string label, IAstObjEnum objEnum, ObjectContext context)
  {
    if (objEnum.EnumValue is null) {
      return;
    }

    IAstEnumValue enumValue = objEnum.EnumValue;

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

  private void CheckParamsUsed(string label, IEnumerable<IAstTypeParam> typeParams, ObjectContext context)
  {
    foreach (IAstTypeParam typeParam in typeParams) {
      bool paramUsed = context.Used.Contains("$" + typeParam.Name);
      context.AddError(typeParam, label, $"'${typeParam.Name}' not used", !paramUsed);
    }
  }

  protected void CheckTypeRef(
    ObjectContext context,
    IAstObjType reference,
    string label,
    HashSet<TypeKind>? validKinds = null,
    bool check = true)
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

  protected ObjectContext CheckTypeRef(
    CheckError error,
    ObjectContext context,
    IAstObjType reference,
    HashSet<TypeKind>? validKinds = null,
    bool check = true)
  {
    string typeName = (reference.IsTypeParam ? "$" : "") + reference.Name;
    validKinds ??= context.FieldKinds;
    if (context.GetType(typeName, out IAstDescribed? definition)) {
      CheckTypeDefinition(error, context, reference, validKinds, check, definition);
    } else {
      error("Invalid reference on ", $"'{typeName}' not defined", check);

      if (reference is IAstObjBase baseType) {
        CheckArgsTypes(error, context, baseType);
      }
    }

    return context;
  }

  private void CheckTypeDefinition(
    CheckError error,
    ObjectContext context,
    IAstObjType reference,
    HashSet<TypeKind> validKinds,
    bool check,
    IAstDescribed? definition)
  {
    if (definition is IAstTypeParam typeParam) {
      if (!context.GetType(typeParam.Constraint, out definition)) {
        error($"Invalid Constraint for {typeParam.Name} on", $"'{typeParam.Constraint}' not defined", check);
      }
    } else {
      CheckTypeArgs(error, context, reference, definition);
    }

    if (definition is IAstTypeSpecial specialType) {
      error("Invalid Kind for", $"{specialType.Name} not one of [{string.Join(",", validKinds)}]", !specialType.MatchesKindSpecial(validKinds));
    } else if (definition is IAstType typeDef) {
      error("Invalid Kind for", $"{typeDef.Kind}({typeDef.Name}) not one of [{string.Join(",", validKinds)}]", !validKinds.Contains(typeDef.Kind));
    }
  }

  private void CheckArgsTypes(CheckError error, ObjectContext context, IAstObjBase reference)
  {
    foreach (IAstTypeArg arg in reference.Args) {
      CheckArgEnum(context, arg);
      CheckTypeRef(error, context, arg);
    }
  }

  private void CheckArgEnum(ObjectContext context, IAstTypeArg arg)
  {
    if (arg.EnumValue is null) {
      return;
    }

    IAstEnumValue enumValue = arg.EnumValue;
    if (!context.GetType(enumValue.EnumType, out IAstDescribed? type)
      && context.GetEnumValue(enumValue.EnumLabel, out string? enumType)) {
      arg.SetEnumType(enumType);
    }

    context.CheckEnumValue("Arg", arg);
  }

  private void CheckParamsArgs(
    CheckError error,
    ObjectContext context,
    IAstObject definition,
    IAstObjBase reference
  )
  {
    IEnumerable<(IAstTypeArg, IAstTypeParam)> argAndParams = reference.Args
      .Zip(definition.TypeParams, static (a, p) => (a, p));
    foreach ((IAstTypeArg arg, IAstTypeParam param) in argAndParams) {
      CheckArgEnum(context, arg);
      CheckTypeRef(error, context, arg);

      if (string.IsNullOrWhiteSpace(param.Constraint)) {
        error("Invalid Constraint on", "undefined");
        continue;
      }

      if (!_constraintMatcher.Matches(arg, param.Constraint!, context)) {
        error($"Invalid Constraint on ${param.Name} of", $"'{arg.TypeName}' not match '{param.Constraint}'");
      }
    }
  }

  internal void CheckTypeArgs(
    CheckError error,
    ObjectContext context,
    IAstObjType reference,
    IAstDescribed? definition)
  {
    int numArgs = reference is IAstObjBase baseNum ? baseNum.Args.Count() : 0;
    if (definition is IAstObject objectDef) {
      CheckTypeArgsDefBase(error, context, reference, numArgs, objectDef, objectDef.TypeParams.Count());
    } else if (definition is IAstSimple simple) {
      error("Args mismatch on", $"Expected none, given {numArgs}", numArgs != 0);
    }
  }

  private void CheckTypeArgsDefBase(
    CheckError error,
    ObjectContext context,
    IAstObjType reference,
    int numArgs,
    IAstObject definition,
    int numParams)
  {
    if (reference is IAstObjBase baseRef) {
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

  protected override string GetParent(IAstType<IAstObjBase> usage)
  {
    IAstObjBase? parent = usage.Parent;
    if (parent is null) {
      return "";
    }

    return (parent.IsTypeParam ? "$" : "") + parent.Name;
  }

  protected override void CheckParentType(
    SelfUsage<IAstObject<TObjField>> input,
    ObjectContext context,
    bool top,
    Action<IAstObject<TObjField>>? onParent = null)
  {
    if (input.Current?.StartsWith("$", StringComparison.Ordinal) == true) {
      string parameter = input.Current[1..];
      bool addError = top && input.Usage.TypeParams.All(IsParameterMismatch);
      context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Current}' not defined", addError);

      return;

      bool IsParameterMismatch(IAstTypeParam p)
        => p.Name != parameter;
    }

    base.CheckParentType(input, context, top, onParent);
  }

  protected override bool CheckAstParentType(SelfUsage<IAstObject<TObjField>> input, IAstType astType)
    => true; // Allow any type as parent, checks are done in CheckTypeRef

  protected override IEnumerable<TObjField> GetItems(IAstObject<TObjField> usage)
    => usage.ObjFields;

  protected override void OnParentType(
    SelfUsage<IAstObject<TObjField>> input,
    ObjectContext context,
    IAstObject<TObjField> parentType,
    bool top)
  {
    if (top && parentType.Kind != TypeKind.Dual) {
      base.OnParentType(input, context, parentType, top);
    }

    input = input with { Label = "a field" };
    foreach (TObjField field in parentType.ObjFields) {
      CheckForSelf(input.AddNext(field.Type.Name), parentType.Name, context);
    }

    input = input with { Label = "an alternate" };
    foreach (IAstAlternate alternate in parentType.Alternates) {
      CheckForSelf(input.AddNext(alternate.Name), parentType.Name, context);
    }
  }

  private void CheckForSelf(SelfUsage<IAstObject<TObjField>> input, string current, ObjectContext context)
  {
    if (context.DifferentName(input, current)
      && context.GetTyped(input.Current, out IAstObject<TObjField>? parentType)) {
      CheckParent(input, parentType, context, false);

      foreach (TObjField field in parentType.ObjFields) {
        CheckForSelf(input.AddNext(field.Type.Name), parentType.Name, context);
      }

      foreach (IAstAlternate alternate in parentType.Alternates) {
        CheckForSelf(input.AddNext(alternate.Name), parentType.Name, context);
      }
    }
  }

  protected override void CheckMergeParent(SelfUsage<IAstObject<TObjField>> input, ObjectContext context)
  {
    base.CheckMergeParent(input, context);

    IAstAlternate[] alternates = [.. GetParentItems(input, input.Usage, context, ast => ast.Alternates)];
    if (alternates.Length > 0) {
      IMessages failures = _mergeAlternates.CanMerge(alternates);
      if (failures.Any()) {
        context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} alternates into Parent {input.Current} alternates");
        context.Add(failures);
      }
    }
  }

  protected override ObjectContext MakeContext(IAstObject<TObjField> usage, IAstType[] aliased, IMessages errors)
  {
    Map<IAstDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IAstDescribed)p.First()))
      .Concat(usage.TypeParams.Select(p => (Id: "$" + p.Name, Type: (IAstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues(), fieldKind);
  }
}

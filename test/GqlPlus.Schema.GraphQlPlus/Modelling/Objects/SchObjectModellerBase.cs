using System.Collections.Generic;
using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal abstract class SchObjectModellerBase<TAstField, TSchField>(
  IModeller<IAstModifier, ISch_Modifiers> modifierModeller
) : ModellerBase<IAstObject<TAstField>, ISch_Type>
  where TAstField : class, IAstObjField
  where TSchField : class
{
  private readonly IModeller<IAstModifier, ISch_Modifiers> _modifierModeller = modifierModeller;

  protected abstract Sch_TypeKind TypeKind { get; }

  protected sealed override ISch_Type ToModel(IAstObject<TAstField> ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<ISch_ObjTypeParam> typeParams = [.. ast.TypeParams.Select(item => MakeTypeParam(item, typeKinds))];
    ICollection<TSchField> fields = [.. ast.ObjFields.Select(item => MakeField(item, typeKinds))];
    ICollection<ISch_ObjAlternate> alternates = [.. ast.Alternates.Select(item => MakeAlternate(item, typeKinds))];
    ICollection<ISch_ObjectFor<TSchField>> allFields = [.. fields.Select(item => MakeObjectFor(ast.Name, item))];
    ICollection<ISch_ObjectFor<ISch_ObjAlternate>> allAlternates = [.. alternates.Select(item => MakeObjectFor(ast.Name, item))];

    Sch_TypeObject<Sch_TypeKind, TSchField> typeObject = new() {
      As__TypeObject = new Sch_TypeObjectObject<Sch_TypeKind, TSchField>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        TypeKind,
        ast.Parent is null ? SchModellerHelpers.EmptyObjBase() : MakeObjBase(ast.Parent, typeKinds),
        typeParams,
        fields,
        alternates,
        allFields,
        allAlternates),
    };

    return Wrap(typeObject);
  }

  protected abstract TSchField MakeField(TAstField ast, IMap<GqlpTypeKind> typeKinds);

  protected abstract ISch_Type Wrap(ISch_TypeObject<Sch_TypeKind, TSchField> typeObject);

  protected ISch_ObjBase MakeObjBase(IAstObjBase ast, IMap<GqlpTypeKind> typeKinds)
  {
    ICollection<ISch_ObjTypeArg> typeArgs = [.. ast.Args.Select(item => MakeTypeArg(item, typeKinds))];

    Sch_ObjBase result = new() {
      As__ObjBase = new Sch_ObjBaseObject(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        typeArgs),
    };

    if (ast.IsTypeParam) {
      result.As_TypeParam = SchModellerHelpers.MakeTypeParam(ast.Name, ast.Description);
    }

    return result;
  }

  protected ISch_ObjFieldType MakeObjFieldType(IAstObjFieldType ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_ObjFieldType result = new() {
      As__ObjFieldType = new Sch_ObjFieldTypeObject(
        SchModellerHelpers.Desc(ast.Type.Description),
        SchModellerHelpers.MakeName(ast.Type.Name),
        [.. ast.Type.Args.Select(item => MakeTypeArg(item, typeKinds))],
        [.. _modifierModeller.ToModels(ast.Modifiers, typeKinds)]),
    };

    if (ast.Type.IsTypeParam) {
      result.As_TypeParam = SchModellerHelpers.MakeTypeParam(ast.Type.Name, ast.Type.Description);
    }

    if (ast.EnumValue is not null) {
      result.As_ObjFieldEnum = MakeObjFieldEnum(ast);
    }

    return result;
  }

  protected ISch_InputFieldType MakeInputFieldType(IAstInputFieldType ast, IMap<GqlpTypeKind> typeKinds)
  {
    string description = FieldDescription(ast);
    Sch_InputFieldTypeObject inputFieldType = new(
      SchModellerHelpers.Desc(description),
      SchModellerHelpers.MakeName(ast.Type.Name),
      [.. ast.Type.Args.Select(item => MakeTypeArg(item, typeKinds))],
      [.. _modifierModeller.ToModels(ast.Modifiers, typeKinds)]) {
      DefaultValue = ast.DefaultValue is null ? null : new GqlpValue(),
    };

    Sch_InputFieldType result = new() {
      As__InputFieldType = inputFieldType,
    };

    if (ast.Type.IsTypeParam) {
      result.As_TypeParam = SchModellerHelpers.MakeTypeParam(ast.Type.Name, description);
    }

    if (ast.EnumValue is not null) {
      result.As_ObjFieldEnum = MakeObjFieldEnum(ast);
    }

    return result;
  }

  protected ISch_OutputFieldType MakeOutputFieldType(IAstOutputField ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_OutputFieldTypeObject outputFieldType = new(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Type.Name),
      [.. ast.Type.Args.Select(item => MakeTypeArg(item, typeKinds))],
      [.. _modifierModeller.ToModels(ast.Modifiers, typeKinds)]) {
      Parameter = ast.Parameter is null ? null : MakeInputFieldType(ast.Parameter, typeKinds),
    };

    Sch_OutputFieldType result = new() {
      As__OutputFieldType = outputFieldType,
    };

    if (ast.Type.IsTypeParam) {
      result.As_TypeParam = SchModellerHelpers.MakeTypeParam(ast.Type.Name, ast.Description);
    }

    if (ast.EnumValue is not null) {
      result.As_ObjFieldEnum = MakeObjFieldEnum(ast);
    }

    return result;
  }

  protected ISch_ObjAlternate MakeAlternate(IAstAlternate ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_ObjAlternate result = new() {
      As__ObjAlternate = new Sch_ObjAlternateObject(
        MakeObjBase(ast, typeKinds),
        [.. ast.Modifiers
          .Select(item => _modifierModeller.ToModel(item, typeKinds).As_Collections)
          .Where(item => item is not null)
          .Cast<ISch_Collections>()]),
    };

    if (ast.EnumValue is not null) {
      result.As_ObjAlternateEnum = MakeAlternateEnum(ast);
    }

    return result;
  }

  protected ISch_ObjTypeParam MakeTypeParam(IAstTypeParam ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_ObjTypeParam result = new();
    result.As__ObjTypeParam = new Sch_ObjTypeParamObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeTypeRef(ast.Constraint, GqlpTypeKind.Basic, typeKinds));
    return result;
  }

  protected ISch_ObjTypeArg MakeTypeArg(IAstTypeArg ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_ObjTypeArgObject typeArg = new(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.GqlpToSchTypeKind(SchModellerHelpers.LookupKind(ast.Name, typeKinds))) {
      Label = ast.EnumValue is null ? null : SchModellerHelpers.MakeName(ast.EnumValue.EnumLabel),
    };

    Sch_ObjTypeArg result = new() {
      As__ObjTypeArg = typeArg,
      As__TypeRef = typeArg,
    };

    if (ast.IsTypeParam) {
      result.As_TypeParam = SchModellerHelpers.MakeTypeParam(ast.Name, ast.Description);
    }

    return result;
  }

  private static Sch_ObjFieldEnum MakeObjFieldEnum(IAstObjFieldType ast)
  {
    Sch_ObjFieldEnum result = new();
    result.As__ObjFieldEnum = new Sch_ObjFieldEnumObject(
      SchModellerHelpers.Desc(FieldDescription(ast)),
      SchModellerHelpers.MakeName(ast.Type.Name),
      SchModellerHelpers.MakeName(ast.EnumValue?.EnumLabel ?? ast.Type.Name));
    return result;
  }

  private static Sch_ObjAlternateEnum MakeAlternateEnum(IAstAlternate ast)
  {
    Sch_ObjAlternateEnum result = new();
    result.As__ObjAlternateEnum = new Sch_ObjAlternateEnumObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeName(ast.EnumValue?.EnumLabel ?? ast.Name));
    return result;
  }

  private static Sch_ObjectFor<TModel> MakeObjectFor<TModel>(string objectName, TModel item)
    where TModel : class
    => new() {
      As_Parent = item,
      As__ObjectFor = new Sch_ObjectForObject<TModel>(SchModellerHelpers.MakeName(objectName)),
    };

  private static string FieldDescription(IAstObjFieldType ast)
    => ast is IAstDescribed described ? described.Description : ast.Type.Description;
}

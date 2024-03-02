using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class TypeObjectModel<TBase, TField>(TypeKindModel Kind, string Name)
  : ChildTypeModel<DescribedModel<TBase>>(Kind, Name)
  where TBase : ITypeBaseModel
  where TField : ModelBase
{
  internal DescribedModel<NamedModel>[] TypeParameters { get; set; } = [];
  internal TField[] Fields { get; set; } = [];
  internal AlternateModel<TBase>[] Alternates { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("parameters", TypeParameters.Render())
      .Add("fields", Fields.Render())
      .Add("alternates", Alternates.Render());
}

internal record class RefModel<TBase>
  : ModelBase
  where TBase : ITypeBaseModel
{
  internal TypeRefModel<SimpleKindModel>? TypeRef { get; private init; }

  internal TBase? BaseRef { get; private init; }

  public RefModel(TypeRefModel<SimpleKindModel> typeRef)
    => TypeRef = typeRef;
  public RefModel(TBase baseRef)
    => BaseRef = baseRef;

  internal override RenderStructure Render()
    => TypeRef is not null ? TypeRef.Render()
      : BaseRef is not null ? BaseRef.Render()
      : new("");
}

internal record class TypeBaseModel<TArg>
  : ModelBase, ITypeBaseModel
{
  internal TArg[] Arguments { get; set; } = [];
  internal string? TypeParameter { get; set; }
}

internal interface ITypeBaseModel : IRendering
{ }

internal record class AlternateModel<TBase>(RefModel<TBase> Type)
  : ModelBase
  where TBase : ITypeBaseModel
{
  internal ModifierModel[] Collections { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("type", Type.Render())
      .Add("collections", Collections.Render());
}

internal record class FieldModel<TBase>(string Name, RefModel<TBase> Type)
  : AliasedModel(Name)
  where TBase : ITypeBaseModel
{
  internal ModifierModel[] Modifiers { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("type", Type.Render());
}

internal record class ParameterModel
// Todo: (RefModel<InputBaseModel> Type)
  : IRendering
{
  public ModifierModel[] Collections { get; set; } = [];
  public ConstantModel? Default { get; set; }

  public RenderStructure Render()
    => RenderStructure.New("_Parameter")
      // .Add("type", Type.Render())
      .Add("collections", Collections.Render(true))
      .Add("description", RenderValue.Str(""))
      .Add("default", Default?.Render())
      ;
}

internal abstract class ModellerObject<TAst, TRefAst, TFieldAst, TModel, TBase, TField>(
  IModeller<AstAlternate<TRefAst>> alternate,
  IModeller<ModifierAst> modifier,
  IModeller<TRefAst> reference
) : ModellerType<TAst, TRefAst, TModel>
  where TAst : AstType<TRefAst>
  where TRefAst : AstReference<TRefAst>
  where TFieldAst : AstField<TRefAst>
  where TModel : IRendering
  where TBase : ITypeBaseModel
  where TField : IRendering
{
  internal DescribedModel<TBase>? ParentModel(TRefAst? parent)
    => parent is null ? null : new DescribedModel<TBase>(BaseModel(parent));

  internal AlternateModel<TBase>[] AlternatesModels(AstAlternate<TRefAst>[] alternates)
    => alternate.ToModels<AlternateModel<TBase>>(alternates);

  internal TField[] FieldsModels(TFieldAst[] fields)
    => [.. fields.Select(FieldModel)];

  internal ModifierModel[] ModifiersModels(ModifierAst[] modifiers)
    => modifier.ToModels<ModifierModel>(modifiers);

  protected TBase BaseModel(TRefAst ast)
    => reference.ToModel<TBase>(ast);

  protected abstract TField FieldModel(TFieldAst field);
}

internal class AlternateModeller<TRefAst, TBase>(
  IModeller<TRefAst> refBase,
  IModeller<ModifierAst> modifier
) : ModellerBase<AstAlternate<TRefAst>, AlternateModel<TBase>>
  where TRefAst : AstReference<TRefAst>
  where TBase : ITypeBaseModel
{
  internal override AlternateModel<TBase> ToModel(AstAlternate<TRefAst> ast)
    => new(new(BaseModel(ast.Type))) { Collections = ModifiersModels(ast.Modifiers) };

  private TBase BaseModel(TRefAst ast)
    => refBase.ToModel<TBase>(ast) ?? throw new ModelTypeException<TBase>(ast);

  internal ModifierModel[] ModifiersModels(ModifierAst[] modifiers)
    => [.. modifiers.Select(modifier.ToModel<ModifierModel>).Where(m => m is not null)];
}

internal class ParameterModeller(
  IModeller<ConstantAst> constant,
  IModeller<ModifierAst> modifier
) : ModellerBase<ParameterAst, ParameterModel>
{
  internal override ParameterModel ToModel(ParameterAst ast)
    => new() {
      // Type = parameter.Type.ToModel(),
      Collections = [.. ast.Modifiers.Select(modifier.ToModel<ModifierModel>)],
      Default = constant.ToModel<ConstantModel>(ast.Default),
    };
}

using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal enum ScalarKindModel { Boolean, Enum, Number, String, Union }

internal record class ScalarRefModel(
  string Name,
  ScalarDomain Scalar
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Scalar, Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("scalar", Scalar);
}

internal sealed record class BaseScalarModel<TItem>(
  ScalarKindModel Scalar,
  string Name
) : ParentTypeModel<TItem, ScalarItemModel<TItem>>(TypeKindModel.Scalar, Name)
  where TItem : IBaseScalarItemModel
{
  protected override string Tag => $"_Scalar{Scalar}";

  protected override Func<TItem, ScalarItemModel<TItem>> NewItem(string parent)
    => item => new(item, parent);

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("scalar", Scalar.RenderEnum());
}

internal record class BaseScalarItemModel(
  bool Exclude
) : ModelBase, IBaseScalarItemModel
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("exclude", Exclude);
}

internal interface IBaseScalarItemModel : IRendering { }

internal record class ScalarMemberModel(
  EnumValueModel EnumValue,
  bool Exclude
) : BaseScalarItemModel(Exclude)
{
  public ScalarMemberModel(string name, string value, bool exclude)
    : this(new(name, value), exclude)
  { }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add(EnumValue, context);
}

internal record class ScalarTrueFalseModel(
  bool Value,
  bool Exclude
) : BaseScalarItemModel(Exclude)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("value", Value);
}

internal record class ScalarRangeModel(
  decimal? From,
  decimal? To,
  bool Exclude
) : BaseScalarItemModel(Exclude)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("from", From)
      .Add("to", To);
}

internal record class ScalarRegexModel(
  string Regex,
  bool Exclude
) : BaseScalarItemModel(Exclude)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("regex", Regex);
}

internal record class ScalarItemModel<TItem>(
  TItem Item,
  string Scalar
) : ModelBase
  where TItem : IBaseScalarItemModel
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add(Item, context)
      .Add("scalar", Scalar);
}

internal abstract class ModellerScalar<TItemAst, TItemModel>
  : ModellerType<AstScalar<TItemAst>, string, BaseScalarModel<TItemModel>>
  where TItemAst : IAstScalarItem
  where TItemModel : IBaseScalarItemModel
{
  protected ModellerScalar()
    : base(TypeKindModel.Scalar)
  { }

  internal TItemModel[] ToItems(AstScalar<TItemAst> ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Items.Select(ast => ToItem(ast, typeKinds))];

  internal ScalarItemModel<TItemModel>[] ToAllItems(AstScalar<TItemAst> ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Items.Select(item => new ScalarItemModel<TItemModel>(ToItem(item, typeKinds), ast.Name))];

  protected abstract TItemModel ToItem(TItemAst ast, IMap<TypeKindModel> typeKinds);
}

internal class ScalarBooleanModeller
  : ModellerScalar<ScalarTrueFalseAst, ScalarTrueFalseModel>
{
  internal override BaseScalarModel<ScalarTrueFalseModel> ToModel(AstScalar<ScalarTrueFalseAst> ast, IMap<TypeKindModel> typeKinds)
    => new(ScalarKindModel.Boolean, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast, typeKinds),
    };

  protected override ScalarTrueFalseModel ToItem(ScalarTrueFalseAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Value, ast.Excludes);
}

internal class ScalarEnumModeller
  : ModellerScalar<ScalarMemberAst, ScalarMemberModel>
{
  internal override BaseScalarModel<ScalarMemberModel> ToModel(AstScalar<ScalarMemberAst> ast, IMap<TypeKindModel> typeKinds)
    => new(ScalarKindModel.Enum, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast, typeKinds),
    };

  protected override ScalarMemberModel ToItem(ScalarMemberAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.EnumType ?? "", ast.Member, ast.Excludes);
}

internal class ScalarNumberModeller
  : ModellerScalar<ScalarRangeAst, ScalarRangeModel>
{
  internal override BaseScalarModel<ScalarRangeModel> ToModel(AstScalar<ScalarRangeAst> ast, IMap<TypeKindModel> typeKinds)
    => new(ScalarKindModel.Number, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast, typeKinds),
    };

  protected override ScalarRangeModel ToItem(ScalarRangeAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Lower, ast.Upper, ast.Excludes);
}

internal class ScalarStringModeller
  : ModellerScalar<ScalarRegexAst, ScalarRegexModel>
{
  internal override BaseScalarModel<ScalarRegexModel> ToModel(AstScalar<ScalarRegexAst> ast, IMap<TypeKindModel> typeKinds)
    => new(ScalarKindModel.String, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast, typeKinds),
    };

  protected override ScalarRegexModel ToItem(ScalarRegexAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Regex, ast.Excludes);
}

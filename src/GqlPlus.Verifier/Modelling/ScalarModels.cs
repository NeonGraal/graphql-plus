using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal enum ScalarKindModel { Boolean, Enum, Number, String, Union }

internal record class ScalarRefModel(string Name, ScalarKind Scalar)
  : TypeRefModel<SimpleKindModel>(SimpleKindModel.Scalar, Name)
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("scalar", Scalar);
}

internal sealed record class BaseScalarModel<TItem>(
  ScalarKindModel Scalar,
  string Name
) : ChildTypeModel<TypeRefModel<SimpleKindModel>>(TypeKindModel.Scalar, Name)
  where TItem : IBaseScalarItemModel
{
  public TItem[] Items { get; set; } = [];
  public ScalarItemModel<TItem>[] AllItems { get; set; } = [];

  protected override string Tag => $"_Scalar{Scalar}";

  internal override RenderStructure Render()
    => base.Render()
      .Add("allItems", AllItems.Render())
      .Add("items", Items.Render())
      .Add("scalar", Scalar.RenderEnum());
}

internal record class BaseScalarItemModel(bool Exclude)
  : ModelBase, IBaseScalarItemModel
{
  internal override RenderStructure Render()
    => base.Render()
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

  internal override RenderStructure Render()
    => base.Render()
      .Add(EnumValue);
}

internal record class ScalarTrueFalseModel(bool Exclude)
  : BaseScalarItemModel(Exclude)
{
  public bool Value { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("value", Value);
}

internal record class ScalarRangeModel(bool Exclude)
  : BaseScalarItemModel(Exclude)
{
  public decimal? From { get; set; }
  public decimal? To { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("from", From)
      .Add("to", To);
}

internal record class ScalarRegexModel(string Regex, bool Exclude)
  : BaseScalarItemModel(Exclude)
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("regex", Regex);
}

internal record class ScalarItemModel<TItem>(TItem Item, string Scalar)
  : ModelBase
  where TItem : IBaseScalarItemModel
{
  internal override RenderStructure Render()
    => base.Render()
      .Add(Item)
      .Add("scalar", Scalar);
}

internal abstract class ModellerScalar<TItemAst, TItemModel>
  : ModellerType<AstScalar<TItemAst>, string, BaseScalarModel<TItemModel>>
  where TItemAst : IAstScalarItem
  where TItemModel : IBaseScalarItemModel
{
  internal TItemModel[] ToItems(AstScalar<TItemAst> ast)
    => [.. ast.Items.Select(ToItem)];

  internal ScalarItemModel<TItemModel>[] ToAllItems(AstScalar<TItemAst> ast)
    => [.. ast.Items.Select(item => new ScalarItemModel<TItemModel>(ToItem(item), ast.Name))];

  protected abstract TItemModel ToItem(TItemAst ast);
}

internal class ScalarBooleanModeller
  : ModellerScalar<ScalarTrueFalseAst, ScalarTrueFalseModel>
{
  internal override BaseScalarModel<ScalarTrueFalseModel> ToModel(AstScalar<ScalarTrueFalseAst> ast)
    => new(ScalarKindModel.Boolean, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast),
      AllItems = ToAllItems(ast),
    };

  protected override ScalarTrueFalseModel ToItem(ScalarTrueFalseAst ast)
    => new(ast.Excludes) { Value = ast.Value, };
}

internal class ScalarEnumModeller
  : ModellerScalar<ScalarMemberAst, ScalarMemberModel>
{
  internal override BaseScalarModel<ScalarMemberModel> ToModel(AstScalar<ScalarMemberAst> ast)
    => new(ScalarKindModel.Enum, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast),
      AllItems = ToAllItems(ast),
    };

  protected override ScalarMemberModel ToItem(ScalarMemberAst ast)
    => new(ast.EnumType ?? "", ast.Member, ast.Excludes);
}

internal class ScalarNumberModeller
  : ModellerScalar<ScalarRangeAst, ScalarRangeModel>
{
  internal override BaseScalarModel<ScalarRangeModel> ToModel(AstScalar<ScalarRangeAst> ast)
    => new(ScalarKindModel.Number, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast),
      AllItems = ToAllItems(ast),
    };

  protected override ScalarRangeModel ToItem(ScalarRangeAst ast)
    => new(ast.Excludes) { From = ast.Lower, To = ast.Upper };
}

internal class ScalarStringModeller
  : ModellerScalar<ScalarRegexAst, ScalarRegexModel>
{
  internal override BaseScalarModel<ScalarRegexModel> ToModel(AstScalar<ScalarRegexAst> ast)
    => new(ScalarKindModel.String, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast),
      AllItems = ToAllItems(ast),
    };

  protected override ScalarRegexModel ToItem(ScalarRegexAst ast)
    => new(ast.Regex, ast.Excludes);
}

internal class ScalarUnionModeller
  : ModellerScalar<ScalarReferenceAst, TypeSimpleModel>
{
  internal override BaseScalarModel<TypeSimpleModel> ToModel(AstScalar<ScalarReferenceAst> ast)
    => new(ScalarKindModel.Union, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast),
      AllItems = ToAllItems(ast),
    };

  // Todo: Determine whether Name is Basic, Scalar or Enum
  protected override TypeSimpleModel ToItem(ScalarReferenceAst ast)
    => new(SimpleKindModel.Basic, ast.Name);
}

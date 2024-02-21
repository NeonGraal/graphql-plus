﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed record class ModelBaseScalar<TItem>(
  ScalarKindModel Scalar,
  string Name
) : ModelChildType<TypeRefModel<SimpleKindModel>>(TypeKindModel.Scalar, Name)
  where TItem : ModelBase
{
  public ModelScalarItem<TItem>[] Items { get; set; } = [];

  protected override string Tag => $"_Scalar{Scalar}";

  internal override RenderStructure Render()
    => base.Render()
      .Add("items", new("", Items.Render()))
      .Add("scalar", Scalar.RenderEnum());
}

internal record class ScalarMemberModel(
  string Name,
  string Value,
  bool Exclude
) : EnumValueModel(Name, Value)
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("exclude", new("", Exclude));
}

internal record class ScalarTrueFalseModel(bool Exclude)
  : ModelBase
{
  public bool Value { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("value", new("", Value))
      .Add("exclude", new("", Exclude));
}

internal record class ScalarRangeModel(bool Exclude)
  : ModelBase
{
  public decimal? From { get; set; }
  public decimal? To { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("from", new("", From))
      .Add("to", new("", To))
      .Add("exclude", new("", Exclude));
}

internal record class ScalarRegexModel(string Regex, bool Exclude)
  : ModelBase
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("regex", new("", Regex))
      .Add("exclude", new("", Exclude));
}

internal abstract class ModellerScalar<TItemAst, TItemModel>
  : ModellerBase<AstScalar<TItemAst>, ModelBaseScalar<TItemModel>>
  where TItemAst : IAstScalarItem
  where TItemModel : ModelBase
{
  internal ModelScalarItem<TItemModel>[] ToItems(AstScalar<TItemAst> ast)
    => [.. ast.Items.Select(item => new ModelScalarItem<TItemModel>(ToItem(item), ast.Name))];

  protected abstract TItemModel ToItem(TItemAst ast);
}

internal class ScalarBooleanModeller
  : ModellerScalar<ScalarTrueFalseAst, ScalarTrueFalseModel>
{
  internal override ModelBaseScalar<ScalarTrueFalseModel> ToModel(AstScalar<ScalarTrueFalseAst> ast)
    => new(ScalarKindModel.Boolean, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast),
    };

  protected override ScalarTrueFalseModel ToItem(ScalarTrueFalseAst ast)
    => new(ast.Excludes) { Value = ast.Value, };
}

internal class ScalarEnumModeller
  : ModellerScalar<ScalarMemberAst, ScalarMemberModel>
{
  internal override ModelBaseScalar<ScalarMemberModel> ToModel(AstScalar<ScalarMemberAst> ast)
    => new(ScalarKindModel.Enum, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast),
    };

  protected override ScalarMemberModel ToItem(ScalarMemberAst ast)
    => new(ast.EnumType ?? "", ast.Member, ast.Excludes);
}

internal class ScalarNumberModeller
  : ModellerScalar<ScalarRangeAst, ScalarRangeModel>
{
  internal override ModelBaseScalar<ScalarRangeModel> ToModel(AstScalar<ScalarRangeAst> ast)
    => new(ScalarKindModel.Number, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast),
    };

  protected override ScalarRangeModel ToItem(ScalarRangeAst ast)
    => new(ast.Excludes) { From = ast.Lower, To = ast.Upper };
}

internal class ScalarStringModeller
  : ModellerScalar<ScalarRegexAst, ScalarRegexModel>
{
  internal override ModelBaseScalar<ScalarRegexModel> ToModel(AstScalar<ScalarRegexAst> ast)
    => new(ScalarKindModel.String, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
      Items = ToItems(ast),
    };

  protected override ScalarRegexModel ToItem(ScalarRegexAst ast)
    => new(ast.Regex, ast.Excludes);
}

internal enum ScalarKindModel { Boolean, Enum, Number, String, Union }

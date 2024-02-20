using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract record class ModelBaseScalar<TItem>(
  ScalarKindModel Scalar,
  string Name
) : ModelChildType<TypeRefModel<SimpleKindModel>>(TypeKindModel.Scalar, Name)
  where TItem : ModelBase
{
  public TItem[] Items { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("items", new("", Items.Render()))
      .Add("scalar", Scalar.RenderEnum());
}

internal record class ScalarNumberModel(string Name)
  : ModelBaseScalar<ScalarRangeModel>(ScalarKindModel.Number, Name)
{ }

internal record class ScalarTrueFalseModel(bool Exclude)
  : ModelBase
{
  public bool Value { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("value", new("", Value))
      .Add("exclude", new("", Exclude));
}

internal record class ScalarBooleanModel(string Name)
  : ModelBaseScalar<ScalarTrueFalseModel>(ScalarKindModel.Boolean, Name)
{ }

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

internal record class ScalarStringModel(string Name)
  : ModelBaseScalar<ScalarRegexModel>(ScalarKindModel.String, Name)
{ }

internal record class ScalarRegexModel(string Regex, bool Exclude)
  : ModelBase
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("regex", new("", Regex))
      .Add("exclude", new("", Exclude));
}

internal class ScalarBooleanModeller
  : ModellerBase<AstScalar<ScalarTrueFalseAst>, ScalarBooleanModel>
{
  internal override ScalarBooleanModel ToModel(AstScalar<ScalarTrueFalseAst> ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
    };
}

internal class ScalarNumberModeller
  : ModellerBase<AstScalar<ScalarRangeAst>, ScalarNumberModel>
{
  internal override ScalarNumberModel ToModel(AstScalar<ScalarRangeAst> ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
    };
}

internal class ScalarStringModeller
  : ModellerBase<AstScalar<ScalarRegexAst>, ScalarStringModel>
{
  internal override ScalarStringModel ToModel(AstScalar<ScalarRegexAst> ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
    };
}

internal enum ScalarKindModel { Boolean, Enum, Number, String, Union }

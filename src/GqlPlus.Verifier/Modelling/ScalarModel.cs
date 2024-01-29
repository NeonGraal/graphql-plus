using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract record class ModelBaseScalar(ScalarKindModel Scalar, string Name)
  : ModelBaseType(TypeKindModel.Scalar, Name)
{
  public TypeRefModel<SimpleKindModel>? Parent { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("parent", Parent?.Render())
      .Add("scalar", Scalar.RenderEnum());
}

internal record class ScalarNumberModel(string Name)
  : ModelBaseScalar(ScalarKindModel.Number, Name)
{
  public ScalarRangeModel[] Ranges { get; set; } = [];
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

internal record class ScalarStringModel(string Name)
  : ModelBaseScalar(ScalarKindModel.String, Name)
{
  public ScalarRegexModel[] Regexes { get; set; } = [];
}

internal record class ScalarRegexModel(string Regex, bool Exclude)
  : ModelBase
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("regex", new("", Regex))
      .Add("exclude", new("", Exclude));
}

internal class ScalarNumberModeller
  : ModellerBase<AstScalar<ScalarRangeAst>, ModelBaseScalar>
{
  internal override ModelBaseScalar ToModel(AstScalar<ScalarRangeAst> ast)
    => new ScalarNumberModel(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
    };
}

internal class ScalarStringModeller
  : ModellerBase<AstScalar<ScalarRegexAst>, ModelBaseScalar>
{
  internal override ModelBaseScalar ToModel(AstScalar<ScalarRegexAst> ast)
    => new ScalarStringModel(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Scalar),
    };
}

internal enum ScalarKindModel { Number, String, Union }

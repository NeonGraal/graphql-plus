using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract record class ModelBaseScalar(ScalarKindModel Scalar, string Name)
  : ModelBaseType(TypeKindModel.Scalar, Name)
{
  public TypeRefModel<SimpleKindModel>? Extends { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("extends", Extends?.Render())
      .Add("scalar", Scalar.RenderEnum());
}

internal record class ScalarNumberModel(string Name)
  : ModelBaseScalar(ScalarKindModel.Number, Name)
{
  public ScalarRangeModel[] Ranges { get; set; } = [];
}

internal record class ScalarRangeModel(bool FromInclusive, bool ToInclusive)
  : ModelBase
{
  public decimal? From { get; set; }
  public decimal? To { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("from", new("", From))
      .Add("fromInclusive", new("", FromInclusive))
      .Add("to", new("", To))
      .Add("toInclusive", new("", ToInclusive));
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

internal class ScalarModeller
  : ModellerBase<ScalarDeclAst, ModelBaseScalar>
{
  internal override ModelBaseScalar ToModel(ScalarDeclAst ast)
    => new ScalarNumberModel(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}

internal enum ScalarKindModel { Number, String, Union }

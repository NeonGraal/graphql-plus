using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class DirectivesModel
  : ModelBase
{
  public DirectiveModel? Directive { get; init; }
  public BaseTypeModel? Type { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => Type is null
      ? Directive is null
        ? new("")
        : Directive.Render(context)
      : Directive is null
        ? Type.Render(context)
        : base.Render(context)
          .Add("directive", Directive.Render(context))
          .Add("type", Type.Render(context));
}

public record class DirectiveModel(
  string Name
) : AliasedModel(Name)
{
  public ParameterModel[] Parameters { get; set; } = [];
  public bool Repeatable { get; set; }
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .AddSet("locations", Locations, "_Location")
      .Add("parameters", Parameters.Render(context))
      .Add("repeatable", Repeatable);
}

internal class DirectiveModeller(
  IModeller<ParameterAst, ParameterModel> parameter
) : ModellerBase<DirectiveDeclAst, DirectiveModel>
{
  protected override DirectiveModel ToModel(DirectiveDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Repeatable = ast.Option == DirectiveOption.Repeatable,
      Locations = ast.Locations,
      Parameters = parameter.ToModels(ast.Parameters, typeKinds),
    };

  internal static DirectiveLocation Combine(DirectiveLocation[] values)
    => values.Aggregate((a, b) => a | b);
}

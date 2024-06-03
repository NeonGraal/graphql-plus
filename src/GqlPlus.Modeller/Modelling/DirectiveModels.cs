﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

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
  public InputParameterModel[] Parameters { get; set; } = [];
  public bool Repeatable { get; set; }
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .AddSet("locations", Locations, "_Location")
      .Add("parameters", Parameters.Render(context))
      .Add("repeatable", Repeatable);
}

internal class DirectiveModeller(
  IModeller<InputParameterAst, InputParameterModel> parameter
) : ModellerBase<IGqlpSchemaDirective, DirectiveModel>
{
  protected override DirectiveModel ToModel(IGqlpSchemaDirective ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Repeatable = ast.DirectiveOption == DirectiveOption.Repeatable,
      Locations = ast.Locations,
      Parameters = parameter.ToModels(ast.Parameters.ArrayOf<InputParameterAst>(), typeKinds),
    };

  internal static DirectiveLocation Combine(DirectiveLocation[] values)
    => values.Aggregate((a, b) => a | b);
}

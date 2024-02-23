using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class OutputModel(string Name)
  : ChildTypeModel<TypeRefModel<TypeKindModel>>(TypeKindModel.Output, Name)
{
  internal override RenderStructure Render()
    => base.Render();
}

internal class OutputModeller
  : ModellerType<OutputDeclAst, OutputReferenceAst, OutputModel>
{
  internal override OutputModel ToModel(OutputDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}

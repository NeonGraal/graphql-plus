using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class InputModel(string Name)
  : ChildTypeModel<TypeRefModel<TypeKindModel>>(TypeKindModel.Input, Name)
{
  internal override RenderStructure Render()
    => base.Render();
}

internal class InputModeller
  : ModellerType<InputDeclAst, InputReferenceAst, InputModel>
{
  internal override InputModel ToModel(InputDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}

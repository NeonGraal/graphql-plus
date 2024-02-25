using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class InputModel(string Name)
  : TypeObjectModel<InputBaseModel, InputFieldModel>(TypeKindModel.Input, Name)
{
  internal override RenderStructure Render()
    => base.Render();
}

internal class InputModeller
  : ModellerObjectType<InputDeclAst, InputReferenceAst, InputModel, InputBaseModel>
{
  protected override InputBaseModel BaseModel(InputReferenceAst reference)
    => new(reference.Name);

  internal override InputModel ToModel(InputDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent),
    };
}

internal record class InputBaseModel(string Input)
  : TypeBaseModel<RefModel<InputBaseModel>>
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("input", Input);
}

internal record class InputFieldModel(string Name, RefModel<InputBaseModel> Type)
  : FieldModel<InputBaseModel>(Name, Type)
{
  internal ConstantModel? Default { get; set; }
}

using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class OutputModel(string Name)
  : TypeObjectModel<OutputBaseModel, OutputFieldModel>(TypeKindModel.Output, Name)
{
  internal override RenderStructure Render()
    => base.Render();
}

internal class OutputModeller
  : ModellerObjectType<OutputDeclAst, OutputReferenceAst, OutputModel, OutputBaseModel>
{
  protected override OutputBaseModel BaseModel(OutputReferenceAst reference)
    => new(reference.Name);

  internal override OutputModel ToModel(OutputDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent),
    };
}

internal record class OutputBaseModel(string Output)
  : TypeBaseModel<RefModel<OutputArgumentModel>>
{
  internal override RenderStructure Render()
    => base.Render()
    .Add("output", Output);
}

internal record class OutputFieldModel(string Name, RefModel<OutputBaseModel> Type)
  : FieldModel<OutputBaseModel>(Name, Type)
{
  internal ParameterModel[] Parameters { get; set; } = [];
  internal OutputEnumModel? Enum { get; set; }
}

internal record class OutputArgumentModel(string Name)
  : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name), ITypeBaseModel
{
  internal string? EnumValue { get; set; }
  internal RefModel<OutputBaseModel>? Ref { get; set; }
}

internal record class OutputEnumModel(string Name, string Field, string Value)
  : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{ }

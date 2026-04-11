using GqlPlus.Ast.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class DualFieldBuilder
  : ObjFieldBuilder<IAstDualField>
{
  public DualFieldBuilder(string name, string type)
    : base(name, type)
    => Add<IAstDualField>();

  public IAstDualField AsDualField
    => Build<IAstDualField>();

  public override IAstDualField AsObjField
    => AsDualField;
}

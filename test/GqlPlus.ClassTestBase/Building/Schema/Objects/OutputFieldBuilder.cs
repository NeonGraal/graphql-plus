using GqlPlus.Ast.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class OutputFieldBuilder
  : ObjFieldBuilder<IAstOutputField>
{
  internal IAstInputParam? _inputParam;

  public OutputFieldBuilder(string name, string type)
    : base(name, type)
    => Add<IAstOutputField>();

  protected new T Build<T>()
    where T : class, IAstOutputField
  {
    T result = base.Build<T>();

    result.Parameter.Returns(_inputParam);

    return result;
  }

  public IAstOutputField AsOutputField
    => Build<IAstOutputField>();

  public override IAstOutputField AsObjField => AsOutputField;
}

public static class OutputFieldBuilderHelper
{
  public static T WithParam<T>(this T builder, IAstInputParam? inputParam)
    where T : OutputFieldBuilder
    => builder.FluentAction(b => b._inputParam = inputParam);
}

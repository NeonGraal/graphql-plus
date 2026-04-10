using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema;

public class TypeParamBuilder
  : NamedBuilder
{
  internal string _constraint;

  public TypeParamBuilder(string name, string constraint)
    : base(name)
  {
    Add<IAstTypeParam>();
    _constraint = constraint;
  }

  protected new T Build<T>()
    where T : class, IAstTypeParam
  {
    T result = base.Build<T>();
    result.Constraint.Returns(_constraint);
    return result;
  }

  public IAstTypeParam AsTypeParam
    => Build<IAstTypeParam>();
}

using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema;

public class TypeParamBuilder
  : NamedBuilder
{
  internal string _constraint;

  public TypeParamBuilder(string name, string constraint)
    : base(name)
  {
    Add<IGqlpTypeParam>();
    _constraint = constraint;
  }

  protected new T Build<T>()
    where T : class, IGqlpTypeParam
  {
    T result = base.Build<T>();
    result.Constraint.Returns(_constraint);
    return result;
  }

  public IGqlpTypeParam AsTypeParam
    => Build<IGqlpTypeParam>();
}

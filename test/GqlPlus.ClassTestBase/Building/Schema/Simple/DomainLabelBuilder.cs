using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class DomainLabelBuilder
  : DomainItemBuilder
{
  internal string _enumType;
  internal string _enumLabel;

  public DomainLabelBuilder(string enumType, string enumLabel)
  {
    Add<IAstDomainLabel>();
    _enumType = enumType;
    _enumLabel = enumLabel;
  }

  protected new T Build<T>()
    where T : class, IAstDomainLabel
  {
    T result = base.Build<T>();
    result.EnumType.Returns(_enumType);
    result.EnumItem.Returns(_enumLabel);
    result.WhenForAnyArgs(a => a.SetEnumType(""))
      .Do(c => result.EnumType.Returns(c.Arg<string>()));
    return result;
  }

  public IAstDomainLabel AsLabel
    => Build<IAstDomainLabel>();
}

public static class DomainLabelBuilderHelper
{
  public static TBuild WithType<TBuild>(this TBuild builder, string enumType)
    where TBuild : DomainLabelBuilder
    => builder.FluentAction(b => b._enumType = enumType);
  public static TBuild WithLabel<TBuild>(this TBuild builder, string enumLabel)
    where TBuild : DomainLabelBuilder
    => builder.FluentAction(b => b._enumLabel = enumLabel);
}

using System.Diagnostics.CodeAnalysis;

namespace GqlPlus;

[SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Tests")]
public class SubstituteBase
{
  public static IMockBuilder A { get; } = Substitute.For<IMockBuilder>();
}

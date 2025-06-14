using System.Diagnostics.CodeAnalysis;
using NSubstitute.Core;

namespace GqlPlus;

[SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Tests")]
public class SubstituteBase
{
  public static IMockBuilder A { get; } = Substitute.For<IMockBuilder>();

  protected static Func<CallInfo, bool> OutValue<T>(T? value, int first = 0)
    => c => {
      c[first] = value;
      return true;
    };

}

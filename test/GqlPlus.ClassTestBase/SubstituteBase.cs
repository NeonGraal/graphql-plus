using NSubstitute;

namespace GqlPlus;

public class SubstituteBase
{
  protected static TResult For<TResult>()
    where TResult : class
    => Substitute.For<TResult>();
}

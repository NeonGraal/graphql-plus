namespace GqlPlus.Matching;

public class MatchTestsBase
  : VerifierTestsBase
{
  protected Map<IAstDescribed> Types { get; } = [];
  protected Map<string> EnumValues { get; } = [];
  protected EnumContext Context { get; }

  protected IMatcherRepository MatcherRepo { get; }

  public MatchTestsBase()
  {
    Context = new(Types, Errors, EnumValues);
    MatcherRepo = Substitute.For<IMatcherRepository>();
    MatcherRepo.LoggerFactory.Returns(LoggerFactory);
  }

  protected static MatcherOne<T>.D MatcherFor<T>(out IMatcher<T> matcher)
  {
    matcher = A.Of<IMatcher<T>>();

    MatcherOne<T>.D result = A.Of<MatcherOne<T>.D>();
    result().Returns(matcher);

    return result;
  }

  protected void MatcherForReturns<T>(MatcherOne<T>.D result)
    where T : IAstError
    => MatcherRepo.MatcherFor<T>().ReturnsForAnyArgs(result);
}

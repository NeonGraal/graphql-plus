using GqlPlus.Ast.Schema;

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

  protected static Matcher<T>.D MatcherFor<T>(out Matcher<T>.I matcher)
  {
    matcher = A.Of<Matcher<T>.I>();

    Matcher<T>.D result = A.Of<Matcher<T>.D>();
    result().Returns(matcher);

    return result;
  }
}

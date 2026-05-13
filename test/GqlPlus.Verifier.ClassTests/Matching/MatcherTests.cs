using GqlPlus.Matching;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

public class MatcherTests
  : SubstituteBase
{
  private readonly EnumContext _context = new(new Map<IAstDescribed>(), Messages.Empty, new Map<string>());

  [Theory, RepeatData]
  public void Matches_WhenCalled_DelegatesToValue(string constraint)
  {
    IMatcher<IAstType> inner = A.Of<IMatcher<IAstType>>();
    IAstType type = A.Named<IAstType>(constraint);
    inner.Matches(type, constraint, _context).Returns(true);

    Matcher<IAstType> matcher = new(() => inner);

    bool result = matcher.Matches(type, constraint, _context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void ImplicitConvert_FromDelegate_ReturnsMatcher(string constraint)
  {
    IMatcher<IAstType> inner = A.Of<IMatcher<IAstType>>();
    IAstType type = A.Named<IAstType>(constraint);
    inner.Matches(type, constraint, _context).Returns(true);

    Matcher<IAstType>.D factory = () => inner;
    Matcher<IAstType> result = factory;

    result.Matches(type, constraint, _context).ShouldBeTrue();
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    Matcher<IAstType>.D? factory = null;

    Action result = () => _ = (Matcher<IAstType>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}

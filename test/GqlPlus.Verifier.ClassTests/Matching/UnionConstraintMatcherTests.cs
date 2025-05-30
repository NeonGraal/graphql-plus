namespace GqlPlus.Matching;
public class UnionConstraintMatcherTests
  : MatcherTestsBase
{
  private readonly UnionConstraintMatcher _sut;
  private readonly Matcher<IGqlpType>.I _anyType;

  public UnionConstraintMatcherTests()
  {
    Matcher<IGqlpType>.D anyType = MatcherFor(out _anyType);

    _sut = new(anyType);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingUnionMember(string name, string constraint)
  {
    IGqlpUnion union = NFor<IGqlpUnion>(constraint);
    IGqlpUnionMember member = NFor<IGqlpUnionMember>(name);
    union.Items.Returns([member]);
    Types[constraint] = union;

    IGqlpType type = NFor<IGqlpType>(name);

    bool result = _sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingUnionMemberParent(string constraint, string name, string parent)
  {
    IGqlpUnion union = NFor<IGqlpUnion>(constraint);
    IGqlpUnionMember member = NFor<IGqlpUnionMember>(name);
    union.Items.Returns([member]);
    Types[constraint] = union;

    IGqlpType type = NFor<IGqlpType>(parent);
    _anyType.Matches(type, name, Context).Returns(true);

    bool result = _sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }
}

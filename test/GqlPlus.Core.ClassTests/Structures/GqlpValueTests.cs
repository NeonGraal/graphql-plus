namespace GqlPlus;

public class GqlpValueTests
{
  [Fact]
  public void GqlpScalar_EqualValues_AreEqualAndHaveMatchingHashes()
  {
    GqlpScalar first = new("name", "Tag", isIdentifier: true);
    GqlpScalar second = new("name", "Tag", isIdentifier: true);

    first.ShouldBe(second);
    first.GetHashCode().ShouldBe(second.GetHashCode());
    first.ShouldNotBe(new GqlpScalar("name", "Tag"));
  }

  [Fact]
  public void GqlpList_EqualValues_AreEqualAndPreserveFlow()
  {
    GqlpList first = new([new GqlpScalar(1m), new GqlpScalar("value")], "List", flow: true);
    GqlpList second = new([new GqlpScalar(1m), new GqlpScalar("value")], "List", flow: true);

    first.ShouldBe(second);
    first.Flow.ShouldBeTrue();
    first.Items.Count.ShouldBe(2);
  }

  [Fact]
  public void GqlpMap_DifferentScalarKeys_AreDistinct()
  {
    GqlpMap map = new([
      new KeyValuePair<IGqlpScalar, IGqlpValue>(new GqlpScalar("1"), new GqlpScalar(true)),
      new KeyValuePair<IGqlpScalar, IGqlpValue>(new GqlpScalar(1m), new GqlpScalar(false)),
    ]);

    map.Entries.Count.ShouldBe(2);
    map.Entries[new GqlpScalar("1")].ShouldBe(new GqlpScalar(true));
    map.Entries[new GqlpScalar(1m)].ShouldBe(new GqlpScalar(false));
  }

  [Fact]
  public void SpecialValues_DifferentTypes_AreDistinct()
  {
    new GqlpNull().Equals(new GqlpVoid()).ShouldBeFalse();
    new GqlpUnit().Equals(new GqlpNull()).ShouldBeFalse();
  }
}

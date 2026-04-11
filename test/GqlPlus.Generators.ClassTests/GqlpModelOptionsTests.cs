namespace GqlPlus;

public class GqlpModelOptionsTests
{
  [Theory, RepeatData]
  public void Equals_SameProperties_ReturnsTrue(string baseNamespace, string typePrefix)
  {
    GqlpModelOptions a = new(baseNamespace, typePrefix);
    GqlpModelOptions b = new(baseNamespace, typePrefix);

    a.Equals(b).ShouldBeTrue();
    a.Equals((object)b).ShouldBeTrue();
    b.Equals(a).ShouldBeTrue();
    a.GetHashCode().ShouldBe(b.GetHashCode());
  }

  [Theory, RepeatData]
  public void Equals_DifferentBaseNamespace_ReturnsFalse(string baseNamespace, string typePrefix)
  {
    GqlpModelOptions a = new(baseNamespace, typePrefix);
    GqlpModelOptions b = new(baseNamespace + "_diff", typePrefix);

    a.Equals(b).ShouldBeFalse();
    a.Equals((object)b).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Equals_DifferentTypePrefix_ReturnsFalse(string baseNamespace, string typePrefix)
  {
    GqlpModelOptions a = new(baseNamespace, typePrefix);
    GqlpModelOptions b = new(baseNamespace, typePrefix + "_diff");

    a.Equals(b).ShouldBeFalse();
    a.Equals((object)b).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Equals_Null_ReturnsFalse(string baseNamespace, string typePrefix)
  {
    GqlpModelOptions a = new(baseNamespace, typePrefix);
    GqlpModelOptions? b = null;

#pragma warning disable CA1508 // Avoid dead conditional code
#pragma warning disable CS8604 // Possible null reference argument.
    a.Equals(b).ShouldBeFalse();
    a.Equals((object?)b).ShouldBeFalse();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CA1508 // Avoid dead conditional code
  }

  [Theory, RepeatData]
  public void GetHashCode_ConsistentForSameInstance(string baseNamespace, string typePrefix)
  {
    GqlpModelOptions a = new(baseNamespace, typePrefix);

    int h1 = a.GetHashCode();
    int h2 = a.GetHashCode();

    h1.ShouldBe(h2);
  }
}

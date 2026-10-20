namespace GqlPlus.Structures;

public class GqlpValueWrapperTests
{
  [Fact]
  public void RoundTrip_Boolean()
    => RoundTrip(new Structured(new StructureValue(true, "Tag")))
      .ShouldBe(new GqlpScalar(true, "Tag"));

  [Fact]
  public void RoundTrip_Number()
    => RoundTrip(new Structured(new StructureValue(1.5m)))
      .ShouldBe(new GqlpScalar(1.5m));

  [Fact]
  public void RoundTrip_Identifier()
    => RoundTrip(new Structured(new StructureValue("abc")))
      .ShouldBe(new GqlpScalar("abc", isIdentifier: true));

  [Fact]
  public void RoundTrip_Text()
    => RoundTrip(new Structured(new StructureValue("not an id!")))
      .ShouldBe(new GqlpScalar("not an id!"));

  [Fact]
  public void RoundTrip_List()
    => RoundTrip(new Structured([new Structured(new StructureValue(1m)), new Structured(new StructureValue(2m))], "L", true))
      .ShouldBe(new GqlpList([new GqlpScalar(1m), new GqlpScalar(2m)], "L", true));

  [Fact]
  public void RoundTrip_Map()
  {
    Structured structured = new(new Dictionary<StructureValue, Structured> {
      [new("a")] = new(new StructureValue(true)),
      [new("b")] = new([new Structured(new StructureValue("x"))]),
    }, "M");

    RoundTrip(structured)
      .ShouldBe(new GqlpMap([
        new("a", new GqlpScalar(true)),
        new("b", new GqlpList([new GqlpScalar("x", isIdentifier: true)])),
      ], "M"));
  }

  [Fact]
  public void EmptyStructured_MapsByTag()
  {
    Structured.Empty().ToGqlpValue().ShouldBeOfType<GqlpUnit>();
    Structured.Empty("Null").ToGqlpValue().ShouldBeOfType<GqlpNull>();
    Structured.Empty("Void").ToGqlpValue().ShouldBeOfType<GqlpVoid>();
  }

  [Fact]
  public void SpecialValues_ToStructured_AreEmptyWithTag()
  {
    new GqlpNull().ToStructured().ShouldBe(Structured.Empty("Null"));
    new GqlpUnit().ToStructured().ShouldBe(Structured.Empty("Unit"));
    new GqlpVoid().ToStructured().ShouldBe(Structured.Empty("Void"));
  }

  [Fact]
  public void GqlpValues_EqualityAndHash()
  {
    GqlpList a = new([new GqlpScalar("x")], "T");
    GqlpList b = new([new GqlpScalar("x")], "T");

    a.ShouldBe(b);
    a.GetHashCode().ShouldBe(b.GetHashCode());
    a.ShouldNotBe(new GqlpList([new GqlpScalar("y")], "T"));
    new GqlpNull().Equals(new GqlpVoid()).ShouldBeFalse();
  }

  private static IGqlpValue RoundTrip(Structured structured)
  {
    IGqlpValue value = structured.ToGqlpValue();
    value.ToStructured().ShouldBe(structured);
    return value;
  }
}

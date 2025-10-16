//HintName: test_all_Impl.gen.cs
// Generated from all.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_all;

public class testGuid
  : ItestGuid
{
}

public class testMany
  : ItestMany
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}

public class testField
  : ItestField
{
  public String strings { get; set; }
}

public class testParam
  : ItestParam
{
  public Many afterId { get; set; }
  public Many beforeId { get; set; }
  public String AsString { get; set; }
}

public class testAll
  : ItestAll
{
  public Field items { get; set; }
  public String AsString { get; set; }
}

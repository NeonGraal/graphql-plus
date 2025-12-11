//HintName: test_all_Impl.gen.cs
// Generated from all.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

public class testGuid
  : DomainString
  , ItestGuid
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
  public ICollection<testString> strings { get; set; }
  public testField Field { get; set; }
}

public class testParam
  : ItestParam
{
  public testMany? afterId { get; set; }
  public testMany beforeId { get; set; }
  public testString AsString { get; set; }
  public testParam Param { get; set; }
}

public class testAll
  : ItestAll
{
  public testField items { get; set; }
  public testString AsString { get; set; }
  public testAll All { get; set; }
}

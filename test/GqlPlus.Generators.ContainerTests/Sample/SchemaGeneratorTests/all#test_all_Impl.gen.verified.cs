//HintName: test_all_Impl.gen.cs
// Generated from all.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

public class testGuid
  : GqlpDomainString
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
  public ICollection<string> Strings { get; set; }
}

public class testParam
  : ItestParam
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }
}

public class testAll
  : ItestAll
{
  public ItestField Items { get; set; }
}

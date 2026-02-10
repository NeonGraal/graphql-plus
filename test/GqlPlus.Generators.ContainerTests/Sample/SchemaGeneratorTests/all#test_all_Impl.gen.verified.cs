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
  public ICollection<string> Strings { get; set; }
  public ItestFieldObject AsField { get; set; }
}

public class testParam
  : ItestParam
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }
  public string AsString { get; set; }
  public ItestParamObject AsParam { get; set; }
}

public class testAll
  : ItestAll
{
  public ItestField Items { get; set; }
  public string AsString { get; set; }
  public ItestAllObject AsAll { get; set; }
}

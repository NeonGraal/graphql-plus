//HintName: Gqlp_all_Impl.gen.cs
// Generated from all.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_all;
public class DomainGuid
  : IGuid
{
}
public class UnionMany
  : IMany
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}
public class DualField
  : IField
{
  public String strings { get; set; }
}
public class InputParam
  : IParam
{
  public Many afterId { get; set; }
  public Many beforeId { get; set; }
  public String AsString { get; set; }
}
public class OutputAll
  : IAll
{
  public Field items { get; set; }
  public String AsString { get; set; }
}

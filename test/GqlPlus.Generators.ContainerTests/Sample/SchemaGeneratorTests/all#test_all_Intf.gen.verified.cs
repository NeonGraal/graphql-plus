//HintName: test_all_Intf.gen.cs
// Generated from all.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

public interface ItestGuid
  : IDomainString
{
}

public interface ItestMany
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}

public interface ItestField
{
}

public interface ItestFieldObject
{
  public ICollection<ItestString> Strings { get; set; }
}

public interface ItestParam
{
  public ItestString AsString { get; set; }
}

public interface ItestParamObject
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }
}

public interface ItestAll
{
  public ItestString AsString { get; set; }
}

public interface ItestAllObject
{
  public ItestField Items { get; set; }
}

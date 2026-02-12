//HintName: test_all_Intf.gen.cs
// Generated from all.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

public interface ItestGuid
  : IGqlpDomainString
{
}

public interface ItestMany
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}

public interface ItestField
{
  ItestFieldObject AsField { get; }
}

public interface ItestFieldObject
{
  ICollection<string> Strings { get; }
}

public interface ItestParam
{
  string AsString { get; }
  ItestParamObject AsParam { get; }
}

public interface ItestParamObject
{
  ItestMany? AfterId { get; }
  ItestMany BeforeId { get; }
}

public interface ItestAll
{
  string AsString { get; }
  ItestAllObject AsAll { get; }
}

public interface ItestAllObject
{
  ItestField Items { get; }
}

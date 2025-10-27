//HintName: test_all_Intf.gen.cs
// Generated from all.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_all;

public interface ItestGuid
{
}

public interface ItestMany
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}

public interface ItestField
{
  String strings { get; }
}

public interface ItestParam
{
  Many afterId { get; }
  Many beforeId { get; }
  String AsString { get; }
}

public interface ItestAll
{
  Field items { get; }
  String AsString { get; }
}

//HintName: Gqlp_all_Intf.gen.cs
// Generated from all.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_all;

public interface IGuid
{
}

public interface IMany
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}

public interface IField
{
  String strings { get; }
}

public interface IParam
{
  Many afterId { get; }
  Many beforeId { get; }
  String AsString { get; }
}

public interface IAll
{
  Field items { get; }
  String AsString { get; }
}

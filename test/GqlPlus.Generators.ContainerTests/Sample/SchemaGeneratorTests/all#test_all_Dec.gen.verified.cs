//HintName: test_all_Dec.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

public interface ItestGuid
  : IGqlpDomainString
{
}

public enum testOne
{
  Two,
  Three,
}

public interface ItestMany
  // No Base because it's Class
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}

public interface ItestField
  // No Base because it's Class
{
  ItestFieldObject? As_Field { get; }
}

public interface ItestFieldObject
  // No Base because it's Class
{
  ICollection<string> Strings { get; }
}

public interface ItestParam
  // No Base because it's Class
{
  string? AsString { get; }
  ItestParamObject? As_Param { get; }
}

public interface ItestParamObject
  // No Base because it's Class
{
  ItestMany? AfterId { get; }
  ItestMany BeforeId { get; }
}

public interface ItestAll
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAllObject? As_All { get; }
}

public interface ItestAllObject
  // No Base because it's Class
{
  ItestField? Items(ItestParam? parameter);
}

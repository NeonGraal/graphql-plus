//HintName: test_all_Intf.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
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
  : IGqlpModelImplementationBase
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}

public interface ItestField
  : IGqlpModelImplementationBase
{
  ItestFieldObject? As_Field { get; }
}

public interface ItestFieldObject
  : IGqlpModelImplementationBase
{
  ICollection<string> Strings { get; }
}

public interface ItestParam
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestParamObject? As_Param { get; }
}

public interface ItestParamObject
  : IGqlpModelImplementationBase
{
  ItestMany? AfterId { get; }
  ItestMany BeforeId { get; }
}

public interface ItestAll
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAllObject? As_All { get; }
}

public interface ItestAllObject
  : IGqlpModelImplementationBase
{
  ItestField? Items(ItestParam? parameter);
}

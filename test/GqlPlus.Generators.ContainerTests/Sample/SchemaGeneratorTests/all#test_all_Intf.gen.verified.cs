//HintName: test_all_Intf.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
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
  : IGqlpInterfaceBase
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}

public interface ItestField
  : IGqlpInterfaceBase
{
  ItestFieldObject? As_Field { get; }
}

public interface ItestFieldObject
  : IGqlpInterfaceBase
{
  ICollection<string> Strings { get; }
}

public interface ItestParam
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestParamObject? As_Param { get; }
}

public interface ItestParamObject
  : IGqlpInterfaceBase
{
  ItestMany? AfterId { get; }
  ItestMany BeforeId { get; }
}

public interface ItestAll
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAllObject? As_All { get; }
}

public interface ItestAllObject
  : IGqlpInterfaceBase
{
  ItestField? Items(ItestParam? parameter);
}

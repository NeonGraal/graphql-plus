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

public interface ItestMany
  : IGqlpModelImplementationBase
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}

public interface ItestField
  : IGqlpModelImplementationBase
{
  ItestFieldObject AsField { get; }
}

public interface ItestFieldObject
{
  ICollection<string> Strings { get; }
}

public interface ItestParam
  : IGqlpModelImplementationBase
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
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAllObject AsAll { get; }
}

public interface ItestAllObject
{
  ItestField Items (ItestParam? parameter);
}

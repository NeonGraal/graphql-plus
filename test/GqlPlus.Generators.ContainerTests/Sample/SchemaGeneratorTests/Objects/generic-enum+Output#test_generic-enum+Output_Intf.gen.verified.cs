//HintName: test_generic-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public interface ItestGnrcEnumOutp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp>? AsEnumGnrcEnumOutpgnrcEnumOutp { get; }
  ItestGnrcEnumOutpObject? As_GnrcEnumOutp { get; }
}

public interface ItestGnrcEnumOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcEnumOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcEnumOutpObject<TType>? As_RefGnrcEnumOutp { get; }
}

public interface ItestRefGnrcEnumOutpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}

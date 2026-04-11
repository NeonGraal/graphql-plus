//HintName: test_generic-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public interface ItestGnrcEnumOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp>? AsEnumGnrcEnumOutpgnrcEnumOutp { get; }
  ItestGnrcEnumOutpObject? As_GnrcEnumOutp { get; }
}

public interface ItestGnrcEnumOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcEnumOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumOutpObject<TType>? As_RefGnrcEnumOutp { get; }
}

public interface ItestRefGnrcEnumOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcEnumOutp
{
  gnrcEnumOutp,
}

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
  ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp> AsEnumGnrcEnumOutpgnrcEnumOutp { get; }
  ItestGnrcEnumOutpObject AsGnrcEnumOutp { get; }
}

public interface ItestGnrcEnumOutpObject
{
}

public interface ItestRefGnrcEnumOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcEnumOutpObject<TType> AsRefGnrcEnumOutp { get; }
}

public interface ItestRefGnrcEnumOutpObject<TType>
{
  TType Field { get; }
}

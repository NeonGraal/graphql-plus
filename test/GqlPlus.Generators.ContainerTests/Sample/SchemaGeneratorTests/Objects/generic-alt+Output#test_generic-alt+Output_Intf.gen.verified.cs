//HintName: test_generic-alt+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Output;

public interface ItestGnrcAltOutp<TType>
  : IGqlpModelImplementationBase
{
  TType? Astype { get; }
  ItestGnrcAltOutpObject<TType>? As_GnrcAltOutp { get; }
}

public interface ItestGnrcAltOutpObject<TType>
  : IGqlpModelImplementationBase
{
}

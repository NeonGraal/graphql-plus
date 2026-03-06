//HintName: test_generic-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Output;

public interface ItestGnrcDescrOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestGnrcDescrOutpObject<TType>? As_GnrcDescrOutp { get; }
}

public interface ItestGnrcDescrOutpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}

//HintName: test_generic-field+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Output;

public interface ItestGnrcFieldOutp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldOutpObject<TType>? As_GnrcFieldOutp { get; }
}

public interface ItestGnrcFieldOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

//HintName: test_generic-alt-arg+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public interface ItestGnrcAltArgOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgOutp<TType>? AsRefGnrcAltArgOutp { get; }
  ItestGnrcAltArgOutpObject<TType>? As_GnrcAltArgOutp { get; }
}

public interface ItestGnrcAltArgOutpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgOutpObject<TRef>? As_RefGnrcAltArgOutp { get; }
}

public interface ItestRefGnrcAltArgOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

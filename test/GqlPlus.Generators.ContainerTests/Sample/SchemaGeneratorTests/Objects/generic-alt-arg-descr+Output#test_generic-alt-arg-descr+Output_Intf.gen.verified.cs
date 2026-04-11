//HintName: test_generic-alt-arg-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public interface ItestGnrcAltArgDescrOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgDescrOutp<TType>? AsRefGnrcAltArgDescrOutp { get; }
  ItestGnrcAltArgDescrOutpObject<TType>? As_GnrcAltArgDescrOutp { get; }
}

public interface ItestGnrcAltArgDescrOutpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgDescrOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDescrOutpObject<TRef>? As_RefGnrcAltArgDescrOutp { get; }
}

public interface ItestRefGnrcAltArgDescrOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

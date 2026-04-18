//HintName: test_generic-alt-simple+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public interface ItestGnrcAltSmplOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltSmplOutp<string>? AsRefGnrcAltSmplOutp { get; }
  ItestGnrcAltSmplOutpObject? As_GnrcAltSmplOutp { get; }
}

public interface ItestGnrcAltSmplOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltSmplOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplOutpObject<TRef>? As_RefGnrcAltSmplOutp { get; }
}

public interface ItestRefGnrcAltSmplOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

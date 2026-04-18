//HintName: test_generic-parent-param-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public interface ItestGnrcPrntParamPrntOutp
  : ItestRefGnrcPrntParamPrntOutp<ItestAltGnrcPrntParamPrntOutp>
{
  ItestGnrcPrntParamPrntOutpObject? As_GnrcPrntParamPrntOutp { get; }
}

public interface ItestGnrcPrntParamPrntOutpObject
  : ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>
{
}

public interface ItestRefGnrcPrntParamPrntOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntParamPrntOutpObject<TRef>? As_RefGnrcPrntParamPrntOutp { get; }
}

public interface ItestRefGnrcPrntParamPrntOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntParamPrntOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamPrntOutpObject? As_AltGnrcPrntParamPrntOutp { get; }
}

public interface ItestAltGnrcPrntParamPrntOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

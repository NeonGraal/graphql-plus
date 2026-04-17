//HintName: test_generic-parent-simple-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public interface ItestGnrcPrntSmplEnumOutp
  : ItestFieldGnrcPrntSmplEnumOutp<testEnumGnrcPrntSmplEnumOutp>
{
  ItestGnrcPrntSmplEnumOutpObject? As_GnrcPrntSmplEnumOutp { get; }
}

public interface ItestGnrcPrntSmplEnumOutpObject
  : ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>
{
}

public interface ItestFieldGnrcPrntSmplEnumOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntSmplEnumOutpObject<TRef>? As_FieldGnrcPrntSmplEnumOutp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntSmplEnumOutp
{
  gnrcPrntSmplEnumOutp,
}

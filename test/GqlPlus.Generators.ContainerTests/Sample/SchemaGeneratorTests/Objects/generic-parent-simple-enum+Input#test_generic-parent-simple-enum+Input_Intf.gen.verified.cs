//HintName: test_generic-parent-simple-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

public interface ItestGnrcPrntSmplEnumInp
  : ItestFieldGnrcPrntSmplEnumInp<testEnumGnrcPrntSmplEnumInp>
{
  ItestGnrcPrntSmplEnumInpObject? As_GnrcPrntSmplEnumInp { get; }
}

public interface ItestGnrcPrntSmplEnumInpObject
  : ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>
{
}

public interface ItestFieldGnrcPrntSmplEnumInp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntSmplEnumInpObject<TRef>? As_FieldGnrcPrntSmplEnumInp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntSmplEnumInp
{
  gnrcPrntSmplEnumInp,
}

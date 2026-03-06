//HintName: test_generic-parent-simple-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  : IGqlpModelImplementationBase
{
  ItestFieldGnrcPrntSmplEnumInpObject<TRef>? As_FieldGnrcPrntSmplEnumInp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumInpObject<TRef>
  : IGqlpModelImplementationBase
{
  TRef Field { get; }
}

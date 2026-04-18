//HintName: test_generic-parent-enum-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

public interface ItestGnrcPrntEnumPrntInp
  : ItestFieldGnrcPrntEnumPrntInp<testEnumGnrcPrntEnumPrntInp>
{
  ItestGnrcPrntEnumPrntInpObject? As_GnrcPrntEnumPrntInp { get; }
}

public interface ItestGnrcPrntEnumPrntInpObject
  : ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>
{
}

public interface ItestFieldGnrcPrntEnumPrntInp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumPrntInpObject<TRef>? As_FieldGnrcPrntEnumPrntInp { get; }
}

public interface ItestFieldGnrcPrntEnumPrntInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent = testParentGnrcPrntEnumPrntInp.gnrcPrntEnumPrntInpParent,
  gnrcPrntEnumPrntInpLabel,
}

public enum testParentGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent,
}

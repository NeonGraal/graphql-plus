//HintName: test_generic-parent-enum-child+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

public interface ItestGnrcPrntEnumChildOutp
  : ItestFieldGnrcPrntEnumChildOutp<testParentGnrcPrntEnumChildOutp>
{
  ItestGnrcPrntEnumChildOutpObject? As_GnrcPrntEnumChildOutp { get; }
}

public interface ItestGnrcPrntEnumChildOutpObject
  : ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>
{
}

public interface ItestFieldGnrcPrntEnumChildOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumChildOutpObject<TRef>? As_FieldGnrcPrntEnumChildOutp { get; }
}

public interface ItestFieldGnrcPrntEnumChildOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumChildOutp
{
  gnrcPrntEnumChildOutpParent = testParentGnrcPrntEnumChildOutp.gnrcPrntEnumChildOutpParent,
  gnrcPrntEnumChildOutpLabel,
}

public enum testParentGnrcPrntEnumChildOutp
{
  gnrcPrntEnumChildOutpParent,
}

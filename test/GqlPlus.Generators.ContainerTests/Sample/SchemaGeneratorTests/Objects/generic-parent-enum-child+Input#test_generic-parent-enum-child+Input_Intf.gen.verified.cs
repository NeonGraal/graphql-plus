//HintName: test_generic-parent-enum-child+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public interface ItestGnrcPrntEnumChildInp
  : ItestFieldGnrcPrntEnumChildInp<testParentGnrcPrntEnumChildInp>
{
  ItestGnrcPrntEnumChildInpObject AsGnrcPrntEnumChildInp { get; }
}

public interface ItestGnrcPrntEnumChildInpObject
  : ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>
{
}

public interface ItestFieldGnrcPrntEnumChildInp<TRef>
  : IGqlpModelImplementationBase
{
  ItestFieldGnrcPrntEnumChildInpObject<TRef> AsFieldGnrcPrntEnumChildInp { get; }
}

public interface ItestFieldGnrcPrntEnumChildInpObject<TRef>
{
  TRef Field { get; }
}

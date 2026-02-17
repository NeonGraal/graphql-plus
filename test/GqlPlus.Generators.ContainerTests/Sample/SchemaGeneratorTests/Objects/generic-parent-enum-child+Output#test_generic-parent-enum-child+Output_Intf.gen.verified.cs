//HintName: test_generic-parent-enum-child+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

public interface ItestGnrcPrntEnumChildOutp
  : ItestFieldGnrcPrntEnumChildOutp<testParentGnrcPrntEnumChildOutp>
{
  ItestGnrcPrntEnumChildOutpObject AsGnrcPrntEnumChildOutp { get; }
}

public interface ItestGnrcPrntEnumChildOutpObject
  : ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>
{
}

public interface ItestFieldGnrcPrntEnumChildOutp<TRef>
  : IGqlpModelImplementationBase
{
  ItestFieldGnrcPrntEnumChildOutpObject<TRef> AsFieldGnrcPrntEnumChildOutp { get; }
}

public interface ItestFieldGnrcPrntEnumChildOutpObject<TRef>
{
  TRef Field { get; }
}

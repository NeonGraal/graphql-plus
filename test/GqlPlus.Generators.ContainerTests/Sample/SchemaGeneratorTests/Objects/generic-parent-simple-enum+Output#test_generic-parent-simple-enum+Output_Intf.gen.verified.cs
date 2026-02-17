//HintName: test_generic-parent-simple-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public interface ItestGnrcPrntSmplEnumOutp
  : ItestFieldGnrcPrntSmplEnumOutp<testEnumGnrcPrntSmplEnumOutp>
{
  ItestGnrcPrntSmplEnumOutpObject AsGnrcPrntSmplEnumOutp { get; }
}

public interface ItestGnrcPrntSmplEnumOutpObject
  : ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>
{
}

public interface ItestFieldGnrcPrntSmplEnumOutp<TRef>
  : IGqlpModelImplementationBase
{
  ItestFieldGnrcPrntSmplEnumOutpObject<TRef> AsFieldGnrcPrntSmplEnumOutp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumOutpObject<TRef>
{
  TRef Field { get; }
}

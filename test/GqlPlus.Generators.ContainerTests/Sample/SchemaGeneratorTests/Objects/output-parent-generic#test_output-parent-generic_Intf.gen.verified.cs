//HintName: test_output-parent-generic_Intf.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public interface ItestOutpPrntGnrc
  : IGqlpModelImplementationBase
{
  ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc> AsEnumOutpPrntGnrcprnt_outpPrntGnrc { get; }
  ItestOutpPrntGnrcObject AsOutpPrntGnrc { get; }
}

public interface ItestOutpPrntGnrcObject
{
}

public interface ItestRefOutpPrntGnrc<TType>
  : IGqlpModelImplementationBase
{
  ItestRefOutpPrntGnrcObject<TType> AsRefOutpPrntGnrc { get; }
}

public interface ItestRefOutpPrntGnrcObject<TType>
{
  TType Field { get; }
}

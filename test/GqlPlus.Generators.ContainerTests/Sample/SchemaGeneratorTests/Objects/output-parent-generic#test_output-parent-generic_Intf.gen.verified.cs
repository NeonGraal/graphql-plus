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
  ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc>? AsEnumOutpPrntGnrcprnt_outpPrntGnrc { get; }
  ItestOutpPrntGnrcObject? As_OutpPrntGnrc { get; }
}

public interface ItestOutpPrntGnrcObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefOutpPrntGnrc<TType>
  : IGqlpModelImplementationBase
{
  ItestRefOutpPrntGnrcObject<TType>? As_RefOutpPrntGnrc { get; }
}

public interface ItestRefOutpPrntGnrcObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}

public enum testEnumOutpPrntGnrc
{
  prnt_outpPrntGnrc = testPrntOutpPrntGnrc.prnt_outpPrntGnrc,
  outpPrntGnrc,
}

public enum testPrntOutpPrntGnrc
{
  prnt_outpPrntGnrc,
}

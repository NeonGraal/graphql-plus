//HintName: test_output-parent-generic_Dec.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public interface ItestOutpPrntGnrc
  // No Base because it's Class
{
  ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc>? AsEnumOutpPrntGnrcprnt_outpPrntGnrc { get; }
  ItestOutpPrntGnrcObject? As_OutpPrntGnrc { get; }
}

public interface ItestOutpPrntGnrcObject
  // No Base because it's Class
{
}

public interface ItestRefOutpPrntGnrc<TType>
  // No Base because it's Class
{
  ItestRefOutpPrntGnrcObject<TType>? As_RefOutpPrntGnrc { get; }
}

public interface ItestRefOutpPrntGnrcObject<TType>
  // No Base because it's Class
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

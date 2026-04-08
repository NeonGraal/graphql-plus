//HintName: test_output-parent-generic_Enc.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public class testOutpPrntGnrc
  : GqlpEncoderBase
  , ItestOutpPrntGnrc
{
  public ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc>? AsEnumOutpPrntGnrcprnt_outpPrntGnrc { get; set; }
  public ItestOutpPrntGnrcObject? As_OutpPrntGnrc { get; set; }
}

public class testOutpPrntGnrcObject
  : GqlpEncoderBase
  , ItestOutpPrntGnrcObject
{

  public testOutpPrntGnrcObject
    ()
  {
  }
}

public class testRefOutpPrntGnrc<TType>
  : GqlpEncoderBase
  , ItestRefOutpPrntGnrc<TType>
{
  public ItestRefOutpPrntGnrcObject<TType>? As_RefOutpPrntGnrc { get; set; }
}

public class testRefOutpPrntGnrcObject<TType>
  : GqlpEncoderBase
  , ItestRefOutpPrntGnrcObject<TType>
{
  public TType Field { get; set; }

  public testRefOutpPrntGnrcObject
    ( TType field
    )
  {
    Field = field;
  }
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

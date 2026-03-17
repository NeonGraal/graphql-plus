//HintName: test_output-parent-generic_Model.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public class testOutpPrntGnrc
  : GqlpModelImplementationBase
  , ItestOutpPrntGnrc
{
  public ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc>? AsEnumOutpPrntGnrcprnt_outpPrntGnrc { get; set; }
  public ItestOutpPrntGnrcObject? As_OutpPrntGnrc { get; set; }
}

public class testOutpPrntGnrcObject
  : GqlpModelImplementationBase
  , ItestOutpPrntGnrcObject
{
}

public class testRefOutpPrntGnrc<TType>
  : GqlpModelImplementationBase
  , ItestRefOutpPrntGnrc<TType>
{
  public ItestRefOutpPrntGnrcObject<TType>? As_RefOutpPrntGnrc { get; set; }
}

public class testRefOutpPrntGnrcObject<TType>
  : GqlpModelImplementationBase
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

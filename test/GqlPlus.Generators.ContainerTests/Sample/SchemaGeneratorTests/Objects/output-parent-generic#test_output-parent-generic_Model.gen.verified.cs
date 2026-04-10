//HintName: test_output-parent-generic_Model.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public class testOutpPrntGnrc
  : GqlpModelBase
  , ItestOutpPrntGnrc
{
  public ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc>? AsEnumOutpPrntGnrcprnt_outpPrntGnrc { get; set; }
  public ItestOutpPrntGnrcObject? As_OutpPrntGnrc { get; set; }
}

public class testOutpPrntGnrcObject
  : GqlpModelBase
  , ItestOutpPrntGnrcObject
{

  public testOutpPrntGnrcObject
    ()
  {
  }
}

public class testRefOutpPrntGnrc<TType>
  : GqlpModelBase
  , ItestRefOutpPrntGnrc<TType>
{
  public ItestRefOutpPrntGnrcObject<TType>? As_RefOutpPrntGnrc { get; set; }
}

public class testRefOutpPrntGnrcObject<TType>
  : GqlpModelBase
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

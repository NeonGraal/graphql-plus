//HintName: test_constraint-field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public class testCnstFieldDualInp
  : testRefCnstFieldDualInp<ItestAltCnstFieldDualInp>
  , ItestCnstFieldDualInp
{
  public ItestCnstFieldDualInpObject? As_CnstFieldDualInp { get; set; }
}

public class testCnstFieldDualInpObject
  : testRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>
  , ItestCnstFieldDualInpObject
{

  public testCnstFieldDualInpObject
    ( ItestAltCnstFieldDualInp field
    ) : base(field)
  {
  }
}

public class testRefCnstFieldDualInp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstFieldDualInp<TRef>
{
  public ItestRefCnstFieldDualInpObject<TRef>? As_RefCnstFieldDualInp { get; set; }
}

public class testRefCnstFieldDualInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstFieldDualInpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldDualInpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testPrntCnstFieldDualInp
  : GqlpEncoderBase
  , ItestPrntCnstFieldDualInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstFieldDualInpObject? As_PrntCnstFieldDualInp { get; set; }
}

public class testPrntCnstFieldDualInpObject
  : GqlpEncoderBase
  , ItestPrntCnstFieldDualInpObject
{

  public testPrntCnstFieldDualInpObject
    ()
  {
  }
}

public class testAltCnstFieldDualInp
  : testPrntCnstFieldDualInp
  , ItestAltCnstFieldDualInp
{
  public ItestAltCnstFieldDualInpObject? As_AltCnstFieldDualInp { get; set; }
}

public class testAltCnstFieldDualInpObject
  : testPrntCnstFieldDualInpObject
  , ItestAltCnstFieldDualInpObject
{
  public decimal Alt { get; set; }

  public testAltCnstFieldDualInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}

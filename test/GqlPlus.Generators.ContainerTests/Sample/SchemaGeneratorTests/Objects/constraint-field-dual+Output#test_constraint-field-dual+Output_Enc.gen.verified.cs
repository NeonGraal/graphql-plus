//HintName: test_constraint-field-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public class testCnstFieldDualOutp
  : testRefCnstFieldDualOutp<ItestAltCnstFieldDualOutp>
  , ItestCnstFieldDualOutp
{
  public ItestCnstFieldDualOutpObject? As_CnstFieldDualOutp { get; set; }
}

public class testCnstFieldDualOutpObject
  : testRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>
  , ItestCnstFieldDualOutpObject
{

  public testCnstFieldDualOutpObject
    ( ItestAltCnstFieldDualOutp field
    ) : base(field)
  {
  }
}

public class testRefCnstFieldDualOutp<TRef>
  : GqlpEncoderBase
  , ItestRefCnstFieldDualOutp<TRef>
{
  public ItestRefCnstFieldDualOutpObject<TRef>? As_RefCnstFieldDualOutp { get; set; }
}

public class testRefCnstFieldDualOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefCnstFieldDualOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldDualOutpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testPrntCnstFieldDualOutp
  : GqlpEncoderBase
  , ItestPrntCnstFieldDualOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstFieldDualOutpObject? As_PrntCnstFieldDualOutp { get; set; }
}

public class testPrntCnstFieldDualOutpObject
  : GqlpEncoderBase
  , ItestPrntCnstFieldDualOutpObject
{

  public testPrntCnstFieldDualOutpObject
    ()
  {
  }
}

public class testAltCnstFieldDualOutp
  : testPrntCnstFieldDualOutp
  , ItestAltCnstFieldDualOutp
{
  public ItestAltCnstFieldDualOutpObject? As_AltCnstFieldDualOutp { get; set; }
}

public class testAltCnstFieldDualOutpObject
  : testPrntCnstFieldDualOutpObject
  , ItestAltCnstFieldDualOutpObject
{
  public decimal Alt { get; set; }

  public testAltCnstFieldDualOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}

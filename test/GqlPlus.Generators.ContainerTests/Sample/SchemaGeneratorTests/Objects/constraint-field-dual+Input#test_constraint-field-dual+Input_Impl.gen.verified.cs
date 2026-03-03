//HintName: test_constraint-field-dual+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
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
  : GqlpModelImplementationBase
  , ItestRefCnstFieldDualInp<TRef>
{
  public ItestRefCnstFieldDualInpObject<TRef>? As_RefCnstFieldDualInp { get; set; }
}

public class testRefCnstFieldDualInpObject<TRef>
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , ItestPrntCnstFieldDualInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstFieldDualInpObject? As_PrntCnstFieldDualInp { get; set; }
}

public class testPrntCnstFieldDualInpObject
  : GqlpModelImplementationBase
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

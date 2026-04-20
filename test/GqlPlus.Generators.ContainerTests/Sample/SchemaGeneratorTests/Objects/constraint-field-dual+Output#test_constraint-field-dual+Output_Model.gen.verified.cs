//HintName: test_constraint-field-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
    ( ItestAltCnstFieldDualOutp pfield
    ) : base(pfield)
  {
  }
}

public class testRefCnstFieldDualOutp<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDualOutp<TRef>
{
  public ItestRefCnstFieldDualOutpObject<TRef>? As_RefCnstFieldDualOutp { get; set; }
}

public class testRefCnstFieldDualOutpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDualOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldDualOutpObject
    ( TRef pfield
    )
  {
    Field = pfield;
  }
}

public class testPrntCnstFieldDualOutp
  : GqlpModelBase
  , ItestPrntCnstFieldDualOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstFieldDualOutpObject? As_PrntCnstFieldDualOutp { get; set; }
}

public class testPrntCnstFieldDualOutpObject
  : GqlpModelBase
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
    ( decimal palt
    )
  {
    Alt = palt;
  }
}

//HintName: test_constraint-alt-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public class testCnstAltDualOutp
  : GqlpModelBase
  , ItestCnstAltDualOutp
{
  public ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp>? AsRefCnstAltDualOutp { get; set; }
  public ItestCnstAltDualOutpObject? As_CnstAltDualOutp { get; set; }
}

public class testCnstAltDualOutpObject
  : GqlpModelBase
  , ItestCnstAltDualOutpObject
{

  public testCnstAltDualOutpObject
    ()
  {
  }
}

public class testRefCnstAltDualOutp<TRef>
  : GqlpModelBase
  , ItestRefCnstAltDualOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDualOutpObject<TRef>? As_RefCnstAltDualOutp { get; set; }
}

public class testRefCnstAltDualOutpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstAltDualOutpObject<TRef>
{

  public testRefCnstAltDualOutpObject
    ()
  {
  }
}

public class testPrntCnstAltDualOutp
  : GqlpModelBase
  , ItestPrntCnstAltDualOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltDualOutpObject? As_PrntCnstAltDualOutp { get; set; }
}

public class testPrntCnstAltDualOutpObject
  : GqlpModelBase
  , ItestPrntCnstAltDualOutpObject
{

  public testPrntCnstAltDualOutpObject
    ()
  {
  }
}

public class testAltCnstAltDualOutp
  : testPrntCnstAltDualOutp
  , ItestAltCnstAltDualOutp
{
  public ItestAltCnstAltDualOutpObject? As_AltCnstAltDualOutp { get; set; }
}

public class testAltCnstAltDualOutpObject
  : testPrntCnstAltDualOutpObject
  , ItestAltCnstAltDualOutpObject
{
  public decimal Alt { get; set; }

  public testAltCnstAltDualOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}

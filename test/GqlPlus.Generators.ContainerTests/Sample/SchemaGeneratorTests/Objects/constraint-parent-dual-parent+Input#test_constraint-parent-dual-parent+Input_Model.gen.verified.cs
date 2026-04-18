//HintName: test_constraint-parent-dual-parent+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public class testCnstPrntDualPrntInp
  : testRefCnstPrntDualPrntInp<ItestAltCnstPrntDualPrntInp>
  , ItestCnstPrntDualPrntInp
{
  public ItestCnstPrntDualPrntInpObject? As_CnstPrntDualPrntInp { get; set; }
}

public class testCnstPrntDualPrntInpObject
  : testRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>
  , ItestCnstPrntDualPrntInpObject
{

  public testCnstPrntDualPrntInpObject
    ()
  {
  }
}

public class testRefCnstPrntDualPrntInp<TRef>
  : GqlpModelBase
  , ItestRefCnstPrntDualPrntInp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntDualPrntInpObject<TRef>? As_RefCnstPrntDualPrntInp { get; set; }
}

public class testRefCnstPrntDualPrntInpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstPrntDualPrntInpObject<TRef>
{

  public testRefCnstPrntDualPrntInpObject
    ()
  {
  }
}

public class testPrntCnstPrntDualPrntInp
  : GqlpModelBase
  , ItestPrntCnstPrntDualPrntInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstPrntDualPrntInpObject? As_PrntCnstPrntDualPrntInp { get; set; }
}

public class testPrntCnstPrntDualPrntInpObject
  : GqlpModelBase
  , ItestPrntCnstPrntDualPrntInpObject
{

  public testPrntCnstPrntDualPrntInpObject
    ()
  {
  }
}

public class testAltCnstPrntDualPrntInp
  : testPrntCnstPrntDualPrntInp
  , ItestAltCnstPrntDualPrntInp
{
  public ItestAltCnstPrntDualPrntInpObject? As_AltCnstPrntDualPrntInp { get; set; }
}

public class testAltCnstPrntDualPrntInpObject
  : testPrntCnstPrntDualPrntInpObject
  , ItestAltCnstPrntDualPrntInpObject
{
  public decimal Alt { get; set; }

  public testAltCnstPrntDualPrntInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}

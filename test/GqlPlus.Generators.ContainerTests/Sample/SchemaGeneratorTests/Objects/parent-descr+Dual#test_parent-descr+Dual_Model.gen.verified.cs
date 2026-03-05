//HintName: test_parent-descr+Dual_Model.gen.cs
// Generated from {CurrentDirectory}parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public class testPrntDescrDual
  : testRefPrntDescrDual
  , ItestPrntDescrDual
{
  public ItestPrntDescrDualObject? As_PrntDescrDual { get; set; }
}

public class testPrntDescrDualObject
  : testRefPrntDescrDualObject
  , ItestPrntDescrDualObject
{

  public testPrntDescrDualObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntDescrDual
  : GqlpModelImplementationBase
  , ItestRefPrntDescrDual
{
  public string? AsString { get; set; }
  public ItestRefPrntDescrDualObject? As_RefPrntDescrDual { get; set; }
}

public class testRefPrntDescrDualObject
  : GqlpModelImplementationBase
  , ItestRefPrntDescrDualObject
{
  public decimal Parent { get; set; }

  public testRefPrntDescrDualObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}

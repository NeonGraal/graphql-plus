//HintName: test_parent-descr+Input_Impl.gen.cs
// Generated from {CurrentDirectory}parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public class testPrntDescrInp
  : testRefPrntDescrInp
  , ItestPrntDescrInp
{
  public ItestPrntDescrInpObject? As_PrntDescrInp { get; set; }
}

public class testPrntDescrInpObject
  : testRefPrntDescrInpObject
  , ItestPrntDescrInpObject
{

  public testPrntDescrInpObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntDescrInp
  : GqlpModelImplementationBase
  , ItestRefPrntDescrInp
{
  public string? AsString { get; set; }
  public ItestRefPrntDescrInpObject? As_RefPrntDescrInp { get; set; }
}

public class testRefPrntDescrInpObject
  : GqlpModelImplementationBase
  , ItestRefPrntDescrInpObject
{
  public decimal Parent { get; set; }

  public testRefPrntDescrInpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}

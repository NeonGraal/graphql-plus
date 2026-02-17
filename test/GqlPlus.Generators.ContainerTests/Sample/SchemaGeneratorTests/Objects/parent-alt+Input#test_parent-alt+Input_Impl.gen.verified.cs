//HintName: test_parent-alt+Input_Impl.gen.cs
// Generated from {CurrentDirectory}parent-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public class testPrntAltInp
  : testRefPrntAltInp
  , ItestPrntAltInp
{
  public decimal? AsNumber { get; set; }
  public ItestPrntAltInpObject? As_PrntAltInp { get; set; }
}

public class testPrntAltInpObject
  : testRefPrntAltInpObject
  , ItestPrntAltInpObject
{

  public testPrntAltInpObject(decimal parent)
    : base(parent)
  {
  }
}

public class testRefPrntAltInp
  : GqlpModelImplementationBase
  , ItestRefPrntAltInp
{
  public string? AsString { get; set; }
  public ItestRefPrntAltInpObject? As_RefPrntAltInp { get; set; }
}

public class testRefPrntAltInpObject
  : GqlpModelImplementationBase
  , ItestRefPrntAltInpObject
{
  public decimal Parent { get; set; }

  public testRefPrntAltInpObject(decimal parent)
  {
    Parent = parent;
  }
}

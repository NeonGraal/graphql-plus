//HintName: test_parent-field+Input_Impl.gen.cs
// Generated from {CurrentDirectory}parent-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public class testPrntFieldInp
  : testRefPrntFieldInp
  , ItestPrntFieldInp
{
  public ItestPrntFieldInpObject? As_PrntFieldInp { get; set; }
}

public class testPrntFieldInpObject
  : testRefPrntFieldInpObject
  , ItestPrntFieldInpObject
{
  public decimal Field { get; set; }

  public testPrntFieldInpObject(decimal parent, decimal field)
    : base(parent)
  {
    Field = field;
  }
}

public class testRefPrntFieldInp
  : GqlpModelImplementationBase
  , ItestRefPrntFieldInp
{
  public string? AsString { get; set; }
  public ItestRefPrntFieldInpObject? As_RefPrntFieldInp { get; set; }
}

public class testRefPrntFieldInpObject
  : GqlpModelImplementationBase
  , ItestRefPrntFieldInpObject
{
  public decimal Parent { get; set; }

  public testRefPrntFieldInpObject(decimal parent)
  {
    Parent = parent;
  }
}

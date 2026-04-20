//HintName: test_parent+Input_Model.gen.cs
// Generated from {CurrentDirectory}parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public class testPrntInp
  : testRefPrntInp
  , ItestPrntInp
{
  public ItestPrntInpObject? As_PrntInp { get; set; }
}

public class testPrntInpObject
  : testRefPrntInpObject
  , ItestPrntInpObject
{

  public testPrntInpObject
    ( decimal pparent
    ) : base(pparent)
  {
  }
}

public class testRefPrntInp
  : GqlpModelBase
  , ItestRefPrntInp
{
  public string? AsString { get; set; }
  public ItestRefPrntInpObject? As_RefPrntInp { get; set; }
}

public class testRefPrntInpObject
  : GqlpModelBase
  , ItestRefPrntInpObject
{
  public decimal Parent { get; set; }

  public testRefPrntInpObject
    ( decimal pparent
    )
  {
    Parent = pparent;
  }
}

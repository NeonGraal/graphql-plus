//HintName: test_parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public class testPrntOutp
  : testRefPrntOutp
  , ItestPrntOutp
{
  public ItestPrntOutpObject? As_PrntOutp { get; set; }
}

public class testPrntOutpObject
  : testRefPrntOutpObject
  , ItestPrntOutpObject
{

  public testPrntOutpObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntOutp
  : GqlpModelBase
  , ItestRefPrntOutp
{
  public string? AsString { get; set; }
  public ItestRefPrntOutpObject? As_RefPrntOutp { get; set; }
}

public class testRefPrntOutpObject
  : GqlpModelBase
  , ItestRefPrntOutpObject
{
  public decimal Parent { get; set; }

  public testRefPrntOutpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}

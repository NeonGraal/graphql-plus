//HintName: test_parent-alt+Output_Impl.gen.cs
// Generated from {CurrentDirectory}parent-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public class testPrntAltOutp
  : testRefPrntAltOutp
  , ItestPrntAltOutp
{
  public decimal? AsNumber { get; set; }
  public ItestPrntAltOutpObject? As_PrntAltOutp { get; set; }
}

public class testPrntAltOutpObject
  : testRefPrntAltOutpObject
  , ItestPrntAltOutpObject
{

  public testPrntAltOutpObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntAltOutp
  : GqlpModelImplementationBase
  , ItestRefPrntAltOutp
{
  public string? AsString { get; set; }
  public ItestRefPrntAltOutpObject? As_RefPrntAltOutp { get; set; }
}

public class testRefPrntAltOutpObject
  : GqlpModelImplementationBase
  , ItestRefPrntAltOutpObject
{
  public decimal Parent { get; set; }

  public testRefPrntAltOutpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}

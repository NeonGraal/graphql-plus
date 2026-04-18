//HintName: test_alt+Output_Model.gen.cs
// Generated from {CurrentDirectory}alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Output;

public class testAltOutp
  : GqlpModelBase
  , ItestAltOutp
{
  public ItestAltAltOutp? AsAltAltOutp { get; set; }
  public ItestAltOutpObject? As_AltOutp { get; set; }
}

public class testAltOutpObject
  : GqlpModelBase
  , ItestAltOutpObject
{

  public testAltOutpObject
    ()
  {
  }
}

public class testAltAltOutp
  : GqlpModelBase
  , ItestAltAltOutp
{
  public string? AsString { get; set; }
  public ItestAltAltOutpObject? As_AltAltOutp { get; set; }
}

public class testAltAltOutpObject
  : GqlpModelBase
  , ItestAltAltOutpObject
{
  public decimal Alt { get; set; }

  public testAltAltOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}

//HintName: test_alt+Output_Model.gen.cs
// Generated from {CurrentDirectory}alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Output;

public class testAltOutp
  : GqlpModelImplementationBase
  , ItestAltOutp
{
  public ItestAltAltOutp? AsAltAltOutp { get; set; }
  public ItestAltOutpObject? As_AltOutp { get; set; }
}

public class testAltOutpObject
  : GqlpModelImplementationBase
  , ItestAltOutpObject
{
}

public class testAltAltOutp
  : GqlpModelImplementationBase
  , ItestAltAltOutp
{
  public string? AsString { get; set; }
  public ItestAltAltOutpObject? As_AltAltOutp { get; set; }
}

public class testAltAltOutpObject
  : GqlpModelImplementationBase
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

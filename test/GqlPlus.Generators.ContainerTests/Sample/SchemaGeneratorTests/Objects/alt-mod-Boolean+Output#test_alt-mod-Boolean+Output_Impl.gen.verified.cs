//HintName: test_alt-mod-Boolean+Output_Impl.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

public class testAltModBoolOutp
  : GqlpModelImplementationBase
  , ItestAltModBoolOutp
{
  public IDictionary<bool, ItestAltAltModBoolOutp>? AsAltAltModBoolOutp { get; set; }
  public ItestAltModBoolOutpObject? As_AltModBoolOutp { get; set; }
}

public class testAltModBoolOutpObject
  : GqlpModelImplementationBase
  , ItestAltModBoolOutpObject
{

  public testAltModBoolOutpObject
    ()
  {
  }
}

public class testAltAltModBoolOutp
  : GqlpModelImplementationBase
  , ItestAltAltModBoolOutp
{
  public string? AsString { get; set; }
  public ItestAltAltModBoolOutpObject? As_AltAltModBoolOutp { get; set; }
}

public class testAltAltModBoolOutpObject
  : GqlpModelImplementationBase
  , ItestAltAltModBoolOutpObject
{
  public decimal Alt { get; set; }

  public testAltAltModBoolOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
